using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sistema_de_Eventos;
using Sistema_de_Eventos.AtividadePack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Eventos {
    [TestClass()]
    public class CupomTests {
        [TestMethod()]
        public void testando_se_cupom_esta_invalido() {

            Evento evento = FabricarAtividade.Evento();
            Atividade atividade = FabricarAtividade.Simples("Lugar");
            evento.Atividades.Adicionar(atividade);
            atividade.Preco = 10;
            Inscricao inscricao = new Inscricao(new Usuario("bla@gats", "sou"));
            inscricao.AdicionarAtividade(atividade);
            Cupom cumpom1 = FabricarCupom.DescontoPorcentagem(50);
            inscricao.AdicionarCuponDeDesconto(cumpom1);
            inscricao.FinalizarInscricao();
            
            Evento evento2 = FabricarAtividade.Evento();
            Atividade atividade2 = FabricarAtividade.Simples("Lugar");
            evento2.Atividades.Adicionar(atividade);
            atividade2.Preco = 30;
            Inscricao inscricao2 = new Inscricao(new Usuario("bla@gats", "sou"));
            try {
                inscricao2.AdicionarCuponDeDesconto(cumpom1);
                Assert.Fail();
            } catch {

            }
        }
        [TestMethod()]
        public void criando_combos_cupom() {
            Cupom cupom1 = FabricarCupom.DescontoPorcentagem(50);
            Cupom cupom2 = FabricarCupom.DescontoPorcentagem(10);
            cupom1.AdicionarCupom(cupom2);
            Evento evento = FabricarAtividade.Evento();
            Atividade atividade = FabricarAtividade.Simples("Lugar");
            evento.Atividades.Adicionar(atividade);
            atividade.Preco = 100;
            Inscricao inscricao = new Inscricao(new Usuario("bla@gats", "sou"));
            inscricao.AdicionarAtividade(atividade);
            inscricao.AdicionarCuponDeDesconto(cupom1);
            Assert.AreEqual(45, inscricao.ValorComDesconto);
        }
    }
}