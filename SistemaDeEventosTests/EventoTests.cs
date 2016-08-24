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
            Atividade atividade1 = new Atividade(evento, "Lugar", 3);
            Atividade atividade2 = new Atividade(evento, "Lugar", 3);
            Atividade atividade3 = new Atividade(evento, "Lugar", 3);
            Atividade atividade4 = new Atividade(evento, "Lugar", 3);
            Atividade atividade5 = new Atividade(evento, "Lugar", 3);
            evento.RemoverAtividade(evento.ListaDeAtividades[0]);
            evento.RemoverAtividade(evento.ListaDeAtividades[0]);
            Assert.AreEqual(4, evento.ListaDeAtividades.Count);
        }
        [TestMethod()]
        public void adicao_de_atividade_pelo_contrutor_da_atividade() {
            Atividade atividade1 = new Atividade(evento, "Lugar", 3);
            Atividade atividade2 = new Atividade(evento, "Lugar", 3);
            Atividade atividade3 = new Atividade(evento, "Lugar", 3);
            Assert.AreEqual(4, evento.ListaDeAtividades.Count);
        }
        [TestMethod()]
        public void adicionar_local_ao_evento() {
            Atividade atividade1 = new Atividade(evento, "Lugar", 3);
            Atividade atividade2 = new Atividade(evento, "Lugar", 3);
            Atividade atividade3 = new Atividade(evento, "Lugar", 3);
            EspacoFisico sala = new EspacoSimples(10, "B3");
            EspacoFisico espaco = new EspacoComposto("Predio B", sala);
            evento.Lugar = espaco;
            Assert.AreEqual(evento.Lugar.Nome, "Predio B - B3" );
        }
        [TestMethod()]
        public void saber_se_evento_tem_espaco_vazio() {
            Assert.AreEqual(evento.Lugar.Nome, "vazio");
        }
        [TestMethod()]
        public void alterar_atividade_principal_do_evento() {
            evento.AtividadePrinciapal.Nome = "Eventão";
            Assert.AreEqual("Eventão", evento.AtividadePrinciapal.Nome);
        }
        [TestMethod()]
        public void testar_quantidade_de_inscritos_no_evento_em_si() {
            Inscricao inscricaoDePessoa = new Inscricao(evento, new Pessoa());
            Inscricao inscricaoDePessoa2 = new Inscricao(evento, new Pessoa());
            Assert.AreEqual(2, evento.AtividadePrinciapal.QuantidadeDeInscritos);
        }
    }
}