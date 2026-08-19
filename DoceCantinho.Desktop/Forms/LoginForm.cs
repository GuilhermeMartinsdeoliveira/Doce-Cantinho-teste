using DoceCantinho.Desktop.Helpers;
using DoceCantinho.Desktop.Services;


namespace DoceCantinho.Desktop.Forms
{
    public partial class LoginForm : Form
    {
        private AuthApiService _authService = null!;
        public LoginForm()
        {
            InitializeComponent();
        }

        private async void btnEntrar_Click(object sender, EventArgs e)
        {

            //Limpa erros anteriores
            ExibirErro(string.Empty);

            //Validação dos campos
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                ExibirErro("⚠️ Informe seu e-mail!");
                txtEmail.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtSenha.Text))
            {
                ExibirErro("⚠️ Informe sua senha!");
                txtSenha.Focus();
                return;
            }
            // ===================== Estado de carregamento ======================
            SetCarregando(true);

            try
            {
                // Chamada da API
                var (success, user, errorMessage) = await _authService.LoginAsync(
                    txtEmail.Text.Trim(),
                    txtSenha.Text);

                if (success && user != null)
                {
                    // Armazena os dados do usuário na sessão (Singleton)
                    SessionManager.Instance.SetUser(user);

                    // Esconde a tela de login
                    this.Hide();

                    //Abrir a tela principal da aplicação
                    using var doceForm = new MainForm();
                    doceForm.ShowDialog();

                    // quando o MainForm fechar. fecha o LoginForm também
                    this.Close();
                }
                else
                {
                    ExibirErro($"❌ {errorMessage}");
                    MessageBox.Show($"❌ {errorMessage}");
                }

            }
            catch (HttpRequestException exHttp)
            {
                ExibirErro($"❌ Não foi possível conectar à API. \nVerifique se a API está em execução erro do sistema: {exHttp.Message}");
                MessageBox.Show($"❌ Não foi possível conectar à API. \nVerifique se a API está em execução erro do sistema: {exHttp.Message}");
            }
            catch (Exception ex)
            {
                ExibirErro($"❌ Erro inesperado: {ex.Message}");
                MessageBox.Show($"❌ Erro inesperado: {ex.Message}");
            }
            finally
            {
                SetCarregando(false);
            }

        }

        private void ExibirErro(string mensagem)
        {
            if (string.IsNullOrEmpty(mensagem))
            {
                lblErro.Visible = false;
                lblErro.Text = string.Empty;
            }
            else
            {
                lblErro.Text = mensagem;
                lblErro.Visible = true;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e) => System.Windows.Forms.Application.Exit();

        private void LoginForm_Load(object sender, EventArgs e)
        {
            //Guard: não executa em tempo de design
            if (DesignMode) return;

            _authService = new AuthApiService();

            lblVersao.Text = $"Versão {AppConfig.Version} | ©️ {DateTime.Now.Year} SENAC-SMP";
            lblApi.Text = $"API: {AppConfig.ApiBaseUrl}";

            txtEmail.Text = "admin@doce.com";
            txtSenha.Text = "Admin@123";
        }

        private void txtEmail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtSenha.Focus();
            }
        }

        private void txtSenha_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) btnEntrar_Click(sender, e);
        }

        private void SetCarregando(bool carregando)
        {
            btnEntrar.Enabled = !carregando;
            txtEmail.Enabled = !carregando;
            txtSenha.Enabled = !carregando;
            lblAutenticando.Visible = carregando;

            if (carregando)
            {
                btnEntrar.Text = "Aguarde...";
                lblErro.Visible = false;
            }
            else
            {
                btnEntrar.Text = "Entrar";
            }

        }

      
    }
}