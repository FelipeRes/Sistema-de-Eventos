using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sistema_de_Eventos.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Eventos.Modelo.Tests {
    [TestClass()]
    public class AgendaUtilsTests {
        Evento evento = new Evento();
        [TestMethod()]
        public void formacao_de_quadro_de_horarios() {
            evento.AtividadePrinciapal.Nome = "GGJ";
            evento.AtividadePrinciapal.DataInicio = new DateTime(2016, 1, 27, 17, 0, 0);
            evento.AtividadePrinciapal.DataFim = new DateTime(2016, 1, 29, 17, 0, 0);
            AgendaUtils.QuadroDeHorariosDoEvento(evento);
            Assert.AreEqual("\nGGJ - Inicio: 27/01/2016 17:00:00 - Fim: 29/01/2016 17:00:00\n", AgendaUtils.QuadroDeHorariosDoEvento(evento));
        }
        [TestMethod()]
        public void quadro_de_horarios_para_varias_atividades() {
            evento.AtividadePrinciapal.Nome = "GGJ";
            evento.AtividadePrinciapal.DataInicio = new DateTime(2016, 1, 27, 17, 0, 0);
            evento.AtividadePrinciapal.DataFim = new DateTime(2016, 1, 29, 17, 0, 0);
            Atividade atividade2 = new Atividade(evento, "MiniCurso");
            atividade2.DataInicio = new DateTime(2016, 1, 27, 18, 0, 0);
            atividade2.DataFim = new DateTime(2016, 1, 27, 22, 0, 0);
            AgendaUtils.QuadroDeHorariosDoEvento(evento);
            Assert.AreEqual("\nGGJ - Inicio: 27/01/2016 17:00:00 - Fim: 29/01/2016 17:00:00\nMiniCurso - Inicio: 27/01/2016 18:00:00 - Fim: 27/01/2016 22:00:00\n", AgendaUtils.QuadroDeHorariosDoEvento(evento));
        }
        [TestMethod()]
        public void saber_se_a_agenda_esta_ordenada() {
            evento.AtividadePrinciapal.Nome = "GGJ";
            evento.AtividadePrinciapal.DataInicio = new DateTime(2016, 1, 27, 17, 0, 0);
            evento.AtividadePrinciapal.DataFim = new DateTime(2016, 1, 29, 17, 0, 0);
            Atividade atividade2 = new Atividade(evento, "MiniCurso");
            atividade2.DataInicio = new DateTime(2015, 1, 21, 13, 0, 0);
            atividade2.DataFim = new DateTime(2015, 1, 21, 17, 0, 0);
            AgendaUtils.QuadroDeHorariosDoEvento(evento);
            Assert.AreEqual("\nMiniCurso - Inicio: 21/01/2015 13:00:00 - Fim: 21/01/2015 17:00:00\nGGJ - Inicio: 27/01/2016 17:00:00 - Fim: 29/01/2016 17:00:00\n", AgendaUtils.QuadroDeHorariosDoEvento(evento));
        }
    }
}