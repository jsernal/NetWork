using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetWork.Modelo
{
    public enum TipoServicio
    {
        Restaurante,
        Lavanderia,
        Gimnasio
    }
    public class Servicios
    {
        [Key]
        public int CodigoServicio { get; set; }
        public TipoServicio Tipo { get; set; }
        public decimal Precio { get; set; }


        public Servicios(int codigoServicio, TipoServicio tipo, decimal precio)
        {
            CodigoServicio = codigoServicio;
            Tipo = tipo;
            Precio = precio;
        }
        public Servicios() { }
    }
}
