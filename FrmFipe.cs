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
    public partial class FrmFipe : Form
    {
        public FrmFipe()
        {
            InitializeComponent();
            cbbBusca.SelectedIndex = 0;
        }

        private void atualizaGRID()
        {
            // TODO: esta linha de código carrega dados na tabela 'seguradoraDataSet.ViewFipe'. Você pode movê-la ou removê-la conforme necessário.
            this.viewFipeTableAdapter.Fill(this.seguradoraDataSet.ViewFipe);
        }

        private void FrmFipe_Load(object sender, EventArgs e)
        {
            atualizaGRID();
        }

        private void btnNovaFipe_Click(object sender, EventArgs e)
        {
            FrmCadastroFipe frmCadastroFipe = new FrmCadastroFipe(null);
            frmCadastroFipe.ShowDialog();
            atualizaGRID();

        }

        private void buscarMarcas()
        {
            String buscaMarca = txtBusca.Text.Trim();

            if (!String.IsNullOrEmpty(buscaMarca))
            {
                viewFipeBindingSource.Filter = "Marca LIKE '%" + buscaMarca + "%'";
            }
            else
            {
                viewFipeBindingSource.Filter = "";
                return;

            }
        }

        private void buscaModelo()
        {
            String buscaModelo = txtBusca.Text.Trim();

            if (!String.IsNullOrEmpty(buscaModelo))
            {
                viewFipeBindingSource.Filter = "Modelo LIKE '%" + buscaModelo + "%'";
            }
            else
            {
                viewFipeBindingSource.Filter = "";
                return;
            }
        }

        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (cbbBusca.Text.Equals("Marcas"))
            {
                buscarMarcas();
            }
            else
            {
                buscaModelo();
            }
        }

        private void viewFipeDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataRowView currentRow = (DataRowView)viewFipeBindingSource.Current;
            FrmCadastroFipe frmCadastroFipe = new FrmCadastroFipe(currentRow.Row["ModeloID"].ToString());
            frmCadastroFipe.ShowDialog();
            atualizaGRID();
        }

        private void txtBusca_Click(object sender, EventArgs e)
        {

        }
    }
}
