﻿using NetWork.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace NetWork.Vista
{
        public partial class FormHabitaciones : Form
        {

            public FormHabitaciones(string emailUsuario)
            {
                InitializeComponent();
            EmailUsuario.Text = emailUsuario;
           // contexto = new ConexionDB(); // Asegúrate de inicializar tu contexto correctamente
            }

            private int ObtenerCodigoTipoHabitacion(string tipoSeleccionado)
            {
                // Mapear el tipo de habitación seleccionado en el ComboBox a su código correspondiente
                switch (tipoSeleccionado)
                {
                    case "Habitación Estándar":
                        return 1;
                    case "Suite de Lujo":
                        return 2;
                    case "Habitación Familiar":
                        return 3;
                    case "Habitación Individual":
                        return 4;
                    case "Habitación Doble":
                        return 5;
                    default:
                        throw new ArgumentException("Tipo de habitación no reconocido");
                }
            }
        
        private void FormHabitaciones_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Form formulario = new MenuPrincipal(EmailUsuario.Text);
            formulario.Show();
            this.Hide();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            ConexionDB contexto = new ConexionDB(); // Asegúrate de tener tu contexto de Entity Framework aquí
            // Verificar si TextBox1 no está vacío y solo contiene números
            if (!string.IsNullOrEmpty(textBox1.Text) && int.TryParse(textBox1.Text, out int numeroHabitacion))
            {
                // Verificar si el número de habitación no existe en la base de datos
                if (!contexto.Habitaciones.Any(h => h.NumHabitacion == numeroHabitacion))
                {
                    // Obtener el tipo de habitación seleccionado
                    string tipoSeleccionado = comboBox1.Text;

                    // Obtener el objeto TipoHabitacion según la descripción seleccionada en ComboBox1
                    TipoHabitacion tipoHabitacion = contexto.TipoHabitacion.SingleOrDefault(t => t.Descripcion == tipoSeleccionado);
                    if (tipoHabitacion != null)
                    {
                        // Crear una nueva habitación
                        Habitaciones nuevaHabitacion = new Habitaciones
                        {
                            NumHabitacion = numeroHabitacion,
                            Estado = "Libre",
                            Tipo = tipoHabitacion
                        };

                        // Agregar la nueva habitación a la base de datos y guardar los cambios
                         contexto.Habitaciones.Add(nuevaHabitacion);
                         contexto.SaveChanges();

                        MessageBox.Show("Habitación creada exitosamente.");
                    }
                    else
                    {
                        MessageBox.Show("Tipo de habitación no encontrado en la base de datos.");
                    }
                }
                else
                {
                    MessageBox.Show("El número de habitación ya existe en la base de datos.");
                }
            }
            else
            {
                MessageBox.Show("Por favor, ingresa un número de habitación válido.");
            }
        }
    }
}
