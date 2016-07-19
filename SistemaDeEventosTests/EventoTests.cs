using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sistema_de_Eventos;
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
            evento.AdicionarAtividade(new Atividade(evento, 3));
            evento.AdicionarAtividade(new Atividade(evento, 3));
            evento.AdicionarAtividade(new Atividade(evento, 3));
            evento.AdicionarAtividade(new Atividade(evento, 3));
            evento.AdicionarAtividade(new Atividade(evento, 3));
            evento.RemoverAtividade(evento.ListaDeAtividades[0]);
            evento.RemoverAtividade(evento.ListaDeAtividades[0]);
            Assert.AreEqual(3, evento.ListaDeAtividades.Count);
        }
        [TestMethod()]
        public void adicao_de_atividade_pelo_contrutor_da_atividade() {
            Atividade atividade1 = new Atividade(evento, 3);
            Atividade atividade2 = new Atividade(evento, 3);
            Atividade atividade3 = new Atividade(evento, 3);
            Assert.AreEqual(3, evento.ListaDeAtividades.Count);
        }


    }
}