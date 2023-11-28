using Microsoft.VisualStudio.TestTools.UnitTesting;
using NetWork.Vista;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetWork.Test
{
    [TestClass]
    public class TestRegistroHabitacion
    {
        [TestMethod]
        public void ValidarExisteHabitacion_AlAgregarNuevaHabitacion()
        {
            
            var formulario = new FormHabitaciones("correo@ejemplo.com");

            // Act
            formulario.textBox1.Text = "123";  
            formulario.comboBox1.Text = "Habitación Estándar";  

            
            formulario.button1_Click_1(null, EventArgs.Empty);

            
            Assert.IsTrue(formulario.mensajeMostrado);
        }
    }
}
