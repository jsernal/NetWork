using NetWork.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace NetWork.Vista
{
    public partial class FormConOdoo : Form
    {
        public FormConOdoo()
        {
            InitializeComponent();
        }

        private void FormOdoo_Load(object sender, EventArgs e)
        {

        }

        private void btnActividadesOdoo_Click(object sender, EventArgs e)
        {

        }




        private void FormConOdoo_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //exportamos un XML con Reservas

            ConexionDB db = new ConexionDB();
            XElement xml = new XElement("Reservas",
                               (from columna in db.Reservas
                                select new
                                {
                                    columna.NumHabitacion,
                                    columna.IdCliente,
                                    columna.FechaEntrada,
                                    columna.FechaSalida,
                                    columna.EstadoReserva,
                                    columna.CodigoReservas
                                }).ToList().Select(
                                           x => new XElement("Reservas",
                                                new XAttribute("CodigoReservas", x.CodigoReservas),
                                                new XAttribute("NumHabitacion", x.NumHabitacion),
                                                new XAttribute("FechaEntrada", x.FechaEntrada),
                                                new XAttribute("FechaSalida", x.FechaSalida),
                                                new XAttribute("IdCliente", x.IdCliente),
                                                new XAttribute("EstadoReserva", x.EstadoReserva)
                                           )));

            FileStream xmlFile = File.OpenWrite(@"C:\Users\sergi\Documents\GitHub\NetWork\NetWork\Controlador\\Reservas.xml");
            byte[] xmlBytes = Encoding.UTF8.GetBytes(xml.ToString());
            xmlFile.Write(xmlBytes, 0, xmlBytes.Length);
            xmlFile.Close();

            // pasamos el xml al programa python
            var script = @"C:\Users\sergi\Documents\GitHub\NetWork\NetWork\Controlador\OdooReservas.py";        // ESCIRBIR LA DIRECCIÓN DEL PY        
            var psi = new ProcessStartInfo();
            psi.FileName = @"C:\Users\sergi\AppData\Local\Programs\Python\Python312\python.exe";
            psi.Arguments = $"\"{script}\"";
            Process process = new Process();
            process.StartInfo = psi;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardInput = true;
            process.StartInfo.RedirectStandardOutput = true;

            process.Start();

            process.StartInfo.RedirectStandardOutput = true;

            while (!process.StandardOutput.EndOfStream)
            {
                string line = process.StandardOutput.ReadLine();
                MessageBox.Show(line);
            }
            process.WaitForExit();

            MessageBox.Show("Se han cargado los datos a Odoo");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //exportamos un XML con Clientes

            ConexionDB db = new ConexionDB();
            XElement xml = new XElement("Clientes",
                               (from columna in db.Clientes
                                select new
                                {
                                    columna.IdCliente,
                                    columna.Nombre,
                                    columna.Telefono,
                                    columna.Dni,
                                    columna.Email,
                                    columna.Tipo
                                }).ToList().Select(
                                           x => new XElement("Cliente",
                                           new XAttribute("idCliente", x.IdCliente),
                                                new XAttribute("Nombre", x.Nombre),
                                                new XAttribute("Telefono", x.Telefono),
                                                new XAttribute("DNI", x.Dni),
                                                new XAttribute("Email", x.Email),
                                                new XAttribute("Tipo", x.Tipo)
                                           )));

            FileStream xmlFile = File.OpenWrite(@"C:\Users\sergi\Documents\GitHub\NetWork\NetWork\Controlador\\Clientes.xml");
            byte[] xmlBytes = Encoding.UTF8.GetBytes(xml.ToString());
            xmlFile.Write(xmlBytes, 0, xmlBytes.Length);
            xmlFile.Close();

            // pasamos el xml al programa python
            var script = @"C:\Users\sergi\Documents\GitHub\NetWork\NetWork\Controlador\OdooClientes.py";        // ESCIRBIR LA DIRECCIÓN DEL PY

            var psi = new ProcessStartInfo();
            psi.FileName = @"C:\Users\sergi\AppData\Local\Programs\Python\Python312\python.exe";
            psi.Arguments = $"\"{script}\"";
            Process process = new Process();
            process.StartInfo = psi;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardInput = true;
            process.StartInfo.RedirectStandardOutput = true;

            process.Start();

            process.StartInfo.RedirectStandardOutput = true;

            while (!process.StandardOutput.EndOfStream)
            {
                string line = process.StandardOutput.ReadLine();
                MessageBox.Show(line);
            }
            process.WaitForExit();

            MessageBox.Show("Se han cargado los datos a Odoo");
        }

        private void button2_Click(object sender, EventArgs e)
        {

            ConexionDB db = new ConexionDB();
            XElement xml = new XElement("Habitaciones",
                               (from columna in db.Habitaciones
                                select new
                                {
                                    columna.NumHabitacion,
                                    columna.Estado,
                                    columna.Tipo.Descripcion,
                                }).ToList().Select(
                                           x => new XElement("Habitaciones",
                                                new XAttribute("NumHabitacion", x.NumHabitacion),
                                                new XAttribute("Estado", x.Estado),
                                                new XAttribute("Tipo", x.Descripcion)
                                           )));

            FileStream xmlFile = File.OpenWrite(@"C:\Users\sergi\Documents\GitHub\NetWork\NetWork\Controlador\\Habitaciones.xml");
            byte[] xmlBytes = Encoding.UTF8.GetBytes(xml.ToString());
            xmlFile.Write(xmlBytes, 0, xmlBytes.Length);
            xmlFile.Close();


            var script = @"C:\Users\sergi\Documents\GitHub\NetWork\NetWork\Controlador\OdooHabitaciones.py";
            var psi = new ProcessStartInfo();
            psi.FileName = @"C:\Users\sergi\AppData\Local\Programs\Python\Python312\python.exe";
            psi.Arguments = $"\"{script}\"";
            psi.UseShellExecute = false;
            psi.RedirectStandardOutput = true;
            psi.RedirectStandardError = true;

            Process process = new Process();
            process.StartInfo = psi;

            process.OutputDataReceived += (s, args) =>
            {
                if (!string.IsNullOrEmpty(args.Data))
                {
                    MessageBox.Show(args.Data); // Muestra la salida estándar del proceso
                }
            };

            process.ErrorDataReceived += (s, args) =>
            {
                if (!string.IsNullOrEmpty(args.Data))
                {
                    MessageBox.Show(args.Data); // Muestra los mensajes de error del proceso
                }
            };

            process.Start();
            process.BeginOutputReadLine();
            process.BeginErrorReadLine();

            process.WaitForExit();

            MessageBox.Show("¿Funciona?");
        }
    }
    }
