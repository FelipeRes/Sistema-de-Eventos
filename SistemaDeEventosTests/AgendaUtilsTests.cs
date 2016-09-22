using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sistema_de_Eventos.Modelo;
using Sistema_de_Eventos.Modelo.Espaco;
using Sistema_de_Eventos.Modelo.Eventos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Eventos.Modelo.Tests {
    [TestClass()]
    public class AgendaUtilsTests {
        Evento evento = FabricarAtividade.Evento();
        [TestMethod()]
        public void formacao_de_quadro_de_horarios() {
            evento.Nome = "GGJ";
            evento.DataInicio = new DateTime(2016, 1, 27, 17, 0, 0);
            evento.DataFim = new DateTime(2016, 1, 29, 17, 0, 0);
            Assert.AreEqual("\nEvento: GGJ - Inicio: 27/01/2016 17:00:00 - Fim: 29/01/2016 17:00:00", evento.Agenda);
        }
        [TestMethod()]
        public void quadro_de_horarios_para_varias_atividades() {
            evento.Nome = "GGJ";
            evento.DataInicio = new DateTime(2016, 1, 27, 17, 0, 0);
            evento.DataFim = new DateTime(2016, 1, 29, 17, 0, 0);
            Atividade atividade2 = FabricarAtividade.Simples("MiniCurso");
            evento.Atividades.Adicionar(atividade2);
            atividade2.DataInicio = new DateTime(2016, 1, 27, 18, 0, 0);
            atividade2.DataFim = new DateTime(2016, 1, 27, 22, 0, 0);
            Assert.AreEqual("\nEvento: GGJ - Inicio: 27/01/2016 17:00:00 - Fim: 29/01/2016 17:00:00\nMiniCurso - Inicio: 27/01/2016 18:00:00 - Fim: 27/01/2016 22:00:00", evento.Agenda);
        }
        [TestMethod()]
        public void saber_se_a_agenda_esta_ordenada() {
            evento.Nome = "GGJ";
            evento.DataInicio = new DateTime(2016, 1, 27, 17, 0, 0);
            evento.DataFim = new DateTime(2016, 1, 29, 17, 0, 0);
            Atividade atividade2 = FabricarAtividade.Simples("MiniCurso");
            evento.Atividades.Adicionar(atividade2);
            atividade2.DataInicio = new DateTime(2015, 1, 21, 13, 0, 0);
            atividade2.DataFim = new DateTime(2015, 1, 21, 17, 0, 0);
            Assert.AreEqual("\nEvento: GGJ - Inicio: 27/01/2016 17:00:00 - Fim: 29/01/2016 17:00:00\nMiniCurso - Inicio: 21/01/2015 13:00:00 - Fim: 21/01/2015 17:00:00", evento.Agenda);
        }
        [TestMethod()]
        public void quadro_de_horarios_por_espaco_fisico() {
            EspacoFisico espaco = FabricarEspaco.Simples(12,"PredioB");
            evento.Nome = "GGJ";
            evento.DataInicio = new DateTime(2016, 1, 27, 17, 0, 0);
            evento.DataFim = new DateTime(2016, 1, 29, 17, 0, 0);
            evento.Lugar = espaco;
            Atividade atividade2 = FabricarAtividade.Simples("MiniCurso");
            evento.Atividades.Adicionar(atividade2);
            atividade2.DataInicio = new DateTime(2015, 1, 21, 13, 0, 0);
            atividade2.DataFim = new DateTime(2015, 1, 21, 17, 0, 0);
            atividade2.Lugar = espaco;
            Assert.AreEqual("\nEvento: GGJ - Inicio: 27/01/2016 17:00:00 - Fim: 29/01/2016 17:00:00\nMiniCurso - Inicio: 21/01/2015 13:00:00 - Fim: 21/01/2015 17:00:00", evento.Agenda);
        }

        [TestMethod()]
        public void quadro_de_horarios_com_atividades_complementares() {
            EspacoFisico espaco = FabricarEspaco.Simples(12, "PredioB");
            evento.Nome = "GGJ";
            evento.DataInicio = new DateTime(2016, 1, 27, 17, 0, 0);
            evento.DataFim = new DateTime(2016, 1, 29, 17, 0, 0);
            evento.Lugar = espaco;
            Atividade atividade2 = FabricarAtividade.Complementar("MiniCurso");
            evento.Atividades.Adicionar(atividade2);
            atividade2.DataInicio = new DateTime(2015, 1, 21, 13, 0, 0);
            atividade2.DataFim = new DateTime(2015, 1, 21, 17, 0, 0);
            atividade2.Lugar = espaco;
            Assert.AreEqual("\nEvento: GGJ - Inicio: 27/01/2016 17:00:00 - Fim: 29/01/2016 17:00:00\nMiniCurso - Inicio: 21/01/2015 13:00:00 - Fim: 21/01/2015 17:00:00", evento.Agenda);
        }
    }
}