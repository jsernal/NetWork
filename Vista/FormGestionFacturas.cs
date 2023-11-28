using NetWork.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace NetWork.Vista
{
    public partial class FormGestionFacturas : Form
    {
        public FormGestionFacturas(string emailUsuario)
        {
            InitializeComponent();
            EmailUsuario.Text = emailUsuario;
            cargarForm();
        }

        ConexionDB db;
        public Facturas factura = new Facturas();
        public Reservas reserva = new Reservas();


        public List<object> Read()
        {
            using (var db = new ConexionDB())
            {
                var listaFacturas = db.Facturas
                                      .Include("Reservas")
                                      .Include("Reservas.Cliente")
                                      .Select(f => new
                                      {
                                          NumFactura = f.NumFactura,
                                          CodigoReservas = f.CodigoReservas,
                                          CodigoServicio = f.CodigoServicio,
                                          IdCliente = f.IdCliente,
                                          TotalFactura = f.TotalFactura,
                                          FechaFactura = f.FechaFactura,
                                          DniCliente = f.Reservas.Cliente.Dni 
                                      })
                                      .ToList()
                                      .Cast<object>()
                                      .ToList();

                return listaFacturas;
            }
        }

        private void cargarDatos()
        {
            int codigoReserva = Convert.ToInt32(textBoxCodigoReservas1.Text);
            factura.NumFactura = Convert.ToInt32(textboxNumeroFactura.Text);
            factura.CodigoReservas = codigoReserva;
            factura.CodigoServicio = Convert.ToInt32(textBoxCodigoServicio.Text);
            factura.TotalFactura = Convert.ToDecimal(textBoxTotalFactura.Text);
            factura.FechaFactura = Convert.ToDateTime(dateTimePickerFechaFactura.Text);

            using (var db = new ConexionDB())
            {
                var reserva = db.Reservas.Include("Cliente").FirstOrDefault(r => r.CodigoReservas == codigoReserva);
                if (reserva != null && reserva.Cliente != null)
                {
                    factura.Dni = reserva.Cliente.Dni; 
                }
            }
        }

        private void cargarGrid()
        {

            var Lst = Read();
            dgvGestionFacturas.DataSource = Lst;
            dgvGestionFacturas.Columns["IdCliente"].Visible = false;
        }

        private void cargarForm()
        {
            cargarGrid();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            MenuPrincipal registroForm = new MenuPrincipal(EmailUsuario.Text);

            registroForm.Show();

            this.Close();
        }
        private void limpiarDatos()
        {
            textboxNumeroFactura.Text = string.Empty;
            textBoxCodigoReservas1.Text = string.Empty;
            textBoxCodigoServicio.Text = string.Empty;
            dateTimePickerFechaFactura.Text = string.Empty;
            textBoxIdCliente.Text = string.Empty;
            textBoxTotalFactura.Text = string.Empty;
            cargarGrid();
        }


        private void genFactura_Click(object sender, EventArgs e)
        {
            {
              
                FormFactura factura = new FormFactura(EmailUsuario.Text, this);
                factura.Show();
            }
        }

        private void dgvGestionFacturas_CellMouseClick_1(object sender, DataGridViewCellMouseEventArgs e)
        {
            int codigoFactura;
            {

                codigoFactura = (int)dgvGestionFacturas.CurrentRow.Cells["NumFactura"].Value;
                textboxNumeroFactura.Text = dgvGestionFacturas.CurrentRow.Cells["NumFactura"].Value.ToString();
                textBoxIdCliente.Text = dgvGestionFacturas.CurrentRow.Cells["IdCliente"].Value.ToString();
                textBoxCodigoReservas1.Text = dgvGestionFacturas.CurrentRow.Cells["CodigoReservas"].Value.ToString(); ;
                textBoxCodigoServicio.Text = dgvGestionFacturas.CurrentRow.Cells["CodigoServicio"].Value.ToString();
                dateTimePickerFechaFactura.Text = dgvGestionFacturas.CurrentRow.Cells["FechaFactura"].Value.ToString();
                textBoxTotalFactura.Text = dgvGestionFacturas.CurrentRow.Cells["TotalFactura"].Value.ToString();
                cargarDatos();

            }
        }

       
        public string valorTextBoxIdCliente
        {
            get { return textBoxIdCliente.Text; }
        }

        private void FormGestionFacturas_Load(object sender, EventArgs e)
        {

        }

        private void dgvGestionFacturas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
