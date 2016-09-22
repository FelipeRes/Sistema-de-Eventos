using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sistema_de_Eventos;
using Sistema_de_Eventos.Modelo;
using Sistema_de_Eventos.Modelo.Controle;
using Sistema_de_Eventos.Modelo.Eventos;
using SistemaDeEventos.Modelo.Controle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Eventos.Tests {
    [TestClass()]
    public class UsuarioTests {
        [TestMethod()]
        public void teste_entrada_de_email() {
            try {
                Usuario user = FabricaUsuario.NovoUsuario("bla@gats", "123456").build();
            } catch {
                Assert.Fail();
            }
            
        }
        [TestMethod()]
        public void teste_entrada_de_senha_curta() {
            try {
                Usuario user = FabricaUsuario.NovoUsuario("bla@gats", "123456").build();
                Assert.Fail();
            } catch {
            }

        }
        [TestMethod()]
        public void teste_entrada_de_senha_longa() {
            try {
                Usuario user = FabricaUsuario.NovoUsuario("bla@gats", "123456").build();
            } catch {
                Assert.Fail();
            }

        }
    }
}