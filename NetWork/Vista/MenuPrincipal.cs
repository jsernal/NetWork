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
    public partial class MenuPrincipal : Form
    {
        public MenuPrincipal(string emailUsuario)
        {
            InitializeComponent();
            EmailUsuario.Text = emailUsuario;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            // Crear una instancia del formulario "RegistroClientes"
            FormClientes registroForm = new FormClientes();

            // Mostrar el formulario "RegistroClientes"
            registroForm.Show();

            // Opcional: Ocultar el formulario actual "menuprincipal"
            this.Hide();
        }
        private void button6_Click(object sender, EventArgs e)
        {
            /*
                        FormLogin registroForm = new FormLogin();


                        registroForm.Show();

                        // Opcional: Cerrar el formulario actual "menuprincipal"
                        this.Close();*/
        }


        private void button4_Click(object sender, EventArgs e)
        {

            /*  FormHistorico registroForm = new FormHistorico();

                registroForm.Show();

                this.Hide();*/
        }

        private void button5_Click(object sender, EventArgs e)
        {
            /*  FormAnularModificar registroForm = new FormAnularModificar();

                registroForm.Show();

                this.Hide();*/
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormCalendario CalendarioForm = new FormCalendario(EmailUsuario.Text);


           CalendarioForm.Show();


            this.Hide();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            Form formulario = new FormModificarReservas(EmailUsuario.Text);
            formulario.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form formulario = new FormFacturas(EmailUsuario.Text);
            formulario.Show();
            this.Hide();
        }


        private void MenuPrincipal_Load(object sender, EventArgs e)
        {
            // Verificar si el EmailUsuario.Text es "recep@hotelsol.com"
            if (EmailUsuario.Text.Trim().ToLower() == "recep@hotelsol.com")
            {
                // Deshabilitar los botones 1, 8, 2 y 4
                button1.Enabled = false;
                button8.Enabled = false;
                button2.Enabled = false;
                button4.Enabled = false;
            }
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            Form formulario = new FormHabitaciones(EmailUsuario.Text);
            formulario.Show();
            this.Hide();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            FormReservasEntradasSalidas registroForm = new FormReservasEntradasSalidas();
            registroForm.Show();
            this.Hide();
        }
    }
}
