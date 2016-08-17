﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sistema_de_Eventos;
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

            Evento evento = new Evento();
            Atividade atividade = new Atividade(evento,"Lugar", 3);
            atividade.Preco = 10;
            Inscricao inscricao = new Inscricao(evento, new Pessoa());
            inscricao.AdicionarAtividade(atividade);
            Cupom cumpom1 = new Cupom(new DescontoPorcentagem(50));
            inscricao.AdicionarCuponDeDesconto(cumpom1);
            inscricao.FinalizarInscricao();
            
            Evento evento2 = new Evento();
            Atividade atividade2 = new Atividade(evento2, "Lugar", 3);
            atividade2.Preco = 30;
            Inscricao inscricao2 = new Inscricao(evento2, new Pessoa());
            inscricao2.AdicionarAtividade(atividade2);
            try {
                inscricao2.AdicionarCuponDeDesconto(cumpom1);
                Assert.Fail();
            } catch {

            }
        }
        [TestMethod()]
        public void criando_combos_cupom() {
            Cupom cupom1 = new Cupom(new DescontoPorcentagem(50));
            Cupom cupom2 = new Cupom(new DescontoPorcentagem(10));
            cupom1.AdicionarCupom(cupom2);
            Evento evento = new Evento();
            Atividade atividade = new Atividade(evento, "Lugar", 3);
            atividade.Preco = 100;
            Inscricao inscricao = new Inscricao(evento, new Pessoa());
            inscricao.AdicionarAtividade(atividade);
            inscricao.AdicionarCuponDeDesconto(cupom1);
            Assert.AreEqual(45, inscricao.ValorComDesconto);
        }
    }
}