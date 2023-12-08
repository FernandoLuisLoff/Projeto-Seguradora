using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace appSeguradora
{
    public partial class FrmApolice : Form
    {
        public FrmApolice()
        {
            InitializeComponent();
        }

        private void FrmDadosVeiculo_Load(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'seguradoraDataSet.Modelos'. Você pode movê-la ou removê-la conforme necessário.
            this.modelosTableAdapter.Fill(this.seguradoraDataSet.Modelos);
            // TODO: esta linha de código carrega dados na tabela 'seguradoraDataSet.Apolices'. Você pode movê-la ou removê-la conforme necessário.
            this.apolicesTableAdapter.Fill(this.seguradoraDataSet.Apolices);
            // TODO: esta linha de código carrega dados na tabela 'seguradoraDataSet.Marcas'. Você pode movê-la ou removê-la conforme necessário.
            this.marcasTableAdapter.Fill(this.seguradoraDataSet.Marcas);
            tabControl1.Dock = DockStyle.Fill;
        }

        private void marcasBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.marcasBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.seguradoraDataSet);

        }

        private void btnProximo1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(1);
        }

        private void btnProximo2_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(2);
        }

        private void btnProximo3_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(3);
        }

        private void btnVoltar1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(0);
        }

        private void btnVoltar2_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(1);
        }

        private void btnVoltar3_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(2);
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            FrmPrincipal frmPrincipal = new FrmPrincipal();
            frmPrincipal.Show();
            this.Close();
        }

        private void btnContratar_Click(object sender, EventArgs e)
        {

        }

        private void marcasBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            var row = ((DataRowView)marcasBindingSource.Current).Row as seguradoraDataSet.MarcasRow;
            modelosBindingSource.Filter = "MarcaID = " + row.Id;
        }

        private void tabPage4_Enter(object sender, EventArgs e)
        {
            if (validaTab1() && validaTab2())
            {
                double valorCarro = double.Parse(valorDoBemTextBox.Text);

                // Cauculo valor apolice
                double valorApolice = valorCarro + (valorCarro * 0.1);

                // Cauculo valor premio
                double valorInicialPremio = valorApolice * 0.015;

                double valorPremio = 0;

                if (rouboCheckBox.Checked) // Roubo
                {
                    valorPremio = valorInicialPremio + (valorInicialPremio * 0.12);
                }

                if (vidrosCheckBox.Checked) // Vidros
                {
                    valorPremio = valorPremio + (valorInicialPremio * 0.02);
                }

                if (acidentesCheckBox.Checked) // Acidentes
                {
                    valorPremio = valorPremio + (valorInicialPremio * 0.04);
                }

                if (danosTerceirosCheckBox.Checked) // Danos contra terceiros
                {
                    valorPremio = valorPremio + (valorInicialPremio * 0.05);
                }

                if (franquiaRedCheckBox.Checked) // Franquia reduzida
                {
                    valorPremio = valorPremio + (valorInicialPremio * 0.03);
                }

                int experienciaMotorista = 5;

                if (experienciaMotorista > 2 && experienciaMotorista <= 5)
                {
                    valorPremio = valorPremio - (valorPremio * 0.03);
                }

                if (experienciaMotorista > 5 && experienciaMotorista <= 10)
                {
                    valorPremio = valorPremio - (valorPremio * 0.05);
                }

                if (experienciaMotorista > 10 && experienciaMotorista <= 20)
                {
                    valorPremio = valorPremio - (valorPremio * 0.06);
                }

                if (experienciaMotorista > 20)
                {
                    valorPremio = valorPremio - (valorPremio * 0.01);
                }

                // Cauculo da Franquia
                double valorFranquia = valorCarro * 0.06;

                if (franquiaRedCheckBox.Checked)
                {
                    valorFranquia = valorFranquia / 2;
                }

                // Seta os valores nos campos
                lbValApolice.Text = string.Format("{0:F2}", valorApolice);
                lbValPremio.Text = string.Format("{0:F2}", valorPremio);
                lbValFranquia.Text = string.Format("{0:F2}", valorFranquia);
            }
        }

        private bool validaTab1()
        {
            if (marcaComboBox.Items.Count == 0)
            {
                MessageBox.Show("Por favor, selecione uma marca antes de avançar.");
                tabControl1.SelectTab(0);
                return false;
            }
            else if (modeloComboBox1.Items.Count == 0)
            {
                MessageBox.Show("Por favor, selecione um modelo antes de avançar.");
                tabControl1.SelectTab(0);
                return false;
            }
            else if (string.IsNullOrWhiteSpace(anoFabricacaoTextBox.Text))
            {
                MessageBox.Show("Por favor, preencha o campo ano de fabricação antes de avançar.");
                tabControl1.SelectTab(0);
                return false;
            }
            else if (string.IsNullOrWhiteSpace(anoModeloTextBox.Text))
            {
                MessageBox.Show("Por favor, preencha o campo ano do modelo antes de avançar.");
                tabControl1.SelectTab(0);
                return false;
            }
            else if (string.IsNullOrWhiteSpace(valorDoBemTextBox.Text))
            {
                MessageBox.Show("Por favor, preencha o campo valor do carro antes de avançar.");
                tabControl1.SelectTab(0);
                return false;
            }
            else
            {

                return true;
            }
        }

        private bool validaTab2()
        {
            if (string.IsNullOrWhiteSpace(chassiTextBox.Text))
            {
                MessageBox.Show("Por favor, preencha o campo chassi antes de avançar.");
                tabControl1.SelectTab(1);
                return false;
            }
            else if (string.IsNullOrWhiteSpace(placaTextBox.Text))
            {
                MessageBox.Show("Por favor, preencha o campo placa antes de avançar.");
                tabControl1.SelectTab(1);
                return false;
            }
            else if (string.IsNullOrWhiteSpace(combustivelTextBox.Text))
            {
                MessageBox.Show("Por favor, preencha o campo combustível antes de avançar.");
                tabControl1.SelectTab(1);
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
