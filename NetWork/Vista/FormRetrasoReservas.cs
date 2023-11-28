using NetWork.Controlador;
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
    public partial class FormRetrasoReservas : Form
    {
        public FormRetrasoReservas()
        {
            InitializeComponent();
            
        }
        private List<Reservas> reservasRetrasadas;

        public FormRetrasoReservas(List<Reservas> reservasRetrasadas)
        {
            InitializeComponent();
            this.reservasRetrasadas = reservasRetrasadas;
        }

        private void FormRetrasoReservas_Load(object sender, EventArgs e)
        {

        }

        private void dGWRetraso_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void btnVerRes_Click(object sender, EventArgs e)
        {
            try
            {
                var controlador = new RecepcionistaControlador();

                // Llama al controlador para obtener las reservas con clientes
                var reservasConClientes = controlador.VerificarReservas();

                if (reservasConClientes.Any())
                {
                    dGWRetraso.AutoGenerateColumns = false;
                    dGWRetraso.DataSource = reservasConClientes;
                }
                else
                {
                    MessageBox.Show("No hay reservas retrasadas.", "Información");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al realizar la consulta");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
