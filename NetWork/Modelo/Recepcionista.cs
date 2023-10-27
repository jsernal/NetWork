using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace NetWork.Modelo
{
    public class Recepcionista : Empleados
    {
        public Recepcionista(int codigoEmpleado, string nombre, string dni, string telefono)
        {
            CodigoEmpleado = codigoEmpleado;
            Nombre = nombre;
            Dni = dni;
            Telefono = telefono;
        }
    }
}
