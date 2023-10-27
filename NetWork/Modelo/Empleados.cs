using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetWork.Modelo
{
    public abstract class Empleados
    {
        [Key]
        public int CodigoEmpleado { get; set; }
        public string Nombre { get; set; }
        public string Dni { get; set; }
        public string Telefono { get; set; }

    }
}
