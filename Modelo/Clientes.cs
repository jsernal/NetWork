using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetWork.Modelo {
    public enum TipoCliente
    {
        Normal,
        Vip
    }
    public class Clientes
    {
        [Key]
        public int IdCliente { get; set; }
        public string Dni {  get; set; }
        public string Nombre { get; set; }
        public int Telefono { get; set; }
        public TipoCliente Tipo {  get; set; }
        public string Email {  get; set; }

        public Clientes(int idCliente, string dni, string nombre, int telefono, TipoCliente tipo, string email)
        {
            IdCliente = idCliente;
            Dni = dni;
            Nombre = nombre;
            Telefono = telefono;
            Tipo = tipo;
            Email = email;
        }
    }
}
