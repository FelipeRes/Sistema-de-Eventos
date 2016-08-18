using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sistema_de_Eventos.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Eventos.Modelo.Tests {
    [TestClass()]
    public class OrganizacaoTests {

        public Evento evento = new Evento();
        Usuario adm = new Usuario();

        [TestMethod()]
        public void adicioar_colaborador_repetido() {
            Organizacao organizacao = new Organizacao(evento, adm);
            Usuario colaborador = new Usuario();
            organizacao.AdicionarColaborador(colaborador);
            try {
                organizacao.AdicionarColaborador(colaborador);
                Assert.Fail();
            } catch {
            }
        }

        [TestMethod()]
        public void remover_colaborador_inexistente() {
            Organizacao organizacao = new Organizacao(evento, adm);
            Usuario colaborador = new Usuario();
            organizacao.AdicionarColaborador(colaborador);
            try {
                organizacao.RemoverColaborador(colaborador);
                Assert.Fail();
            } catch {
            }
        }
        
    }
}