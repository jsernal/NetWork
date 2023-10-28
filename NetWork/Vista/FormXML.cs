using NetWork.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using static NetWork.Modelo.Clientes;

namespace NetWork.Vista
{
    public partial class FormXML : Form
    {
        public FormXML()
        {
            InitializeComponent();
        }


        private void FormXML_Load_1(object sender, EventArgs e)
        {
            Refresh();
        }
        new
       public void Refresh()
        {
            using (ConexionDB db = new ConexionDB())
            {

                dataGridView1.DataSource = db.Clientes.ToList();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Archivos XML (*.xml)|*.xml";
            saveFileDialog1.Title = "Guardar archivo XML";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog1.FileName;
                ActividadToXML(filePath);
            }
        }

        public static void ActividadToXML(string filePath)
        {
            using (ConexionDB db = new ConexionDB())
            {
                List<Clientes> ListaActividades = db.Clientes.ToList();

                XmlSerializer serializer = new XmlSerializer(typeof(List<Clientes>), new XmlRootAttribute("ClienteList"));

                using (TextWriter writer = new StreamWriter(filePath))
                {
                    serializer.Serialize(writer, ListaActividades);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Archivos XML (*.xml)|*.xml";
            openFileDialog1.Title = "Abrir archivo XML";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog1.FileName;
                xmlToActividad(filePath);
            }
        }



        public static void xmlToActividad(string filePath)
        {
            ClienteLst ClienteXmlLst = new ClienteLst();
            XmlSerializer serializer = new XmlSerializer(typeof(List<Clientes>));
            using (StreamReader reader = new StreamReader(filePath))
            {
                ClienteXmlLst = (ClienteLst)serializer.Deserialize(reader);
            }
            using (ConexionDB db = new ConexionDB())
            {
                var ClienteBDLst = db.Clientes.ToList();
                foreach (var Clientexml in ClienteXmlLst.Clientes)
                {
                    var ClienteBD = ClienteBDLst.FirstOrDefault(s => s.Dni == Clientexml.Dni);
                    if (ClienteBD != null)
                    {
                        ClienteBD.Dni = Clientexml.Dni;
                        ClienteBD.Nombre = Clientexml.Nombre;
                        ClienteBD.Telefono = Clientexml.Telefono;
                        ClienteBD.Tipo = Clientexml.Tipo;
                        ClienteBD.Email = Clientexml.Email;
                        db.Entry(ClienteBD).State = EntityState.Modified;
                    }

                    else
                    {
                        var newCliente = new Clientes
                        {
                            Dni = Clientexml.Dni,
                            Nombre = Clientexml.Nombre,
                            Telefono = Clientexml.Telefono,
                            Tipo = Clientexml.Tipo,
                            Email = Clientexml.Email
                        };
                        db.Clientes.Add(newCliente);
                    }


                    foreach (var ClientesBD in ClienteBDLst) {
                        var ClienteXml = ClienteXmlLst.Clientes.FirstOrDefault(x => x.Dni == ClientesBD.Dni);
                        if (ClienteXml == null)
                        {
                            db.Clientes.Remove(ClienteBD);

                        }
                    }
                    db.SaveChanges();
                }
            }
        }



    }
}
