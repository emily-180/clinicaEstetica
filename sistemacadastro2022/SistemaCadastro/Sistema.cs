using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace SistemaCadastro
{
    public partial class Sistema : Form
    {
        int idAlterar; // variavel global

        public Sistema()
        {
            InitializeComponent();
            
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnCadastra_Click(object sender, EventArgs e)
        {
            marcador.Height = btnCadastra.Height;
            marcador.Top = btnCadastra.Top;
            tabControl1.SelectedTab = tabControl1.TabPages[0];
        }
        

        private void btnBusca_Click(object sender, EventArgs e)
        {
            marcador.Height = btnBusca.Height;
            marcador.Top = btnBusca.Top;
            tabControl1.SelectedTab = tabControl1.TabPages[1];
        }

        void listaProcedimento()
        {
            ConectaBanco con = new ConectaBanco();
            DataTable tabelaDados = new DataTable();
            tabelaDados = con.listaProcedimentos();
            cbProcedimento.DataSource = tabelaDados;
            cbProcedimento.DisplayMember = "nomeProcedimento";
            cbProcedimento.ValueMember = "codProcedimento";
            // preenchendo cbAlteraGenero
            cbAlteraProcedimento.DataSource = tabelaDados;
            cbAlteraProcedimento.DisplayMember = "nomèProcedimento";
            cbAlteraProcedimento.ValueMember = "codProcedimento";
            //
            lblmsgerro.Text = con.mensagem;
            cbProcedimento.Text = "";
            cbAlteraProcedimento.Text = "";
        }
        void listaConsulta()
        {
            ConectaBanco con = new ConectaBanco();
            dgConsultas.DataSource = con.listaConsultas();
        }
        void limpaCampos()
        {
            txtcliente.Text = "";
            cbProcedimento.Text = "";
            txtcpf.Text = "";
            txttelefone.Text = "";
            txthora.Text = "";
            txtdataD.Text = "";
            cbProcedimento.Text = "";
            txtcliente.Focus();
        }

        private void Sistema_Load(object sender, EventArgs e)
        {
            listaProcedimento();
            listaConsulta();
        }


        private void BtnConfirmaCadastro_Click_1(object sender, EventArgs e)
        {
            Consulta c = new Consulta();
            c.Cliente = txtcliente.Text;
            c.Cpf = txtcpf.Text;
            c.Telefone = txttelefone.Text;
            c.Hora = txthora.Text;
            c.DataD = txtdataD.Text;
            c.Proce =Convert.ToInt32(cbProcedimento.SelectedValue.ToString());
            // enviar para o banco
            ConectaBanco conecta = new ConectaBanco();
            bool retorno = conecta.insereConsulta(c);
            if (retorno == true)
            {
                MessageBox.Show("Dados inseridos com sucesso!");
            }
            else
                lblmsgerro.Text = conecta.mensagem;

            listaConsulta();
            limpaCampos();
        }//  fim confima insere banda

        private void txtBusca_TextChanged(object sender, EventArgs e)
        {
            (dgConsultas.DataSource as DataTable).
                 DefaultView.RowFilter =
                  String.Format("nome like'{0}%'",txtBusca.Text);
        }

        private void btnRemoveBanda_Click(object sender, EventArgs e)
        {
            
        }


        private void btnAlterar_Click(object sender, EventArgs e)
        {
           
        }

         private void btnConfirmaAlteracao_Click(object sender, EventArgs e)
        {

        }

        private void bntAddGenero_Click(object sender, EventArgs e)
        {
             FrmAddGenero frmAddGenero = new FrmAddGenero();
             this.Hide();
             frmAddGenero.ShowDialog();
            this.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
