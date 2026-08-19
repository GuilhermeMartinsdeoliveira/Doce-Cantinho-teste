namespace DoceCantinho.Desktop.UserControls
{
    partial class DoceUserControl
    {
        /// <summary> 
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Designer de Componentes

        /// <summary> 
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            guna2AnimateWindow2 = new Guna.UI2.WinForms.Guna2AnimateWindow(components);
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            guna2AnimateWindow1 = new Guna.UI2.WinForms.Guna2AnimateWindow(components);
            guna2AnimateWindow3 = new Guna.UI2.WinForms.Guna2AnimateWindow(components);
            txtPesquisa = new Guna.UI2.WinForms.Guna2TextBox();
            lblUser = new Label();
            lblGestao = new Label();
            btnEditar = new Guna.UI2.WinForms.Guna2Button();
            btnExcluir = new Guna.UI2.WinForms.Guna2Button();
            btnNovo = new Guna.UI2.WinForms.Guna2Button();
            btnAtualizar = new Guna.UI2.WinForms.Guna2Button();
            btnPesquisar = new Guna.UI2.WinForms.Guna2Button();
            lblTitulo = new Label();
            guna2AnimateWindow4 = new Guna.UI2.WinForms.Guna2AnimateWindow(components);
            gridBanco = new DataGridView();
            colID = new DataGridViewTextBoxColumn();
            colTitle = new DataGridViewTextBoxColumn();
            colCategoryId = new DataGridViewTextBoxColumn();
            colIsFeatured = new DataGridViewCheckBoxColumn();
            colPreco = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)gridBanco).BeginInit();
            SuspendLayout();
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(626, -64);
            label3.Name = "label3";
            label3.Size = new Size(98, 15);
            label3.TabIndex = 16;
            label3.Text = "👤 Administrador";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(35, -29);
            label2.Name = "label2";
            label2.Size = new Size(113, 15);
            label2.TabIndex = 15;
            label2.Text = "Gestão de produtos:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(25, -64);
            label1.Name = "label1";
            label1.Size = new Size(162, 21);
            label1.TabIndex = 9;
            label1.Text = " 🍰 DOCEGOURMET";
            // 
            // txtPesquisa
            // 
            txtPesquisa.BorderRadius = 5;
            txtPesquisa.CustomizableEdges = customizableEdges1;
            txtPesquisa.DefaultText = "🔍 Pesquisar por nome...    ";
            txtPesquisa.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtPesquisa.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtPesquisa.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtPesquisa.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtPesquisa.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtPesquisa.Font = new Font("Segoe UI", 9F);
            txtPesquisa.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtPesquisa.Location = new Point(17, 91);
            txtPesquisa.Name = "txtPesquisa";
            txtPesquisa.PlaceholderText = "";
            txtPesquisa.SelectedText = "";
            txtPesquisa.SelectionStart = 28;
            txtPesquisa.ShadowDecoration.CustomizableEdges = customizableEdges2;
            txtPesquisa.Size = new Size(209, 36);
            txtPesquisa.TabIndex = 26;
            txtPesquisa.TextChanged += txtPesquisa_TextChanged;
            // 
            // lblUser
            // 
            lblUser.AutoSize = true;
            lblUser.Location = new Point(618, 5);
            lblUser.Name = "lblUser";
            lblUser.Size = new Size(98, 15);
            lblUser.TabIndex = 25;
            lblUser.Text = "👤 Administrador";
            // 
            // lblGestao
            // 
            lblGestao.AutoSize = true;
            lblGestao.Location = new Point(27, 40);
            lblGestao.Name = "lblGestao";
            lblGestao.Size = new Size(113, 15);
            lblGestao.TabIndex = 24;
            lblGestao.Text = "Gestão de produtos:";
            // 
            // btnEditar
            // 
            btnEditar.BorderRadius = 10;
            btnEditar.CustomizableEdges = customizableEdges3;
            btnEditar.DisabledState.BorderColor = Color.DarkGray;
            btnEditar.DisabledState.CustomBorderColor = Color.DarkGray;
            btnEditar.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnEditar.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnEditar.FillColor = Color.Blue;
            btnEditar.Font = new Font("Segoe UI", 9F);
            btnEditar.ForeColor = Color.White;
            btnEditar.Location = new Point(192, 160);
            btnEditar.Name = "btnEditar";
            btnEditar.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnEditar.Size = new Size(161, 45);
            btnEditar.TabIndex = 23;
            btnEditar.Text = " ✏ Editar ";
            btnEditar.Click += btnEditar_Click;
            // 
            // btnExcluir
            // 
            btnExcluir.BorderRadius = 10;
            btnExcluir.CustomizableEdges = customizableEdges5;
            btnExcluir.DisabledState.BorderColor = Color.DarkGray;
            btnExcluir.DisabledState.CustomBorderColor = Color.DarkGray;
            btnExcluir.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnExcluir.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnExcluir.FillColor = Color.FromArgb(192, 0, 0);
            btnExcluir.Font = new Font("Segoe UI", 9F);
            btnExcluir.ForeColor = Color.White;
            btnExcluir.Location = new Point(371, 160);
            btnExcluir.Name = "btnExcluir";
            btnExcluir.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnExcluir.Size = new Size(159, 45);
            btnExcluir.TabIndex = 21;
            btnExcluir.Text = "🗑 Excluir";
            btnExcluir.Click += btnExcluir_Click;
            // 
            // btnNovo
            // 
            btnNovo.BorderRadius = 10;
            btnNovo.CustomizableEdges = customizableEdges7;
            btnNovo.DisabledState.BorderColor = Color.DarkGray;
            btnNovo.DisabledState.CustomBorderColor = Color.DarkGray;
            btnNovo.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnNovo.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnNovo.FillColor = Color.ForestGreen;
            btnNovo.Font = new Font("Segoe UI", 9F);
            btnNovo.ForeColor = Color.White;
            btnNovo.Location = new Point(6, 160);
            btnNovo.Name = "btnNovo";
            btnNovo.ShadowDecoration.CustomizableEdges = customizableEdges8;
            btnNovo.Size = new Size(180, 45);
            btnNovo.TabIndex = 22;
            btnNovo.Text = "+ Novo Doce";
            btnNovo.Click += btnNovo_Click;
            // 
            // btnAtualizar
            // 
            btnAtualizar.BorderRadius = 10;
            btnAtualizar.CustomizableEdges = customizableEdges9;
            btnAtualizar.DisabledState.BorderColor = Color.DarkGray;
            btnAtualizar.DisabledState.CustomBorderColor = Color.DarkGray;
            btnAtualizar.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnAtualizar.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnAtualizar.FillColor = Color.Olive;
            btnAtualizar.Font = new Font("Segoe UI", 9F);
            btnAtualizar.ForeColor = Color.White;
            btnAtualizar.Location = new Point(536, 160);
            btnAtualizar.Name = "btnAtualizar";
            btnAtualizar.ShadowDecoration.CustomizableEdges = customizableEdges10;
            btnAtualizar.Size = new Size(180, 45);
            btnAtualizar.TabIndex = 19;
            btnAtualizar.Text = "🔄 Atualizar";
            btnAtualizar.Click += btnAtualizar_Click;
            // 
            // btnPesquisar
            // 
            btnPesquisar.BorderRadius = 10;
            btnPesquisar.CustomizableEdges = customizableEdges11;
            btnPesquisar.DisabledState.BorderColor = Color.DarkGray;
            btnPesquisar.DisabledState.CustomBorderColor = Color.DarkGray;
            btnPesquisar.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnPesquisar.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnPesquisar.FillColor = Color.RoyalBlue;
            btnPesquisar.Font = new Font("Segoe UI", 9F);
            btnPesquisar.ForeColor = Color.White;
            btnPesquisar.Location = new Point(573, 91);
            btnPesquisar.Name = "btnPesquisar";
            btnPesquisar.ShadowDecoration.CustomizableEdges = customizableEdges12;
            btnPesquisar.Size = new Size(143, 36);
            btnPesquisar.TabIndex = 20;
            btnPesquisar.Text = "Pesquisar";
            btnPesquisar.Click += btnPesquisar_Click;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.Location = new Point(17, 5);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(162, 21);
            lblTitulo.TabIndex = 18;
            lblTitulo.Text = " 🍰 DOCEGOURMET";
            // 
            // gridBanco
            // 
            gridBanco.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridBanco.Columns.AddRange(new DataGridViewColumn[] { colID, colTitle, colCategoryId, colIsFeatured, colPreco });
            gridBanco.Location = new Point(3, 231);
            gridBanco.Name = "gridBanco";
            gridBanco.Size = new Size(713, 361);
            gridBanco.TabIndex = 17;
            // 
            // colID
            // 
            colID.FillWeight = 600F;
            colID.HeaderText = "ID";
            colID.Name = "colID";
            colID.Width = 50;
            // 
            // colTitle
            // 
            colTitle.FillWeight = 500F;
            colTitle.HeaderText = "Título";
            colTitle.Name = "colTitle";
            colTitle.Width = 225;
            // 
            // colCategoryId
            // 
            colCategoryId.FillWeight = 200F;
            colCategoryId.HeaderText = "Categoria";
            colCategoryId.Name = "colCategoryId";
            colCategoryId.Width = 200;
            // 
            // colIsFeatured
            // 
            colIsFeatured.FillWeight = 500F;
            colIsFeatured.HeaderText = "Destaque";
            colIsFeatured.Name = "colIsFeatured";
            // 
            // colPreco
            // 
            colPreco.HeaderText = "Data";
            colPreco.Name = "colPreco";
            // 
            // DoceUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(txtPesquisa);
            Controls.Add(lblUser);
            Controls.Add(lblGestao);
            Controls.Add(btnEditar);
            Controls.Add(btnExcluir);
            Controls.Add(btnNovo);
            Controls.Add(btnAtualizar);
            Controls.Add(btnPesquisar);
            Controls.Add(lblTitulo);
            Controls.Add(gridBanco);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "DoceUserControl";
            Size = new Size(718, 597);
            Load += DoceUserControl_Load;
            ((System.ComponentModel.ISupportInitialize)gridBanco).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2AnimateWindow guna2AnimateWindow2;
        private Label label3;
        private Label label2;
        private Label label1;
        private Guna.UI2.WinForms.Guna2AnimateWindow guna2AnimateWindow1;
        private Guna.UI2.WinForms.Guna2AnimateWindow guna2AnimateWindow3;
        private Guna.UI2.WinForms.Guna2TextBox txtPesquisa;
        private Label lblUser;
        private Label lblGestao;
        private Guna.UI2.WinForms.Guna2Button btnEditar;
        private Guna.UI2.WinForms.Guna2Button btnExcluir;
        private Guna.UI2.WinForms.Guna2Button btnNovo;
        private Guna.UI2.WinForms.Guna2Button btnAtualizar;
        private Guna.UI2.WinForms.Guna2Button btnPesquisar;
        private Label lblTitulo;
        private Guna.UI2.WinForms.Guna2AnimateWindow guna2AnimateWindow4;
        private DataGridView gridBanco;
        private DataGridViewTextBoxColumn colID;
        private DataGridViewTextBoxColumn colTitle;
        private DataGridViewTextBoxColumn colCategoryId;
        private DataGridViewCheckBoxColumn colIsFeatured;
        private DataGridViewTextBoxColumn colPreco;
    }
}
