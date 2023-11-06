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
    public partial class FormReserva : Form
    {
        public FormReserva(string emailUsuario,string numhab, string descripcion, string precio)
        {
            InitializeComponent();
            label13.Text = emailUsuario;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
