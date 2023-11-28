using NetWork.Controlador;
using NetWork.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static NetWork.Controlador.RecepcionistaControlador;

namespace NetWork.Vista
{
    public partial class FormReservasEntradasSalidas : Form
    {
        private RecepcionistaControlador recepcionistaControlador;
        public FormReservasEntradasSalidas()
        {
            InitializeComponent();
            this.btnEntrSal.Click += new System.EventHandler(this.btnEntrSal_Click);
            recepcionistaControlador = new RecepcionistaControlador();
            
        }

        private void FormRecepcionista_Load(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
       private void btnEntrSal_Click(object sender, EventArgs e)
{
    try
    {
        var controlador = new RecepcionistaControlador();
        var fechaSalida = dateTimePicker1.Value;

     
        var reservasConClientes = controlador.ConsultarReservas(fechaSalida);



                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.DataSource = reservasConClientes;
    }
    catch (Exception ex)
    {
        MessageBox.Show(ex.Message, "Error al realizar la consulta");
    }
}

        private void txtbFirmar_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnFirmar_Click(object sender, EventArgs e)
        {
            
            if (int.TryParse(txtbFirmar.Text, out int codigoReserva))
            {
                
                string mensajeError;
                bool exito = recepcionistaControlador.FirmarReserva(codigoReserva, out mensajeError);

                if (exito)
                {
                    
                    MessageBox.Show("Reserva firmada con éxito.");
                }
                else
                {
                   
                    MessageBox.Show(mensajeError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                
                MessageBox.Show("Por favor, ingrese un código de reserva válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            MenuPrincipal menu = new MenuPrincipal("email@example.com");
            menu.Show();
            this.Close();
        }
    }
}
