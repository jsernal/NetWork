using NetWork.Modelo;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        public void Create(Facturas factura)
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
        }

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


        private void cargarDatos()
           {
               factura.NumFactura = Convert.ToInt32(textboxNumFactura.Text);
               factura.IdCliente = textBoxNifCliente.Text;
               factura.CodigoServicio = Convert.ToInt32(textBoxCodServicio.Text);
               factura.FechaFactura = DateTime.Parse(dateTimePickerFecha.Text);
                factura.TotalFactura = Convert.ToInt32(textBoxTotalFactura.Text);


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
            textboxNumFactura.Focus();
            textboxNumFactura.Text = string.Empty;
            textBoxNifCliente.Text = string.Empty;
            dateTimePickerFecha.Text = string.Empty;
            textBoxCodServicio.Text = string.Empty;
            cargarGrid();

        }



        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            {

                cargarDatos();
                Delete(factura.NumFactura);
                limpiarDatos();
            }
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            {
                textboxNumFactura.Text = dataGridView1.CurrentRow.Cells["NumFactura"].Value.ToString();

                textBoxNifCliente.Text = dataGridView1.CurrentRow.Cells["IdCliente"].Value.ToString();

                textBoxCodServicio.Text = dataGridView1.CurrentRow.Cells["CodigoServicio"].Value.ToString();

                dateTimePickerFecha.Text = dataGridView1.CurrentRow.Cells["FechaFactura"].Value.ToString();

                textBoxTotalFactura.Text = dataGridView1.CurrentRow.Cells["TotalFactura"].Value.ToString();

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MenuPrincipal registroForm = new MenuPrincipal(EmailUsuario.Text);

            registroForm.Show();

            this.Close();
        }

        private void textBoxTotalFactura_TextChanged(object sender, EventArgs e)
        {

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
    }
}
