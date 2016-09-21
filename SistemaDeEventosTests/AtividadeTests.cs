using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sistema_de_Eventos;
using Sistema_de_Eventos.Modelo.Espaco;
using Sistema_de_Eventos.Modelo.Eventos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Eventos.Tests {
    [TestClass()]
    public class AtividadeTests {
        public Evento evento = FabricarAtividade.Evento();
        [TestMethod()]
        public void horaio_da_ativdade_Inicio_hoje() {
            Atividade atividade = FabricarAtividade.Simples("Lugar");
            atividade.DataInicio = DateTime.Today;
            Assert.AreEqual(atividade.DataInicio, DateTime.Today);
        }
        [TestMethod()]
        public void horaio_da_ativdade_Inicio_as_dez_da_manha() {
            Atividade atividade = FabricarAtividade.Simples("Lugar");
            atividade.DataInicio = new DateTime(2016, 7, 18, 10, 30, 0);
            Assert.AreEqual(atividade.DataInicio.Hour, 10);
        }
        [TestMethod()]
        public void horaio_da_ativdade_Saida_as_23_da_noite() {
            Atividade atividade = FabricarAtividade.Simples("Lugar");
            atividade.DataInicio = new DateTime(2016, 7, 18, 23, 30, 0);
            Assert.AreEqual(atividade.DataInicio.Hour, 23);
        }
        [TestMethod()]
        public void horaio_da_ativdade_as_38_horas_que_nao_existe() {
            Atividade atividade = FabricarAtividade.Simples("Lugar");
            try {
                atividade.DataInicio = new DateTime(2016, 7, 18, 38, 30, 0);
                Assert.Fail();
            } catch {
                
            }
        }
        
        [TestMethod()]
        public void adicionar_espaco_fisico() {
            Atividade atividade = FabricarAtividade.Simples("Lugar");
            atividade.Lugar = FabricarEspaco.Simples(10,"Outro Lugar");
            Assert.AreEqual("Outro Lugar", atividade.Lugar.Nome);
        }
    }
    
}