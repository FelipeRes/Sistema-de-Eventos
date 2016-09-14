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
        Usuario adm = new Usuario("bla@gats", "1234567");

        [TestMethod()]
        public void adicioar_colaborador_repetido() {
            Organizacao organizacao = new Organizacao(atividade, adm);
            Usuario colaborador = new Usuario("bla@gats", "123456");
            organizacao.AdicionarColaborador(colaborador);
            try {
                organizacao.AdicionarColaborador(colaborador);
                Assert.Fail();
            } catch {
            }
        }
        [TestMethod()]
        public void nome_do_responsavel() {
            Pessoa colaborador = Pessoa.BuildNome("Felipe").Idade(30).CPF(0404004).build();
            Usuario user = new Usuario("bla@gats", "123456");
            user.Pessoa = colaborador;
            Organizacao organizacao = new Organizacao(atividade, user);
            Assert.AreEqual(colaborador.Nome, organizacao.ResponsavelNome);
        }

        [TestMethod()]
        public void nome_dos_responsaveis() {
            Pessoa colaborador = Pessoa.BuildNome("Felipe").Idade(30).CPF(0404004).build();
            Pessoa p1 = Pessoa.BuildNome("Jotaro").Idade(30).CPF(0404004).build();
            Pessoa p2 = Pessoa.BuildNome("Josuke").Idade(30).CPF(0404004).build();
            Pessoa p3 = Pessoa.BuildNome("Jonhantan").Idade(30).CPF(0404004).build();
            Usuario user = new Usuario("bla@gats", "123456");
            user.Pessoa = colaborador;
            Usuario user1 = new Usuario("bla@gats", "123456");
            user1.Pessoa = p1;
            Usuario user2 = new Usuario("bla@gats", "123456");
            user2.Pessoa = p2;
            Usuario user3 = new Usuario("bla@gats", "123456");
            user3.Pessoa = p3;
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
            Usuario user = new Usuario("bla@gats", "123456");
            user.Pessoa = colaborador;
            organizacao.AdicionarColaborador(user);
            try {
                organizacao.RemoverColaborador(user);
                Assert.Fail();
            } catch {
            }
        }
        
    }
}