using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetWork.Modelo
{
    public class Facturas
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int NumFactura { get; set; }
        public string IdCliente { get; set; }
        public int CodigoServicio { get; set; }
        public decimal TotalFactura { get; set; }
        public DateTime FechaFactura { get; set; }


        public Facturas(int numFactura, string idCliente, int codigoServicio, decimal totalFactura, DateTime fechaFactura)
        {
            NumFactura = numFactura;
            IdCliente = idCliente;
            CodigoServicio = codigoServicio;
            TotalFactura = totalFactura;
            FechaFactura = fechaFactura;
        }
        public Facturas() { }
    }
}
