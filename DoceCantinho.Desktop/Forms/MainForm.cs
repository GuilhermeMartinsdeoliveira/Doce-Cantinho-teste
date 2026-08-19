using DoceCantinho.Desktop.UserControls;
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
    public partial class MainForm : Form
    {

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            CarregarTela();
        }
        public void CarregarTela()
        {
            pnlPanel.Controls.Clear();
            pnlPanel.Controls.Add(new DoceUserControl());
        }


    }
}
