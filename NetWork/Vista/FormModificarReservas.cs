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

        //función cargar datos desde forms a variables de reserva
        private void cargarDatos()
        {
            reserva.CodigoReservas = Convert.ToInt32(textboxCodigoReserva.Text);
            reserva.DniCliente = textBoxNifCliente.Text;
            reserva.NumHabitacion = Convert.ToInt32(textBoxNumHab.Text);
            reserva.Fecha = DateTime.Parse(dateTimePickerFechaReserva.Text);
            cargarGrid();
        }

        //ejecutar un read para obtener un listado de datos y visualizar a través de gridview
        private void cargarGrid()
        {
            var Lst = Read();
            dataGridView1.DataSource = Lst;
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
            textBoxNifCliente.Text = string.Empty;
            dateTimePickerFechaReserva.Text = string.Empty;
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

                textBoxNifCliente.Text = dataGridView1.CurrentRow.Cells["DniCliente"].Value.ToString();

                textBoxNumHab.Text = dataGridView1.CurrentRow.Cells["NumHabitacion"].Value.ToString();

                dateTimePickerFechaReserva.Text = dataGridView1.CurrentRow.Cells["Fecha"].Value.ToString();

            }
        }

        //Retornar al main menu
        private void button1_Click(object sender, EventArgs e)
        {
            MenuPrincipal registroForm = new MenuPrincipal(EmailUsuario.Text);

            registroForm.Show();

            this.Close();
        }

        //Guardar cambios
        private void btnGuardarCambios_Click(object sender, EventArgs e)
        {
            DateTime fechaActual = DateTime.Now;
            int contador = 0;

            if (textboxCodigoReserva.Text != string.Empty)
            {
                cargarDatos();
                //para cada fila del gridview
                foreach (DataGridViewRow r in dataGridView1.Rows)
                {
                    //si el valor de fecha y numHab coinciden con la reserva a modificar, sumador
                    if (r.Cells["Fecha"].Value.ToString() == Convert.ToString(reserva.Fecha) && r.Cells["NumHabitacion"].Value.ToString() == Convert.ToString(reserva.NumHabitacion))
                    {
                        contador++;
                    }
                }
                
                //si el contador es 0, no hay coincidencias de fecha y numHab ==> actualiza la reserva
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