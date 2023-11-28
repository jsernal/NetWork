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

        //nueva conexión a la bbdd
        ConexionDB db;
        Reservas reserva = new Reservas();

        //función de lectura de reserva
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
        //función actualizar reserva
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
        //función borrar reserva
        public void Delete(int codigoReserva)
        {
            {
                try

                {
                    using (db = new ConexionDB())
                    {
                        db.Reservas.Remove(db.Reservas.
                            Single(Reservas => 
                            Reservas.CodigoReservas == codigoReserva));
                        db.SaveChanges();
                    }
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }

        //función cargar datos desde forms a variables de reserva
        private void cargarDatos()
        {
            reserva.CodigoReservas = Convert.ToInt32(textboxCodigoReserva.Text);
            reserva.CodigoTipoAloj = Convert.ToInt32(textBoxTipoAloj.Text);
            reserva.DniCliente = textBoxNifCliente.Text;
            reserva.NumHabitacion = Convert.ToInt32(textBoxNumHab.Text);
            reserva.FechaEntrada = DateTime.Parse(dateTimePickerFechaReserva.Text);
            reserva.FechaSalida = DateTime.Parse(dateTimePickerSalida.Text);

            cargarGrid();
        }

        //ejecutar un read para obtener un listado de datos y visualizar a través de gridview
        private void cargarGrid()
        {
            var Lst = Read();
            dataGridView1.DataSource = Lst;
            dataGridView1.Columns["IdCliente"].Visible = false;
            dataGridView1.Columns["Cliente"].Visible = false;
            dataGridView1.Columns["NombreCliente"].Visible = false;
            dataGridView1.Columns["TelefonoCliente"].Visible = false;
            dataGridView1.Columns["EstadoReserva"].Visible = false;
            dataGridView1.Columns["EstadoReservaTexto"].Visible = false;

        }

        //CargarGrid
        private void cargarForm()
        {
            cargarGrid();
        }

        //Vacíar boxes en el forms
        private void limpiarDatos()
        {
            textboxCodigoReserva.Focus();
            textboxCodigoReserva.Text = string.Empty;
            textBoxTipoAloj.Text = string.Empty;
            textBoxNifCliente.Text = string.Empty;
            dateTimePickerFechaReserva.Text = string.Empty;
            dateTimePickerSalida.Text = string.Empty;
            textBoxNumHab.Text = string.Empty;
            cargarGrid();

        }
        //Eliminar al pulsar botón
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            {

                cargarDatos();
                Delete(reserva.CodigoReservas);
                limpiarDatos();
            }
        }

        //Al clickar sobre las filas y celdas del gridview ==> copiar valor a los correspondientes textbox

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            {
                textboxCodigoReserva.Text = dataGridView1.CurrentRow.Cells["CodigoReservas"].Value.ToString();

                textBoxTipoAloj.Text = dataGridView1.CurrentRow.Cells["CodigoTipoAloj"].Value.ToString();


                textBoxNifCliente.Text = dataGridView1.CurrentRow.Cells["DniCliente"].Value.ToString();

                textBoxNumHab.Text = dataGridView1.CurrentRow.Cells["NumHabitacion"].Value.ToString();


                dateTimePickerFechaReserva.Text = dataGridView1.CurrentRow.Cells["FechaEntrada"].Value.ToString();
                dateTimePickerSalida.Text = dataGridView1.CurrentRow.Cells["FechaSalida"].Value.ToString();

            }
        }

        //Retornar al main menu
        private void button1_Click(object sender, EventArgs e)
        {
            MenuPrincipal registroForm = new MenuPrincipal(EmailUsuario.Text);

            registroForm.Show();

            this.Close();
        }

        private void btnGuardarCambios_Click(object sender, EventArgs e)
        {
            cargarDatos();

            if (!ExisteSolapamiento(reserva))
            {
                Update(reserva);
                cargarGrid();
                limpiarDatos();
            }
            else
            {
                MessageBox.Show("Los datos ingresados no son válidos. " +
                    "Por favor, verifique y corrija los campos.", 
                    "Datos no válidos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /*private bool ExisteSolapamiento(Reservas reserva)
        {
            using (var dbContext = new ConexionDB())
            {
                // Obtener todas las reservas para la misma habitación
                var reservasMismaHabitacion = dbContext.Reservas
                    .Where(r => r.NumHabitacion == reserva.NumHabitacion && r.CodigoReservas != reserva.CodigoReservas)
                    .ToList();

                // Verificar si hay solapamiento con alguna reserva existente
                foreach (var reservaExistente in reservasMismaHabitacion)
                {
                    if (reservaExistente.FechaEntrada < reserva.FechaSalida && reservaExistente.FechaSalida > reserva.FechaEntrada)
                    {
                        MessageBox.Show($"La habitación {reserva.NumHabitacion} ya está reservada en ese período de tiempo.", "Solapamiento de reservas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return true; // Hay solapamiento
                    }
                }
            } // Al usar 'using', el contexto se liberará correctamente al salir de este bloque

            // No hay solapamiento
            return false;
        }*/

        private bool ExisteSolapamiento(Reservas reserva)
        {
            using (var dbContext = new ConexionDB())
            {
                // Verificar si hay solapamiento con alguna reserva existente en la base de datos
                var solapamiento = dbContext.Reservas
                    .Any(r =>
                        r.NumHabitacion == reserva.NumHabitacion &&
                        r.CodigoReservas != reserva.CodigoReservas &&
                        r.FechaEntrada < reserva.FechaSalida &&
                        r.FechaSalida > reserva.FechaEntrada);

                if (solapamiento)
                {
                    MessageBox.Show($"La habitación {reserva.NumHabitacion} " +
                        $"ya está reservada en ese período de tiempo.", "Solapamiento de reservas", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return true; // Hay solapamiento
                }
            }

            // No hay solapamiento
            return false;
        }

    }
}