﻿using System;
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
    public partial class FormMenuPrincipal : Form
    {
        public FormMenuPrincipal()
        {
            InitializeComponent();
           // EmailUsuario.Text = emailUsuario;
        }

        private void FormMenuPrincipal_Load(object sender, EventArgs e)
        {

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


        private void button3_Click(object sender, EventArgs e)
        {

            /*  FormEntradasSalidas registroForm = new FormEntradasSalidas();
             *  registroForm.Show();
             *  this.Hide();*/


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
    }
}
