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
        public Atividade atividade = new Atividade("Bahia");
        Pessoa adm = new Pessoa();

        [TestMethod()]
        public void adicioar_colaborador_repetido() {
            Organizacao organizacao = new Organizacao(atividade, adm);
            Pessoa colaborador = new Pessoa();
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
            Organizacao organizacao = new Organizacao(atividade, colaborador);
            Assert.AreEqual(colaborador.Nome, organizacao.ResponsavelNome);
        }

        [TestMethod()]
        public void nome_dos_responsaveis() {
            Pessoa colaborador = new Pessoa("Felipe", 30, 0404004, "aaa@gemail");
            Pessoa p1 = new Pessoa("Jotaro", 30, 0404004, "aaa@gemail");
            Pessoa p2 = new Pessoa("Josuke", 30, 0404004, "aaa@gemail");
            Pessoa p3 = new Pessoa("Jonhantan", 30, 0404004, "aaa@gemail");
            Organizacao organizacao = new Organizacao(atividade, colaborador);
            organizacao.AdicionarColaborador(p1);
            organizacao.AdicionarColaborador(p2);
            organizacao.AdicionarColaborador(p3);
            Assert.AreEqual("Felipe\nJotaro\nJosuke\nJonhantan\n", organizacao.NomeColaboradores);
        }

        [TestMethod()]
        public void remover_colaborador_inexistente() {
            Organizacao organizacao = new Organizacao(atividade, adm);
            Pessoa colaborador = new Pessoa();
            organizacao.AdicionarColaborador(colaborador);
            try {
                organizacao.RemoverColaborador(colaborador);
                Assert.Fail();
            } catch {
            }
        }
        
    }
}