using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sistema_de_Eventos;
using Sistema_de_Eventos.AtividadePack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Eventos.Tests {
    [TestClass()]
    public class UsuarioTests {
        [TestMethod()]
        public void atividade_que_participei() {
            Evento evento = FabricarAtividade.Evento();
            evento.Nome = "Feriadao";
            Atividade atividade = FabricarAtividade.Simples("Stand");
            Usuario user = new Usuario("algo@gmai.com", "123456");
            Inscricao inscricao = new Inscricao(user);
            inscricao.AdicionarAtividade(evento);
            inscricao.AdicionarAtividade(atividade);
            inscricao.FinalizarInscricao();
            Assert.AreEqual(user.AtividadeQueParticipei[0].Nome, evento.Nome);
        }
        [TestMethod()]
        public void minhas_inscricoes() {
            Evento evento = FabricarAtividade.Evento();
            evento.Nome = "Feriadao";
            Atividade atividade = FabricarAtividade.Simples("Stand");
            Pessoa pessoa = Pessoa.BuildNome("Felipe").build();
            Usuario user = new Usuario("algo@gmai.com", "123456");
            user.Pessoa = pessoa;
            Inscricao inscricao = new Inscricao(user);
            inscricao.AdicionarAtividade(evento);
            inscricao.AdicionarAtividade(atividade);
            inscricao.FinalizarInscricao();
            Assert.AreEqual(user.MinhasInscricoes[0].User.Pessoa.Nome, "Felipe");
        }
        [TestMethod()]
        public void teste_entrada_de_email() {
            try {
                Usuario user = new Usuario("algo@gmai.com", "123456");
            } catch {
                Assert.Fail();
            }
            
        }
        [TestMethod()]
        public void teste_entrada_de_senha_curta() {
            try {
                Usuario user = new Usuario("algo@gmai.com", "oo");
                Assert.Fail();
            } catch {
            }

        }
        [TestMethod()]
        public void teste_entrada_de_senha_longa() {
            try {
                Usuario user = new Usuario("algo@gmai.com", "1234567");
            } catch {
                Assert.Fail();
            }

        }
    }
}