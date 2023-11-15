using NetWork.Modelo;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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

       /* public void Create(Facturas factura)
        {
            {
                try

                {
                    using (db = new ConexionDB())
                    {
                        db.Facturas.Add(factura);
                        db.SaveChanges();
                    }

                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }*/

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

        public void Update(Facturas factura)        
        {
            {
                try

                {
                    using (db = new ConexionDB())
                    {
                        db.Entry(factura).State = EntityState.Modified;
                        db.SaveChanges();
                    }

                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }
        public void Delete(int numFactura)
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
        }

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
          //     factura.NumFactura = Convert.ToInt32(textboxNumFactura.Text);
               factura.IdCliente = textBoxNifCliente.Text;
            // factura.CodigoServicio = Convert.ToInt32(textBoxCodServicio.Text);
               factura.TotalFactura = Convert.ToDecimal(textTotal.Text);


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
        private void limpiarDatos()
        {
            //textboxNumFactura.Focus();
            //textboxNumFactura.Text = string.Empty;
            textBoxNifCliente.Text = string.Empty;
            //dateTimePickerFecha.Text = string.Empty;
            //textBoxCodServicio.Text = string.Empty;
            cargarGrid();

        }



        private void label1_Click(object sender, EventArgs e)
        {

        }

     /*   private void btnEliminar_Click(object sender, EventArgs e)
        {
            {

                cargarDatos();
                Delete(factura.NumFactura);
                limpiarDatos();
            }
        } */

        private void button1_Click(object sender, EventArgs e)
        {
            MenuPrincipal registroForm = new MenuPrincipal(EmailUsuario.Text);

            registroForm.Show();

            this.Close();
        }

        private void textBoxTotalFactura_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

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

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void textTotal_TextChanged(object sender, EventArgs e)
        {
        }
    }
 }

        /*   private void btnGuardarCambios_Click(object sender, EventArgs e)
           {
               if (textboxCodigoReserva.Text != string.Empty)
               {
                   cargarDatos();
                   Update(factura);
                   limpiarDatos();
               }

           }*/
