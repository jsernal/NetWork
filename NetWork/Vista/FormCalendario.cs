using NetWork.Modelo;
using System;
using System.Linq;
using System.Windows.Forms;

namespace NetWork.Vista
{
    public partial class FormCalendario : Form
    {
        public FormCalendario(string emailUsuario)
        {
            InitializeComponent();
            EmailUsuario.Text = emailUsuario;
            ActualizarDatos(dateTimePicker1.Value);
        }
        private void FormCalendario_Load(object sender, EventArgs e)
        {

        }
        public void ActualizarDatos(DateTime fechaSeleccionada)
        {
            using (ConexionDB db = new ConexionDB())
            {
                var habitaciones = db.Habitaciones.ToList();
                var tipo = db.TipoHabitacion.ToList();
                var res = db.Reservas.ToList();


                // Verificar si la lista de habitaciones no está vacía
                if (habitaciones.Any())
                {
                    dataGridView1.Rows.Clear();

                    foreach (var habitacion in habitaciones)
                    {
                        bool estaDisponible = false; // Establecer como disponible inicialmente

                        // Verificar si alguna reserva coincide con la habitación y la fecha seleccionada
                        foreach (var reserva in res)
                        {
                            if (reserva.NumHabitacion != habitacion.NumHabitacion || (reserva.Fecha.Date.Year == fechaSeleccionada.Year &&
            reserva.Fecha.Date.Month == fechaSeleccionada.Month && reserva.Fecha.Date.Day == fechaSeleccionada.Day))
                            {
                                estaDisponible = true; // La habitación está ocupada para esta fecha
                                Console.WriteLine($"Habitación: {habitacion.NumHabitacion} HabitaciónREs: {reserva.NumHabitacion}  está libre para la fecha {fechaSeleccionada} v fechares {reserva.Fecha}");
                                break; // Salir del bucle si la habitación está ocupada en esta fecha
                            }

                            // Si la habitación está disponible, añadirla al DataGridView
                            
                        }
                        if (estaDisponible)
                        {
                            dataGridView1.Rows.Add(habitacion.NumHabitacion, habitacion.Estado, habitacion.Tipo.Descripcion, habitacion.Tipo.PrecioBase);
                            //Console.WriteLine($"Habitación: {habitacion.NumHabitacion}, HabitacionRes: {reserva.NumHabitacion} está disponible para la fecha {fechaSeleccionada}");
                        }
                    }
                }
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            ActualizarDatos(dateTimePicker1.Value);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MenuPrincipal registroForm = new MenuPrincipal(EmailUsuario.Text);

            registroForm.Show();

            this.Close();
        }


    }
}
