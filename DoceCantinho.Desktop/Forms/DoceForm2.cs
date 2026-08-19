using DoceCantinho.Desktop.Helpers;
using DoceCantinho.Desktop.Services;
using DoceCantinho.Desktop.UserControls;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoceCantinho.Desktop.Forms
{
    public partial class DoceForm2 : Form
    {
        private UserControl? _controleAtual;
        private Panel pnlConteudo;
        private AuthApiService _authService = null;
        public DoceForm2()
        {
            InitializeComponent();
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            //Guard: não executa em tempo de design
            if (DesignMode) return;

            //Instancia o serviço
            _authService = new AuthApiService();

            // Configura permissões baseadas no perfil do usuário
            ConfigurarPermissoes();

          CarregarTela(new DoceUserControl());
        }

        private void ConfigurarPermissoes()
        {
            var isAdmin = SessionManager.Instance.IsAdmin;
        }



        private void NavegarParaDashboard()
        {
            Navegar(new DoceUserControl());
        }

        private void InitializeComponent()
        {
            pnlConteudo = new Panel();
            SuspendLayout();
            // 
            // pnlConteudo
            // 
            pnlConteudo.Location = new Point(12, 62);
            pnlConteudo.Name = "pnlConteudo";
            pnlConteudo.Size = new Size(687, 418);
            pnlConteudo.TabIndex = 0;
            // 
            // DoceForm2
            // 
            ClientSize = new Size(791, 574);
            Controls.Add(pnlConteudo);
            Name = "DoceForm2";
            ResumeLayout(false);

        }

        private void Navegar(UserControl control)
        {
            //Remove o UserControl anterior
            if (_controleAtual != null)
            {
                pnlConteudo.Controls.Remove(_controleAtual);
                _controleAtual.Dispose();
                _controleAtual = null;
            }

            //Adiona o novo UserControl(Tela interna)
            control.Dock = DockStyle.Fill;
            pnlConteudo.Controls.Add(control);
            _controleAtual = control;
        }

        public void CarregarTela(UserControl control)
        {
            
            control.Controls.Clear();
            pnlConteudo.Dock= DockStyle.Fill;
            pnlConteudo.Controls.Add(control);
        }
    }
}
