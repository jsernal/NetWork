using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;
using System.Xml.Linq;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;

namespace NetWork.Modelo
{
    public class CreacionXML
    {
        public void CrearXMLClientes(DataGridView dgv)
        {
            var clientes = new List<Clientes>();

            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.IsNewRow) continue;

                var cliente = new Clientes
                {
                    IdCliente = Convert.ToInt32(row.Cells["ColumnIdCliente"].Value),
                    Dni = row.Cells["ColumnDNI"].Value.ToString(),
                    Nombre = row.Cells["ColumnNombre"].Value.ToString(),
                    Telefono = Convert.ToInt32(row.Cells["ColumnTelef"].Value),
                    Tipo = (TipoCliente)Enum.Parse(typeof(TipoCliente), row.Cells["ColumnTipo"].Value.ToString()),
                    Email = row.Cells["ColumnEmail"].Value.ToString()

                };

                clientes.Add(cliente);
            }

            XmlSerializer serializer = new XmlSerializer(typeof(List<Clientes>));
            using (TextWriter writer = new StreamWriter(@"C:\Users\sergi\Desktop\GIT\Network\NetWork\XML\Clientes.xml"))
            {
                serializer.Serialize(writer, clientes);
            }

        }
        public List<Clientes> LeerXML(string rutaArchivo)
        {
            List<Clientes> clientes = new List<Clientes>();

            XDocument doc = XDocument.Load(rutaArchivo);
            foreach (var node in doc.Root.Elements("Clientes"))
            {
                var cliente = new Clientes
                {
                    IdCliente = Convert.ToInt32(node.Element("IdCliente").Value),
                    Dni = (string)node.Element("Dni"),
                    Nombre = (string)node.Element("Nombre"),
                    Telefono = (int)node.Element("Telefono"),
                    Tipo = (TipoCliente)Enum.Parse(typeof(TipoCliente), (string)node.Element("Tipo")),
                    Email = (string)node.Element("Email")
                };

                clientes.Add(cliente);
            }

            return clientes;
        }
    }
}
