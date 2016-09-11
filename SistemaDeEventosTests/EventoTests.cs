using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sistema_de_Eventos;
using Sistema_de_Eventos.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Eventos.Tests {
    [TestClass()]
    public class EventoTests {
        Evento evento = new Evento();
        [TestMethod()]
        public void quantidade_de_atividades_no_evento() {
            Atividade atividade1 = new Atividade("Lugar");
            Atividade atividade2 = new Atividade("Lugar");
            Atividade atividade3 = new Atividade("Lugar");
            Atividade atividade4 = new Atividade("Lugar");
            Atividade atividade5 = new Atividade("Lugar");
            evento.AdicionarAtividade(atividade1);
            evento.AdicionarAtividade(atividade2);
            evento.AdicionarAtividade(atividade3);
            evento.AdicionarAtividade(atividade4);
            evento.AdicionarAtividade(atividade5);
            evento.RemoverAtividade(atividade1);
            evento.RemoverAtividade(atividade2);
            Assert.AreEqual(4, evento.QuantidadeDeAtividades);
        }
        [TestMethod()]
        public void adicao_de_atividade_pelo_contrutor_da_atividade() {
            Atividade atividade1 = new Atividade("Lugar");
            Atividade atividade2 = new Atividade("Lugar");
            Atividade atividade3 = new Atividade("Lugar");
            evento.AdicionarAtividade(atividade1);
            evento.AdicionarAtividade(atividade2);
            evento.AdicionarAtividade(atividade3);
            Assert.AreEqual(4, evento.QuantidadeDeAtividades);
        }
        [TestMethod()]
        public void adicionar_local_ao_evento() {
            Atividade atividade1 = new Atividade("Lugar");
            Atividade atividade2 = new Atividade("Lugar");
            Atividade atividade3 = new Atividade("Lugar");
            evento.AdicionarAtividade(atividade1);
            evento.AdicionarAtividade(atividade2);
            evento.AdicionarAtividade(atividade3);
            EspacoFisico sala = new EspacoSimples(10, "B3");
            EspacoFisico espaco = new EspacoComposto("Predio B", sala);
            evento.AtividadePrinciapal.Lugar = espaco;
            Assert.AreEqual(evento.AtividadePrinciapal.Lugar.Nome, "Predio B - B3" );
        }
        [TestMethod()]
        public void saber_se_evento_tem_espaco_vazio() {
            Assert.AreEqual(evento.AtividadePrinciapal.Lugar.Nome, "vazio");
        }
        [TestMethod()]
        public void modificando_atividade_principal_do_evento() {
            evento.AtividadePrinciapal.Nome = "Arduiono Day";
            Assert.AreEqual(evento.AtividadePrinciapal.Nome, "Arduiono Day");
        }
        [TestMethod()]
        public void inscricao_em_atividade_principal() {
            evento.AtividadePrinciapal.Nome = "Arduiono Day";
            evento.AtividadePrinciapal.Preco = 30;
            Inscricao inscricao = new Inscricao(evento, new Pessoa());
            inscricao.FinalizarInscricao();
            Assert.AreEqual(inscricao.ValorTotal, 30);
        }
        [TestMethod()]
        public void confirmacao_de_inscricao() {
            evento.AtividadePrinciapal.Nome = "Arduiono Day";
            evento.AtividadePrinciapal.Preco = 30;
            Inscricao inscricao = new Inscricao(evento, new Pessoa());
            Inscricao inscricao2 = new Inscricao(evento, new Pessoa());
            Assert.AreEqual(evento.AtividadePrinciapal.QuantidadeDeInscritos, 2);
        }
    }
}