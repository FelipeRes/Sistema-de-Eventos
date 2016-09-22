using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sistema_de_Eventos.Modelo;
using Sistema_de_Eventos.Modelo.Controle;
using Sistema_de_Eventos.Modelo.Eventos;
using SistemaDeEventos.Modelo.Controle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Eventos.Modelo.Tests {
    [TestClass()]
    public class OrganizacaoTests {
        public Atividade atividade = FabricarAtividade.Simples("Bahia");
        Usuario adm = FabricaUsuario.NovoUsuario("bla@gats", "123456").build();

        [TestMethod()]
        public void adicioar_colaborador_repetido() {
            Organizacao organizacao = new Organizacao();
            organizacao.Organizador = adm;
            organizacao.AtividadeOrganizacao = atividade;
            Usuario colaborador = FabricaUsuario.NovoUsuario("bla@gats", "123456").build();
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
            Usuario user = FabricaUsuario.NovoUsuario("bla@gats", "123456").build();
            user.Pessoa = colaborador;
            Organizacao organizacao = new Organizacao();
            organizacao.AtividadeOrganizacao = atividade;
            organizacao.Organizador = user;
            Assert.AreEqual(colaborador.Nome, organizacao.ResponsavelNome);
        }

        [TestMethod()]
        public void nome_dos_responsaveis() {
            Pessoa colaborador = Pessoa.BuildNome("Felipe").Idade(30).CPF(0404004).build();
            Pessoa p1 = Pessoa.BuildNome("Jotaro").Idade(30).CPF(0404004).build();
            Pessoa p2 = Pessoa.BuildNome("Josuke").Idade(30).CPF(0404004).build();
            Pessoa p3 = Pessoa.BuildNome("Jonhantan").Idade(30).CPF(0404004).build();
            Usuario user = FabricaUsuario.NovoUsuario("bla@gats", "123456").build();
            user.Pessoa = colaborador;
            Usuario user1 = FabricaUsuario.NovoUsuario("bla@gats", "123456").build();
            user1.Pessoa = p1;
            Usuario user2 = FabricaUsuario.NovoUsuario("bla@gats", "123456").build();
            user2.Pessoa = p2;
            Usuario user3 = FabricaUsuario.NovoUsuario("bla@gats", "123456").build();
            user3.Pessoa = p3;
            Organizacao organizacao = new Organizacao();
            organizacao.AtividadeOrganizacao = atividade;
            organizacao.Organizador = user;
            organizacao.AdicionarColaborador(user1);
            organizacao.AdicionarColaborador(user2);
            organizacao.AdicionarColaborador(user3);
            Assert.AreEqual("Felipe\nJotaro\nJosuke\nJonhantan\n", organizacao.NomeColaboradores);
        }

        [TestMethod()]
        public void remover_colaborador_inexistente() {
            Organizacao organizacao = new Organizacao();
            organizacao.AtividadeOrganizacao = atividade;
            organizacao.Organizador = adm;
            Pessoa colaborador = new Pessoa();
            Usuario user = FabricaUsuario.NovoUsuario("bla@gats", "123456").build();
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