using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sistema_de_Eventos.Modelo;
using Sistema_de_Eventos.Modelo.Espaco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Eventos.Modelo.Tests {
    [TestClass()]
    public class PredioTests {
        [TestMethod()]
        public void criaca_de_predio() {
            EspacoFisico sala = FabricarEspaco.Simples(10, "DGTI");
            EspacoComposto predio = FabricarEspaco.Composto("IFPI").AdicionarEspaco(sala).build();
            Assert.AreEqual("IFPI - DGTI", predio.Nome);
        }
        [TestMethod()]
        public void adicionar_localidades_ao_predio() {
            EspacoFisico sala1 = FabricarEspaco.Simples(10, "B3");
            EspacoFisico sala2 = FabricarEspaco.Simples(10, "B4");
            EspacoComposto predio = FabricarEspaco.Composto("IFPI").AdicionarEspaco(sala1).build();
            predio.AdicionarInterior(sala2);
            Assert.AreEqual(20, predio.Capacidade);
        }
        [TestMethod()]
        public void adicionar_localidades_repetida() {
            EspacoFisico sala1 = FabricarEspaco.Simples(10, "B3");
            EspacoComposto predio = FabricarEspaco.Composto("IFPI").AdicionarEspaco(sala1).build();
            try {
                predio.AdicionarInterior(sala1);
                Assert.Fail();
            } catch (Exception e) {
                Assert.IsTrue(true);
            }
        }
        [TestMethod()]
        public void adicionar_predio_ao_predio() {
            EspacoFisico sala1 = FabricarEspaco.Simples(15, "B3");
            EspacoFisico predio = FabricarEspaco.Composto("EspacoComposto A").AdicionarEspaco(sala1).build();
            EspacoFisico ifpiComleto = FabricarEspaco.Composto("IFPI").AdicionarEspaco(predio).build();
            Assert.AreEqual(15, ifpiComleto.Capacidade);
        }
        [TestMethod()]
        public void nome_total_do_predio() {
            EspacoFisico sala1 = FabricarEspaco.Simples(15, "B3");
            EspacoFisico sala2 = FabricarEspaco.Simples(15, "B4");
            EspacoComposto predio = FabricarEspaco.Composto("EspacoComposto A").AdicionarEspaco(sala1).build();
            predio.AdicionarInterior(sala2);
            Assert.AreEqual("EspacoComposto A - B3 - B4", predio.Nome);
        }
    }
}