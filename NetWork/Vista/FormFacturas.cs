using NetWork.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace NetWork.Vista
{
    public partial class FormFacturas : Form
    {
        public FormFacturas(string emailUsuario)
        {
            InitializeComponent();
            EmailUsuario.Text = emailUsuario;
            cargarForm();
        }

        ConexionDB db;
        Facturas factura = new Facturas();

        public List<Facturas> Read()
        {
            try
            {
                using (db = new ConexionDB())
                {
                    return db.Facturas.ToList();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }

        }

     /*   public void Delete(int numFactura)
        {
            {
                try

                {
                    using (db = new ConexionDB())
                    {
                        db.Facturas.Remove(db.Facturas.Single(Facturas => Facturas.NumFactura == numFactura));
                        db.SaveChanges();
                    }

                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }*/

        //Buscar servicios por NIF
        public List<Facturas> buscarPorNif(string dniCliente)
        {
            try
            {
                using (db = new ConexionDB())
                {
                    return db.Facturas.Where(Facturas => Facturas.IdCliente == dniCliente).ToList();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }

        }


        private void cargarDatos()
           {
               factura.IdCliente = textBoxNifCliente.Text;
                cargarGrid();
           }

        private void cargarGrid()
        {
            var Lst = Read();
            dataGridView1.DataSource = Lst;
        }

        private void cargarForm()
        {
            cargarGrid();
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MenuPrincipal registroForm = new MenuPrincipal(EmailUsuario.Text);

            registroForm.Show();

            this.Close();
        }
        //Mostrar en Grid solo aquellos servicios para un DNI concreto
        private void textBoxNifCliente_TextChanged(object sender, EventArgs e)
        {
            if (textBoxNifCliente.Text != String.Empty)
            {
                var Lst = buscarPorNif(textBoxNifCliente.Text);
                dataGridView1.DataSource = Lst;
            }
            else
            {
                cargarGrid();


            }

        }

        //Mostrar cantidad total factura
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBoxNifCliente.Text == string.Empty)
            {
                textTotal.Text = string.Empty;
            }
            double suma = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1.Rows[i].Cells[1].Value.Equals(textBoxNifCliente.Text))
                {
                    suma += Convert.ToDouble(dataGridView1.Rows[i].Cells["TotalFactura"].Value.ToString());
                }
            }
            
            textTotal.Text = suma.ToString();

        }

     }
 }
