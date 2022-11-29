using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaCadastro
{
    public partial class FrmAddGenero : Form
    {
        public FrmAddGenero()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Sistema sistema= new Sistema();
            this.Hide();
            sistema.ShowDialog();
            this.Close();
        }

        private void BtnAddGenero_Click(object sender, EventArgs e)
        {
            
        }// fim addGenero
    }
}
