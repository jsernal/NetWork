using NetWork.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetWork.Vista
{
    public partial class FormXML : Form
    {
        public FormXML(List<Clientes> clientes)
        {
            InitializeComponent();
            visualizarXML.DataSource = clientes;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
