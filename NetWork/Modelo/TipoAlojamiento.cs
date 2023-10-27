using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetWork.Modelo
{
    public class TipoAlojamiento
    {
        [Key]
        public int CodigoTipoAloj { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }

        public TipoAlojamiento(string descripcion, decimal precio)
        {
            Descripcion = descripcion;
            Precio = precio;
        }
    }
}
