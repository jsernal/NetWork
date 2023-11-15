using NetWork.Modelo;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace NetWork.Vista
{
    public partial class FormModificarReservas : Form
    {
        public FormModificarReservas(string emailUsuario)
        {
            InitializeComponent();
            EmailUsuario.Text = emailUsuario;
            cargarForm();
        }

        ConexionDB db;
        Reservas reserva = new Reservas();


        public List<Reservas> Read()
        {
            try
            {
                using (db = new ConexionDB())
                {
                    return db.Reservas.ToList();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }

        }

        public void Update(Reservas reserva)
        {
            {
                try

                {
                    using (db = new ConexionDB())
                    {
                        db.Entry(reserva).State = EntityState.Modified;
                        db.SaveChanges();
                    }

                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }
        public void Delete(int codigoReserva)
        {
            {
                try

                {
                    using (db = new ConexionDB())
                    {
                        db.Reservas.Remove(db.Reservas.Single(Reservas => Reservas.CodigoReservas == codigoReserva));
                        db.SaveChanges();
                    }

                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }


        private void cargarDatos()
        {  
               
            int idCliente = ObtenerIdClientePorDNI(textBoxNifCliente.Text);

            // Asignar el ID del cliente a la reserva
            reserva.IdCliente = idCliente;
            reserva.CodigoReservas = Convert.ToInt32(textboxCodigoReserva.Text);
            reserva.IdCliente = idCliente; 
            reserva.NumHabitacion = Convert.ToInt32(textBoxNumHab.Text);
            reserva.FechaEntrada = DateTime.Parse(dateTimePickerFechaReserva.Text);

          

            cargarGrid();
        }

        private int ObtenerIdClientePorDNI(string dni)
        {
            using (ConexionDB db = new ConexionDB())
            {
                // Buscar el cliente por el DNI proporcionado
                var cliente = db.Clientes.FirstOrDefault(c => c.Dni == dni);

                // Verificar si se encontró el cliente
                if (cliente != null)
                {
                    // Devolver el ID del cliente
                    return cliente.IdCliente;
                }

                // Si no se encuentra el cliente, puedes manejarlo de acuerdo a tus necesidades
                // Por ejemplo, lanzar una excepción, devolver un valor predeterminado, etc.
                throw new Exception("Cliente no encontrado");
            }
        }

        private void cargarGrid()
        {
            var Lst = Read();
            dataGridView1.DataSource = Lst;
        }

        private void cargarForm()
        {
            cargarGrid();
        }
        private void limpiarDatos()
        {
            textboxCodigoReserva.Focus();
            textboxCodigoReserva.Text = string.Empty;
            textBoxNifCliente.Text = string.Empty;
            dateTimePickerFechaReserva.Text = string.Empty;
            textBoxNumHab.Text = string.Empty;
            cargarGrid();

        }



        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            {

                cargarDatos();
                Delete(reserva.CodigoReservas);
                limpiarDatos();
            }
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            {
                textboxCodigoReserva.Text = dataGridView1.CurrentRow.Cells["CodigoReservas"].Value.ToString();

                textBoxNifCliente.Text = dataGridView1.CurrentRow.Cells["DniCliente"].Value.ToString();

                textBoxNumHab.Text = dataGridView1.CurrentRow.Cells["NumHabitacion"].Value.ToString();

                dateTimePickerFechaReserva.Text = dataGridView1.CurrentRow.Cells["Fecha"].Value.ToString();

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MenuPrincipal registroForm = new MenuPrincipal(EmailUsuario.Text);

            registroForm.Show();

            this.Close();
        }

        private void btnGuardarCambios_Click(object sender, EventArgs e)
        {
            DateTime fechaActual = DateTime.Now;
            if (textboxCodigoReserva.Text != string.Empty)
            {
                cargarDatos();
                int contador = 0;
                foreach (DataGridViewRow r in dataGridView1.Rows)
                {
                    if (r.Cells[1].Value.ToString() == Convert.ToString(reserva.FechaEntrada) && r.Cells[3].Value.ToString() == Convert.ToString(reserva.NumHabitacion))
                    {
                        contador++;
                    }
                }

                if (contador == 0 && dateTimePickerFechaReserva.Value >= fechaActual.Date)
                    {
                        Update(reserva);
                    }
                else
                    {
                        MessageBox.Show("Habitación no disponible, seleccione otra fecha");

                    }
             }
             cargarGrid();
             limpiarDatos();
         }


    }

}