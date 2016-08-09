using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sistema_de_Eventos.Modelo;
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
            EspacoFisico sala = new Sala(10, "DGTI");
            Predio predio = new Predio("IFPI", sala);
            Assert.AreEqual("IFPI", predio.Nome);
        }
        [TestMethod()]
        public void adicionar_localidades_ao_predio() {
            EspacoFisico sala1 = new Sala(10, "B3");
            EspacoFisico sala2 = new Sala(10, "B4");
            Predio predio = new Predio("IFPI", sala1);
            predio.AdicionarInterior(sala2);
            Assert.AreEqual(20, predio.Capacidade);
        }
        [TestMethod()]
        public void adicionar_localidades_repetida() {
            EspacoFisico sala1 = new Sala(10, "B3");
            Predio predio = new Predio("IFPI", sala1);
            try{
                predio.AdicionarInterior(sala1);
                Assert.Fail();
            } catch (Exception e) {
                Assert.IsTrue(true);
            }
        }
        [TestMethod()]
        public void adicionar_predio_ao_predio() {
            EspacoFisico sala1 = new Sala(15, "B3");
            EspacoFisico predio = new Predio("Predio A", sala1);
            Predio ifpiComleto = new Predio("IFPI", predio);
            Assert.AreEqual(15, ifpiComleto.Capacidade);
        }
    }
}