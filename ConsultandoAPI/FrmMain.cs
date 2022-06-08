using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Correios;

namespace ConsultandoAPI
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Sair da aplicação?", "Saindo...", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult)
            Application.Exit();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCEP.Text))
                MessageBox.Show("O campo do CEP esta vazio", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
            {
                try
                {
                    CorreiosApi correiosApi = new CorreiosApi();
                    var retorno = correiosApi.consultaCEP(txtCEP.Text);

                    if (retorno is null)
                    {
                        MessageBox.Show("CEP não encontrado", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }

                    txtUF.Text = retorno.uf;
                    txtCidade.Text = retorno.cidade;
                    txtEnderec.Text = retorno.end;
                    txtComp1.Text = retorno.complemento;
                    txtComp2.Text = retorno.complemento2;
                    txtBairro.Text = retorno.bairro;
                    //txtUndPostagem.Text = retorno.unidadesPostagem.[0];
                }
                catch (Exception erro)
                {
                    MessageBox.Show("Erro ao consultar CEP: " + erro.Message, "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
