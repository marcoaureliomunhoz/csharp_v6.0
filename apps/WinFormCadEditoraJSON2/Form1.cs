using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace WinFormCadEditoraJSON2
{
    public partial class Form1 : Form
    {
        string editoras_json =
            "[" +
            "{ \"Codigo\" : \"1\", \"Nome\" : \"novatec\" }, " +
            "{ \"Codigo\" : \"2\", \"Nome\" : \"Brasport\" }, " +
            "{ \"Codigo\" : \"3\", \"Nome\" : \"Alta Books\" }, " +
            "{ \"Codigo\" : \"4\", \"Nome\" : \"Digerati Books\" }, " +
            "{ \"Codigo\" : \"5\", \"Nome\" : \"Bookman\" } " +
            "]";
        List<Editora> editoras;

        public Form1()
        {
            InitializeComponent();
        }

        private void CarregarEditoras()
        {
            int indexAtual = gridEditoras.CurrentRow != null ? gridEditoras.CurrentRow.Index : 0;

            gridEditoras.DataSource = null;

            editoras = JsonConvert.DeserializeObject<List<Editora>>(editoras_json);

            gridEditoras.DataSource = editoras;
            gridEditoras.ClearSelection();
            if (indexAtual > gridEditoras.RowCount - 1)
            {
                indexAtual--;
            }
            gridEditoras.Rows[indexAtual].Selected = true;
        }

        private void GravarEditoras()
        {
            editoras_json = JsonConvert.SerializeObject(editoras);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            gridEditoras.AutoGenerateColumns = false;
            CarregarEditoras();
        }

        private void btnNova_Click(object sender, EventArgs e)
        {
            panelCadastro.Enabled = true;
            txtCodigo.Text = "0";
            txtNome.Text = "";
            btnSalvar.Enabled = true;
            txtNome.Focus();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (txtNome.Text.Length > 0)
            {
                int codigo = 0;
                if (Int32.TryParse(txtCodigo.Text, out codigo))
                {
                    if (codigo > 0)
                    {
                        var editora = editoras.FirstOrDefault(x => x.Codigo == codigo);
                        if (editora != null)
                        {
                            editora.Nome = txtNome.Text;
                        }
                    }
                    else
                    {
                        var editora = new Editora
                        {
                            Codigo = editoras.Max(x => x.Codigo) + 1,
                            Nome = txtNome.Text
                        };
                        editoras.Add(editora);
                    }
                    GravarEditoras();
                    CarregarEditoras();

                    txtCodigo.Text = "";
                    txtNome.Text = "";
                    panelCadastro.Enabled = false;
                    btnSalvar.Enabled = false;
                }
            }
        }

        private void btnRecarregar_Click(object sender, EventArgs e)
        {
            CarregarEditoras();
        }

        private void gridEditoras_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (gridEditoras.CurrentRow.Index >= 0 && editoras.Count > 0)
                {
                    if (MessageBox.Show("Confirma a exclusão?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        editoras.RemoveAt(gridEditoras.CurrentRow.Index);
                        GravarEditoras();
                        CarregarEditoras();
                    }
                }
            }
        }

        private void gridEditoras_DoubleClick(object sender, EventArgs e)
        {
            if (gridEditoras.CurrentRow.Index >= 0 && editoras.Count > 0)
            {
                var editora = editoras[gridEditoras.CurrentRow.Index];
                txtCodigo.Text = editora.Codigo.ToString();
                txtNome.Text = editora.Nome;
                panelCadastro.Enabled = true;
                btnSalvar.Enabled = true;
                txtNome.Focus();
            }
        }
    }
}
