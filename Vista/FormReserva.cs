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

        private decimal precioBase;
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

            DateTime diaSiguiente = fecha.AddDays(1);

           
            dateTimePicker1.Value = diaSiguiente;

            dateTimePicker1.MinDate = diaSiguiente;
            dateTimePicker1.Enabled = false;
            precioBase = decimal.Parse(precio);
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string textoLabel = label15.Text;
            decimal precioBase1 = precioBase;
            int incremento = 0;

           
            switch (comboBox1.SelectedIndex)
            {
                case 0: 
                    incremento = 15;
                    break;
                case 1: 
                    incremento = 35;
                    break;
                case 2: 
                    incremento = 55;
                    break;
                   
            }

        
            decimal precioTotal = precioBase1 + incremento;

          

            comboBox1.Enabled = false;
            dateTimePicker1.Enabled = true;

           
            label15.Text = precioTotal.ToString(); 
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

            decimal precioActual = precioBase;

           
            decimal nuevoPrecio = precioActual * diasDiferencia;

            
            label15.Text = nuevoPrecio.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
       
            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, seleccione el tipo de pensión.");
                return;
            }

            
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Por favor, ingrese un email.");
                return;
            }

           
            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Por favor, ingrese el DNI.");
                return;
            }
            string email = textBox1.Text;
            string dni = textBox2.Text;

            using (ConexionDB db = new ConexionDB())
            {
                    
                    var cliente = db.Clientes.FirstOrDefault(c => c.Email == email && c.Dni == dni);

                    if (cliente == null)
                    {
                        MessageBox.Show("El email y el DNI no corresponden al mismo cliente.");
                        return;
                    }

                

                DateTime fechaEntrada = data;
                DateTime fechaSalida = dateTimePicker1.Value;
                string numHabitacion1 = label9.Text;

                Reservas nuevaReserva = new Reservas
                {
                    FechaEntrada = fechaEntrada,
                    FechaSalida = fechaSalida,
                    IdCliente = cliente.IdCliente,
                    DniCliente = cliente.Dni,
                    NumHabitacion = int.Parse(numHabitacion1)
                };

                db.Reservas.Add(nuevaReserva);
                db.SaveChanges();

               
                db.SaveChanges();

               
                int codigoServicio = comboBox1.SelectedIndex + 1; 
                decimal totalFactura = decimal.Parse(label15.Text);

                Facturas nuevaFactura = new Facturas
                {
                    CodigoReservas = nuevaReserva.CodigoReservas,
                    IdCliente = Convert.ToString(cliente.IdCliente), 
                    CodigoServicio = codigoServicio,
                    TotalFactura = totalFactura,
                    FechaFactura = fechaEntrada
                };

                db.Facturas.Add(nuevaFactura);
                db.SaveChanges();

                FormCalendario registroForm = new FormCalendario(label13.Text);

                registroForm.Show();

                this.Close();
            } 
        }

        private void FormReserva_Load(object sender, EventArgs e)
        {

        }
    }
}
