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
    public partial class FormReserva : Form
    {

        private int precioBase;
        private DateTime data;

        public FormReserva(string emailUsuario, string numhab, string descripcion, string precio, DateTime fecha)
        {
            InitializeComponent();
            label13.Text = emailUsuario;
            label8.Text = fecha.ToString();
            label9.Text = numhab;
            label10.Text = descripcion;
            label15.Text = precio;
            data = fecha;

            // Para obtener el día siguiente a partir de la fecha dada
            DateTime diaSiguiente = fecha.AddDays(1);

            // Establecer el DateTimePicker con el día siguiente
            dateTimePicker1.Value = diaSiguiente;

            dateTimePicker1.MinDate = diaSiguiente;
            dateTimePicker1.Enabled = false;
            precioBase = int.Parse(precio);
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string textoLabel = label15.Text;
            int precioBase1 = precioBase;
            int incremento = 0;

            // Verificar qué elemento está seleccionado en el ListBox
            switch (comboBox1.SelectedIndex)
            {
                case 0: // Primer ítem seleccionado
                    incremento = 15;
                    break;
                case 1: // Segundo ítem seleccionado
                    incremento = 35;
                    break;
                case 2: // Tercer ítem seleccionado
                    incremento = 55;
                    break;
                    // Puedes añadir más casos si hay más elementos en el ListBox
            }

            // Calcular el precio total sumando el precio base con el incremento
            int precioTotal = precioBase1 + incremento;

            //MessageBox.Show(precioTotal.ToString());

            comboBox1.Enabled = false;
            dateTimePicker1.Enabled = true;

            // Actualizar el valor del Label con el precio total
            label15.Text = precioTotal.ToString(); // Muestra el precio en formato de moneda (por ejemplo, euros)
        }


        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormCalendario registroForm = new FormCalendario(label13.Text);

            registroForm.Show();

            this.Close();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            TimeSpan diferenciaDias = dateTimePicker1.Value - data;
            int diasDiferencia = (int)diferenciaDias.TotalDays;

            // Obtén el precio actual del label15
            int precioActual = precioBase;

            // Calcula el nuevo precio multiplicando el precio actual por la cantidad de días de diferencia
            int nuevoPrecio = precioActual * diasDiferencia;

            // Actualiza el texto del label15 con el nuevo precio
            label15.Text = nuevoPrecio.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Verifica si el ComboBox tiene un item seleccionado
            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, seleccione el tipo de pensión.");
                return;
            }

            // Verifica si textBox1 está vacío
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Por favor, ingrese un email.");
                return;
            }

            // Verifica si textBox2 está vacío
            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Por favor, ingrese el DNI.");
                return;
            }
            string email = textBox1.Text;
            string dni = textBox2.Text;

            using (ConexionDB db = new ConexionDB())
            {
                    // Verificar si existe un cliente con el email y DNI proporcionados
                    var cliente = db.Clientes.FirstOrDefault(c => c.Email == email && c.Dni == dni);

                    if (cliente == null)
                    {
                        MessageBox.Show("El email y el DNI no corresponden al mismo cliente.");
                        return;
                    }

                // Si el email y el DNI pertenecen al mismo cliente, continuar con la lógica adicional del botón
                // Obtener datos para la reserva
                    DateTime fechaEntrada = data;
                    DateTime fechaSalida = dateTimePicker1.Value;
                    string numHabitacion1 = label9.Text;

                    // Insertar datos de reserva por cada día entre fecha de entrada y salida
                    for (DateTime date1 = fechaEntrada; date1 <= fechaSalida; date1 = date1.AddDays(1))
                    {
                        Reservas nuevaReserva = new Reservas
                        {
                            Fecha = date1,
                            DniCliente = cliente.Dni,
                            NumHabitacion = int.Parse(numHabitacion1)
                };

                        db.Reservas.Add(nuevaReserva);
                    }

                    // Guardar los cambios en la base de datos
                    db.SaveChanges();

                    // Insertar en la tabla Factura
                    int codigoServicio = comboBox1.SelectedIndex + 1; // Sumamos 1 porque los índices comienzan en 0
                    decimal totalFactura = decimal.Parse(label15.Text);

                    Facturas nuevaFactura = new Facturas
                    {
                        IdCliente = Convert.ToString(cliente.IdCliente), // Suponiendo que hay un campo Id en la tabla Clientes
                        CodigoServicio = codigoServicio,
                        TotalFactura = totalFactura
                    };

                    db.Facturas.Add(nuevaFactura);
                    db.SaveChanges();

                    FormCalendario registroForm = new FormCalendario(label13.Text);

                    registroForm.Show();

                     this.Close();
            } 
        }

    }
}
