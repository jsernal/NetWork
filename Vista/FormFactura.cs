using NetWork.Modelo;
using System;
using System.Linq;
using System.Windows.Forms;

namespace NetWork.Vista
{
    public partial class FormFactura : Form
    {
        private FormGestionFacturas formGestionFacturas;
        private Facturas facturas;
        string formatoFecha = "dd-MM-yyyy";




        public FormFactura(string emailUsuario, FormGestionFacturas formGestionFacturas)
        {
            InitializeComponent();
            label9.Text = emailUsuario;
            this.formGestionFacturas = formGestionFacturas;
            facturas = new Facturas();
            CargarDatos();
        }

        private void CargarDatos()
        {
            label6.Text = formGestionFacturas.factura.CodigoReservas.ToString();
            label2.Text = formGestionFacturas.factura.FechaFactura.ToString(formatoFecha);
            label20.Text = formGestionFacturas.factura.TotalFactura.ToString("C");
            label27.Text = formGestionFacturas.factura.CodigoServicio.ToString();

            int codigoReservasFactura = formGestionFacturas.factura.CodigoReservas;

            using (var db = new ConexionDB())
            {
                var reservaAsociada = db.Reservas.Include("Cliente").FirstOrDefault(r => r.CodigoReservas == codigoReservasFactura);
                if (reservaAsociada != null)
                {
                    DateTime fechaEntrada = reservaAsociada.FechaEntrada;
                    DateTime fechaSalida = reservaAsociada.FechaSalida;

                    label13.Text = fechaEntrada.ToString(formatoFecha);
                    label14.Text = fechaSalida.ToString(formatoFecha);

                    
                    if (reservaAsociada.Cliente != null)
                    {
                        label7.Text = reservaAsociada.Cliente.Dni; 
                    }
                }
            }

            int codigoServiciosFactura = formGestionFacturas.factura.CodigoServicio;
            Servicios servicioAsociado = ObtenerInformacionServiciosPorCodigo(codigoServiciosFactura);
            if (servicioAsociado != null)
            {
                int codigoSer = servicioAsociado.CodigoServicio;
                decimal precioServicio = servicioAsociado.Precio;

                label27.Text = codigoSer.ToString();
                label28.Text = precioServicio.ToString();
                label21.Text = precioServicio.ToString();
            }
            else
            {

                label27.Text = "No hay servicios asociados";
                label28.Text = "No hay servicios asociados";
                label21.Text = "No hay servicios asociados";
            }

            decimal totalServicios;

            if (string.IsNullOrWhiteSpace(label28.Text))
            {
                totalServicios = 0;
            }
            else
            {
                totalServicios = Convert.ToDecimal(label28.Text);
            }

            label24.Text = (totalServicios + formGestionFacturas.factura.TotalFactura).ToString("C");
            label4.Text = (totalServicios + formGestionFacturas.factura.TotalFactura).ToString("C");



            ObtenerYMostrarDescripcionTipoAlojamiento(codigoReservasFactura, label17);





        }
        public Reservas ObtenerInformacionReservasPorCodigo(int codigoReservasFactura)
        {
            using (var db = new ConexionDB())
            {
               
                Reservas reservaAsociada = db.Reservas
                    .AsNoTracking()
                    .FirstOrDefault(r => r.CodigoReservas == codigoReservasFactura);

                return reservaAsociada;
            }
        }

        public Servicios ObtenerInformacionServiciosPorCodigo(int codigoServiciosFactura)
        {
            using (var db = new ConexionDB())
            {
                
                Servicios servicioAsociado = db.Servicios
                    .AsNoTracking()
                    .FirstOrDefault(s => s.CodigoServicio == codigoServiciosFactura);

                return servicioAsociado;
            }
        }

        public void ObtenerYMostrarCodigoTipoAlojamiento(int codigoReservaFactura, Label labelDescripcion)
        {
            using (var db = new ConexionDB())
            {
               
                int? codigoTipoAlojamiento = db.Facturas
                    .Where(f => f.CodigoReservas == codigoReservaFactura)
                    .Join(
                        db.Reservas,
                        facturas => facturas.CodigoReservas,
                        reservas => reservas.CodigoReservas,
                        (facturas, reservas) => new { Facturas = facturas, Reservas = reservas }
                    )
                    .Select(facturasReservas => facturasReservas.Reservas.CodigoTipoAloj)
                    .FirstOrDefault();

                if (codigoTipoAlojamiento.HasValue)
                {
                   
                    labelDescripcion.Text = codigoTipoAlojamiento.ToString();
                }
                else
                {
                   
                    labelDescripcion.Text = "No hay CodigoTipoAlojamiento";
                }
            }
        }

        public void ObtenerYMostrarDescripcionTipoAlojamiento(int codigoReservaFactura, Label labelDescripcion)
        {
            using (var db = new ConexionDB())
            {
               
                string descripcionTipoAlojamiento = db.Facturas
                    .Where(f => f.CodigoReservas == codigoReservaFactura)
                    .Join(
                        db.Reservas,
                        facturas => facturas.CodigoReservas,
                        reservas => reservas.CodigoReservas,
                        (facturas, reservas) => new { Facturas = facturas, Reservas = reservas }
                    )
                    .Join(
                        db.TipoAlojamiento,
                        facturasReservas => facturasReservas.Reservas.CodigoTipoAloj,
                        tipoAlojamiento => tipoAlojamiento.CodigoTipoAloj,
                        (facturasReservas, tipoAlojamiento) => tipoAlojamiento.Descripcion
                    )
                    .FirstOrDefault();

                if (!string.IsNullOrEmpty(descripcionTipoAlojamiento))
                {
                    
                    labelDescripcion.Text = descripcionTipoAlojamiento;
                }
                else
                {
                   
                    labelDescripcion.Text = "No hay Descripción";
                }
            }
        }

        private void FormFactura_Load(object sender, EventArgs e)
        {

        }

        private void label28_Click(object sender, EventArgs e)
        {

        }

        private void label27_Click(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}