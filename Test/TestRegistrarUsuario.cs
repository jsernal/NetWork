using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NetWork.Modelo;
using NetWork.Vista;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NetWork.Test
{
    [TestClass]
    public class TestRegistrarUsuario : FormRegistrarUsuario
    {
        [TestMethod]
        public void ValidarRegistroUsuario_RetornaTrue_SiUsuarioRegistradoCorrectamente()
        {
            // Arrange
            var contextoMock = new Mock<ConexionDB>();

            // Configurar el DbSet para el tipo de entidad usando una lista
            var clientes = new List<Clientes>();
            var clientesMock = new Mock<DbSet<Clientes>>();
            clientesMock.As<IQueryable<Clientes>>().Setup(m => m.Provider).Returns(clientes.AsQueryable().Provider);
            clientesMock.As<IQueryable<Clientes>>().Setup(m => m.Expression).Returns(clientes.AsQueryable().Expression);
            clientesMock.As<IQueryable<Clientes>>().Setup(m => m.ElementType).Returns(clientes.AsQueryable().ElementType);
            clientesMock.As<IQueryable<Clientes>>().Setup(m => m.GetEnumerator()).Returns(() => clientes.GetEnumerator());

            contextoMock.Setup(c => c.Set<Clientes>()).Returns(clientesMock.Object);

            
            var formRegistrarUsuario = new FormRegistrarUsuario();

            
            var resultado = formRegistrarUsuario.ValidarYRegistrarUsuario(contextoMock.Object, "correo@ejemplo.com", "contraseña", "contraseña");

            
            Assert.IsTrue(resultado);


        }

        [TestMethod]
        public void ValidarRegistroUsuario_RetornaFalse_SiUsuarioYaExiste()
        {
         
            var contextoMock = new Mock<ConexionDB>();

            
            var usuariosExistente = new List<Clientes>
    {
        new Clientes { Email = "usuario_existente@ejemplo.com" }
    };
            var clientesMock = new Mock<DbSet<Clientes>>();
            clientesMock.As<IQueryable<Clientes>>().Setup(m => m.Provider).Returns(usuariosExistente.AsQueryable().Provider);
            clientesMock.As<IQueryable<Clientes>>().Setup(m => m.Expression).Returns(usuariosExistente.AsQueryable().Expression);
            clientesMock.As<IQueryable<Clientes>>().Setup(m => m.ElementType).Returns(usuariosExistente.AsQueryable().ElementType);
            clientesMock.As<IQueryable<Clientes>>().Setup(m => m.GetEnumerator()).Returns(() => usuariosExistente.GetEnumerator());

            contextoMock.Setup(c => c.Set<Clientes>()).Returns(clientesMock.Object);

            var formRegistrarUsuario = new FormRegistrarUsuario();

            
            var resultado = formRegistrarUsuario.ValidarYRegistrarUsuario(contextoMock.Object, "usuario_existente@ejemplo.com", "contraseña", "contraseña");

            
            Assert.IsFalse(resultado);
        }


    }
}
