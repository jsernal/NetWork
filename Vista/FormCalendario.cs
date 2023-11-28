﻿using NetWork.Modelo;
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

                
                if (habitaciones.Any())
                {
                    dataGridView1.Rows.Clear();
                    int habitacionesLibres = 0;
                    int totalHabitaciones = habitaciones.Count;

                    foreach (var habitacion in habitaciones)
                    {
                        bool estaDisponible = true; 

                        
                        foreach (var reserva in res)
                        {
                            if (reserva.NumHabitacion == habitacion.NumHabitacion && (reserva.FechaEntrada.Date.Year == fechaSeleccionada.Year &&
                                reserva.FechaEntrada.Date.Month == fechaSeleccionada.Month && reserva.FechaEntrada.Date.Day == fechaSeleccionada.Day))
                            {
                                estaDisponible = false;
                                habitacion.Estado = "Ocupado";
                               
                                break; 
                            }
                        }
                        if (estaDisponible)
                        {
                            habitacion.Estado = "Libre";
                            habitacionesLibres++;
                            dataGridView1.Rows.Add(habitacion.NumHabitacion, habitacion.Estado, habitacion.Tipo.Descripcion, habitacion.Tipo.PrecioBase);
                            // Console.WriteLine($"Habitación: {habitacion.NumHabitacion}, está disponible para la fecha {fechaSeleccionada}");
                        }
                    }

                    // Calcular el porcentaje de habitaciones libres
                    double porcentajeHabitacionesLibres = (habitacionesLibres * 100.0) / totalHabitaciones;

                    // Ajustar precios según el porcentaje de habitaciones libres
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (row.Cells[1].Value != null && row.Cells[1].Value.ToString() == "Libre")
                        {
                            double precioBase = Convert.ToDouble(row.Cells[3].Value);

                            if (porcentajeHabitacionesLibres > 75)
                            {
                                // Más del 75% de habitaciones libres
                                row.Cells[3].Value = (precioBase * 0.50).ToString();
                            }
                            else if (porcentajeHabitacionesLibres < 25)
                            {
                                // Menos del 25% de habitaciones libres
                                row.Cells[3].Value = (precioBase * 1.50).ToString();
                            }
                            // En otro caso, entre 25% y 75%, el precio se mantiene igual
                        }
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MenuPrincipal registroForm = new MenuPrincipal(EmailUsuario.Text);

            registroForm.Show();

            this.Close();
        }

        private void dateTimePicker1_ValueChanged_1(object sender, EventArgs e)
        {
            ActualizarDatos(dateTimePicker1.Value);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Por favor, ingrese un número de habitación.");
                textBox1.Clear();
                return;
            }

            bool habitacionEncontrada = false;
            int numeroHabitacion;

            if (!int.TryParse(textBox1.Text, out numeroHabitacion))
            {
                MessageBox.Show("Ingrese un número válido para la habitación.");
                textBox1.Clear();
                return;
            }

            
            DateTime fechaActual = DateTime.Now;

            if (dateTimePicker1.Value.Date < fechaActual.Date)
            {
                MessageBox.Show("La fecha de reserva debe ser igual o posterior a la fecha actual.");
                return;
            }

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[0].Value != null && Convert.ToInt32(row.Cells[0].Value) == numeroHabitacion)
                {
                    habitacionEncontrada = true;

                    
                    string numHabitacion = row.Cells[0].Value.ToString();
                    string estado = row.Cells[1].Value.ToString();
                    string descripcion = row.Cells[2].Value.ToString();
                    string precio = row.Cells[3].Value.ToString();

                    
                    FormReserva formReserva = new FormReserva(EmailUsuario.Text, numHabitacion,descripcion, precio,dateTimePicker1.Value.Date);
                    formReserva.Show();
                    this.Close();
                    break;
                }
            }

            if (!habitacionEncontrada)
            {
                MessageBox.Show("El número de habitación ingresado no coincide con ninguna habitación mostrada.");
                textBox1.Clear();
            }
        }

        private void FormCalendario_Load_1(object sender, EventArgs e)
        {

        }
    }
   
}
