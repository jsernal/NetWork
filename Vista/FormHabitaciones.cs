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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace NetWork.Vista
{
        public partial class FormHabitaciones : Form
        {
            public bool mensajeMostrado { get; private set; }

        public FormHabitaciones(string emailUsuario)
            {
                InitializeComponent();
            EmailUsuario.Text = emailUsuario;
           
            }

            private int ObtenerCodigoTipoHabitacion(string tipoSeleccionado)
            {
                
                switch (tipoSeleccionado)
                {
                    case "Habitación Estándar":
                        return 101;
                    case "Suite de Lujo":
                        return 102;
                    case "Habitación Familiar":
                        return 103;
                    case "Habitación Individual":
                        return 104;
                    case "Habitación Doble":
                        return 105;
                    default:
                        throw new ArgumentException("Tipo de habitación no reconocido");
                }
            }
        
        private void FormHabitaciones_Load(object sender, EventArgs e)
        {

        }

        public void button2_Click_1(object sender, EventArgs e)
        {
            Form formulario = new MenuPrincipal(EmailUsuario.Text);
            formulario.Show();
            this.Hide();
        }

        public void button1_Click_1(object sender, EventArgs e)
        {
            ConexionDB contexto = new ConexionDB(); 
            if (!string.IsNullOrEmpty(textBox1.Text) && int.TryParse(textBox1.Text, out int numeroHabitacion))
            {
               
                if (!contexto.Habitaciones.Any(h => h.NumHabitacion == numeroHabitacion))
                {
                   
                    string tipoSeleccionado = comboBox1.Text;

                    
                    TipoHabitacion tipoHabitacion = contexto.TipoHabitacion.SingleOrDefault(t => t.Descripcion == tipoSeleccionado);

                    if (tipoHabitacion != null)
                    {
                        
                        Habitaciones nuevaHabitacion = new Habitaciones
                        {
                            NumHabitacion = numeroHabitacion,
                            Estado = "Libre",
                            Tipo = tipoHabitacion
                        };

                       
                         contexto.Habitaciones.Add(nuevaHabitacion);
                         contexto.SaveChanges();

                        MessageBox.Show("Habitación creada exitosamente.");
                    }
                    else
                    {
                        MessageBox.Show("Tipo de habitación no encontrado en la base de datos.");
                        mensajeMostrado = true;
                    }
                }
                else
                {
                    MessageBox.Show("El número de habitación ya existe en la base de datos.");
                    mensajeMostrado = true;
                }
            }
            else
            {
                MessageBox.Show("Por favor, ingresa un número de habitación válido.");
                mensajeMostrado = true;
            }
        }
    }
}
