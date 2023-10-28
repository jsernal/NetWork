//using Microsoft.VisualBasic.Devices;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace NetWork
{
    public class ConexionERP
    {
       /* public static void ActividadToXML(string filePath)
        {

            using (NetworkDBEntities dBhotel = new NetworkDBEntities())
            {

                List<ClienteView> ListaActividades = GestionHotel.ListarActividades();


                XmlSerializer serializer = new XmlSerializer(typeof(List<ClienteView>), new XmlRootAttribute("ClienteList"));

                using (TextWriter writer = new StreamWriter(filePath))
                {
                    serializer.Serialize(writer, ListaActividades);
                }
            }
        }




        public static void xmlToActividad(string filePath)
        {
            Clientelst ClienteXmlLst = new ClienteLst();
            XmlSerializer serializer = new XmlSerializer(typeof(ClienteLst));
            using (StreamReader reader = new StreamReader(filePath))
            {
                ClienteXmlLst = (ClienteLst)serializer.Deserialize(reader);
            }
            using (NetworkDBEntities dBHotel = new NetworktDBentities())
            {
                var ClienteBDLst = dBHotel.ClienteBDLst;
                foreach (var Clientexml in ClienteXmlLst.Clientes)
                {
                    var ClienteBD = ClienteBDLst.FirstOrDefault(s => s.dni == Clientexml.DNI);
                    if (ClienteBD != null)
                    {
                        ClienteBD.DNI = Clientexml.DNI;
                        ClienteBD.nombre = Clientexml.nombre;
                        ClienteBD.telef = Clientexml.telef;
                        ClienteBD.tipoCliente = Clientexml.tipoCliente;
                        ClienteBD.email = Clientexml.email;
                        dBHotel.Entry(ClienteBD).State = EntityState.Modified;
                    }

                    else
                    {
                        var newCliente = Cliente()
                            {
                            DNI = Clientexml.DNI;
                            nombre = Clientexml.nombre;
                            telef = Clientexml.telef;
                            tipoCliente = Clientexml.tipoCliente;
                            email = Clientexml.email;
                        };
                        dBHotel.Add(newCliente);
                    }

                    foreach (var ClientesBD in ClienteBDLst) {
                        var ClienteXml = ClienteXmlLst.Cliente.FirstOrDefault(x => x.dni == ClientesBD.DNI);
                        if (ClienteXml == null)
                        {
                            dBHotel.Cliente.Remove(ClienteBD);

                        }
                    }
                    dBHotel.SaveChanges();
                }
            }
        }*/
    }
}

