using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace WinFormCadEditoraXML1
{
    public partial class Form1 : Form
    {
        int maxCodigo = 0;

        string editoras_xml =
            "<editoras>" +
                "<editora id=\"1\">" +
                    "<nome>novatec</nome>" +
                "</editora>" +
                "<editora id=\"2\">" +
                    "<nome>Alta Books</nome>" +
                "</editora>" +
                "<editora id=\"3\">" +
                    "<nome>Excel Books</nome>" +
                "</editora>" +
            "</editoras>";

        XmlDocument doc = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void CarregarEditoras()
        {
            if (doc == null)
            {
                doc = new XmlDocument();
                doc.LoadXml(editoras_xml);
            }

            listBoxEditoras.Items.Clear();
            XmlNodeList xeditoras = doc.SelectNodes("//editora");
            foreach (XmlNode xeditora in xeditoras)
            {
                XmlNode nome = xeditora.SelectSingleNode("descendant::nome");

                var editora = new Editora
                {
                    Codigo = Convert.ToInt32(xeditora.Attributes["id"].InnerText),
                    Nome = nome.InnerText
                };

                if (editora.Codigo > maxCodigo)
                {
                    maxCodigo = editora.Codigo;
                }

                listBoxEditoras.Items.Add(editora);
            }
        }

        private void GravarEditoras()
        {
            editoras_xml = doc.OuterXml;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
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
                        var xeditora = doc.SelectSingleNode($"//editora[@id='{codigo}']");

                        if (xeditora != null)
                        {
                            XmlNode xnome = xeditora.SelectSingleNode("descendant::nome");
                            if (xnome != null)
                            {
                                xnome.InnerText = txtNome.Text;
                            }
                        }
                    }
                    else
                    {
                        maxCodigo++;

                        var xeditora = doc.CreateElement("editora");

                        var xcodigo = doc.CreateAttribute("id");
                        xcodigo.Value = maxCodigo.ToString();

                        var xnome = doc.CreateElement("nome");
                        xnome.InnerText = txtNome.Text;

                        xeditora.Attributes.Append(xcodigo);
                        xeditora.AppendChild(xnome);

                        doc.DocumentElement.AppendChild(xeditora);
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

        private void listBoxEditoras_DoubleClick(object sender, EventArgs e)
        {
            if (listBoxEditoras.SelectedItem != null)
            {
                var editora = listBoxEditoras.SelectedItem as Editora;
                txtCodigo.Text = editora.Codigo.ToString();
                txtNome.Text = editora.Nome;
                panelCadastro.Enabled = true;
                btnSalvar.Enabled = true;
                txtNome.Focus();
            }
        }

        private void listBoxEditoras_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (listBoxEditoras.SelectedItem != null)
                {
                    if (MessageBox.Show("Confirma a exclusão?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        var editora = listBoxEditoras.SelectedItem as Editora;

                        var xeditora = doc.SelectSingleNode($"//editora[@id='{editora.Codigo}']");

                        if (xeditora != null)
                        {
                            doc.DocumentElement.RemoveChild(xeditora);

                            GravarEditoras();
                            CarregarEditoras();
                        }
                    }
                }
            }
        }

        private void btnRecarregar_Click(object sender, EventArgs e)
        {
            CarregarEditoras();
        }
    }
}
