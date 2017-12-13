using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModeloPadradoDeEventos1
{
    public partial class Form1 : Form
    {
        MeuBotao meuBotao;

        public Form1()
        {
            InitializeComponent();

            meuBotao = new MeuBotao();
            meuBotao.Left = 20;
            meuBotao.Top = 10;
            meuBotao.Text = "Clique Aqui";
            meuBotao.Width = 100;
            meuBotao.Height = 30;
            meuBotao.AlteracaoCor += btnCliqueAqui_AlteracaoCor;
            this.Controls.Add(meuBotao);
        }

        /* método final */
        private void btnCliqueAqui_AlteracaoCor(object sender, AlteracaoCorEventArgs e)
        {
            richTextBox1.AppendText(e.CorAnterior + " => " + meuBotao.BackColor.ToString() + "\n");
        }
    }
}
