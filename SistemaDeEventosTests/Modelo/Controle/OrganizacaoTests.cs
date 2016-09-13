using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sistema_de_Eventos.AtividadePack;
using Sistema_de_Eventos.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Eventos.Modelo.Tests {
    [TestClass()]
    public class OrganizacaoTests {
        public Atividade atividade = new AtividadeSimples("Bahia");
        Usuario adm = new Usuario();

        [TestMethod()]
        public void adicioar_colaborador_repetido() {
            Organizacao organizacao = new Organizacao(atividade, adm);
            Usuario colaborador = new Usuario();
            organizacao.AdicionarColaborador(colaborador);
            try {
                organizacao.AdicionarColaborador(colaborador);
                Assert.Fail();
            } catch {
            }
        }
        [TestMethod()]
        public void nome_do_responsavel() {
            Pessoa colaborador = new Pessoa("Felipe", 30, 0404004, "aaa@gemail");
            Usuario user = new Usuario(colaborador);
            Organizacao organizacao = new Organizacao(atividade, user);
            Assert.AreEqual(colaborador.Nome, organizacao.ResponsavelNome);
        }

        [TestMethod()]
        public void nome_dos_responsaveis() {
            Pessoa colaborador = new Pessoa("Felipe", 30, 0404004, "aaa@gemail");
            Pessoa p1 = new Pessoa("Jotaro", 30, 0404004, "aaa@gemail");
            Pessoa p2 = new Pessoa("Josuke", 30, 0404004, "aaa@gemail");
            Pessoa p3 = new Pessoa("Jonhantan", 30, 0404004, "aaa@gemail");
            Usuario user = new Usuario(colaborador);
            Usuario user1 = new Usuario(p1);
            Usuario user2 = new Usuario(p2);
            Usuario user3 = new Usuario(p3);
            Organizacao organizacao = new Organizacao(atividade, user);
            organizacao.AdicionarColaborador(user1);
            organizacao.AdicionarColaborador(user2);
            organizacao.AdicionarColaborador(user3);
            Assert.AreEqual("Felipe\nJotaro\nJosuke\nJonhantan\n", organizacao.NomeColaboradores);
        }

        [TestMethod()]
        public void remover_colaborador_inexistente() {
            Organizacao organizacao = new Organizacao(atividade, adm);
            Pessoa colaborador = new Pessoa();
            Usuario user = new Usuario(colaborador);
            organizacao.AdicionarColaborador(user);
            try {
                organizacao.RemoverColaborador(user);
                Assert.Fail();
            } catch {
            }
        }
        
    }
}