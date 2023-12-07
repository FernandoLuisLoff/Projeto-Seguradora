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
    public partial class FrmMarcas : Form
    {
        public FrmMarcas()
        {
            InitializeComponent();
        }

        private void atualizaGRID()
        {
            // TODO: esta linha de código carrega dados na tabela 'seguradoraDataSet.Marcas'. Você pode movê-la ou removê-la conforme necessário.
            this.marcasTableAdapter.Fill(this.seguradoraDataSet.Marcas);
            // TODO: esta linha de código carrega dados na tabela 'seguradoraDataSet.Marcas'. Você pode movê-la ou removê-la conforme necessário.
            this.marcasTableAdapter.Fill(this.seguradoraDataSet.Marcas);
        }

        private void FrmMarcas_Load(object sender, EventArgs e)
        {
           
            atualizaGRID();

        }

        private void buscarMarcas()
        {
            String buscaMarca = txtBuscarMarca.Text.Trim();

            if (!String.IsNullOrEmpty(buscaMarca))
            {
               marcasBindingSource.Filter = "Marca LIKE '%" + buscaMarca + "%'";
            }
            else
            {
                marcasBindingSource.Filter = "";
                return;

            }
        }

        private void marcasDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataRowView currentRow = (DataRowView)marcasBindingSource.Current;
            FrmCadastroMarcas frmCadastroMarcas = new FrmCadastroMarcas(currentRow.Row["Id"].ToString());
            frmCadastroMarcas.ShowDialog();
            atualizaGRID();
        }

        private void marcasBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.marcasBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.seguradoraDataSet);

        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            FrmCadastroMarcas frmCadastroMarcas = new FrmCadastroMarcas(null);
            frmCadastroMarcas.ShowDialog();
            atualizaGRID();
        }

        private void btnBuscar_Click_1(object sender, EventArgs e)
        {
            if (txtBuscarMarca.Text == "")
            {
                MessageBox.Show("digite um valor para o campo se quiser buscar uma marca");
            }
            else
            {
                buscarMarcas();
            }
        }

        private void txtBuscarMarca_TextChanged_1(object sender, EventArgs e)
        {
            buscarMarcas();
        }
    }
}
