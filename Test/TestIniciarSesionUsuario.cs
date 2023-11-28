using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NetWork.Modelo;
using NetWork.Vista;

namespace NetWork.Test
{
    [TestClass]
    public class TestIniciarSesionUsuario :FormIniciarSesionUsuario
    {

        [TestMethod]
        public void VerificarCredenciales_RetornaTrue_SiCredencialesValidas()
        {
         
            var email = "pepe@gmail.com";
            var contraseña = "pepe";

           
            var resultado = VerificarCredenciales(email, contraseña);

            
            Assert.IsTrue(resultado);
        }

        [TestMethod]
        public void VerificarCredenciales_RetornaFalse_SiCorreoesVacio()
        {
            // Arrange
            
            var email = "";
            var contraseña = "contraseña";

            // Act
            var resultado = VerificarCredenciales(email, contraseña);

            // Assert
            Assert.IsFalse(resultado);
        }

        [TestMethod]
        public void VerificarCredenciales_RetornaFalse_SiContraseñaVacia()
        {
            // Arrange

            var email = "pepe@gmail.com";
            var contraseña = "";

            // Act
            var resultado = VerificarCredenciales(email, contraseña);

            // Assert
            Assert.IsFalse(resultado);
        }


    

    }
}
