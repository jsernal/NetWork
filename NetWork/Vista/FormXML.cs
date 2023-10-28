using NetWork.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

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
            ActividadToXML("C:\\Users\\sergi\\Desktop");
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

    }
}
