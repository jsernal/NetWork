using NetWork.Controlador;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static NetWork.Controlador.RecepcionistaControlador;

namespace NetWork.Vista
{
    public partial class FormHistorialClientes : Form
    {
        private RecepcionistaControlador recepcionistaControlador;
        public FormHistorialClientes()
        {
            InitializeComponent();
            this.btnCliente.Click += new System.EventHandler(this.btnCliente_Click);
            recepcionistaControlador = new RecepcionistaControlador();
            this.dtgCliente.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgCliente_CellClick);
        }
        private void dtgCliente_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (e.RowIndex >= 0)
            {
                int numHabitacion = Convert.ToInt32(dtgCliente.Rows[e.RowIndex].Cells["NumHabitacion"].Value);

                
                DateTime nuevaFechaEntrada = dtpFecha1.Value;
                DateTime nuevaFechaSalida = dtpFecha2.Value;

                bool estaDisponible = RecepcionistaControlador.VerificarDisponibilidad(numHabitacion, nuevaFechaEntrada, nuevaFechaSalida);

                if (estaDisponible)
                {
                    MessageBox.Show("La habitación está disponible para las nuevas fechas seleccionadas.");
                }
                else
                {
                    MessageBox.Show("La habitación no está disponible para las nuevas fechas seleccionadas.");
                }
            }
        }

        private void dtgCliente_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void btnCliente_Click(object sender, EventArgs e)
        {
            try
            {
                var controlador = new RecepcionistaControlador();

                int idCliente = Convert.ToInt32(txtbCliente.Text);
                // Llama al controlador para obtener las reservas con clientes
                var historialClientes = controlador.ConsultarHistorial(idCliente);

                // Recorre las reservas y accede al nombre del cliente


                dtgCliente.AutoGenerateColumns = false;
                dtgCliente.DataSource = historialClientes;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al realizar la consulta");
            }
        }

        private void txtbCliente_TextChanged(object sender, EventArgs e)
        {

        }

        private void FormHistorialClientes_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
