﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sistema_de_Eventos;
using Sistema_de_Eventos.Modelo;
using Sistema_de_Eventos.Modelo.Controle;
using Sistema_de_Eventos.Modelo.Cupons;
using Sistema_de_Eventos.Modelo.Eventos;
using SistemaDeEventos.Dominio.Modelo.Inscircoes;
using SistemaDeEventos.Modelo.Controle;
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
            Inscricao inscricao = FabricaInscricao.NovaInscricao();
            inscricao.User = FabricaUsuario.NovoUsuario("bla@gats", "123456").build();
            inscricao.AdicionarAtividade(atividade);
            Cupom cumpom1 = FabricarCupom.DescontoPorcentagem(50);
            inscricao.AdicionarCuponDeDesconto(cumpom1);
            inscricao.FinalizarInscricao();
            
            Evento evento2 = FabricarAtividade.Evento();
            Atividade atividade2 = FabricarAtividade.Simples("Lugar");
            evento2.Atividades.Adicionar(atividade);
            atividade2.Preco = 30;
            Inscricao inscricao2 = FabricaInscricao.NovaInscricao();
            inscricao.User = FabricaUsuario.NovoUsuario("bla@gats", "123456").build();
            try {
                inscricao2.AdicionarCuponDeDesconto(cumpom1);
                Assert.Fail();
            } catch {

            }
        }
        [TestMethod()]
        public void criando_combos_cupom() {
            Evento evento = FabricarAtividade.Evento();
            Atividade atividade = FabricarAtividade.Simples("Lugar");
            evento.Atividades.Adicionar(atividade);
            atividade.Preco = 100;
            Cupom cupom1 = FabricarCupom.DescontoPorcentagem(50);
            Cupom cupom2 = FabricarCupom.DescontoPorcentagem(10);
            cupom1.AdicionarCupom(cupom2);
            Inscricao inscricao = FabricaInscricao.NovaInscricao();
            inscricao.User = FabricaUsuario.NovoUsuario("bla@gats", "123456").build();
            inscricao.AdicionarAtividade(atividade);
            inscricao.AdicionarCuponDeDesconto(cupom1);
            Assert.AreEqual(45, inscricao.ValorComDesconto);
        }
        public void checando_se_cupom_para_estudante_funcioa() {
            Evento evento = FabricarAtividade.Evento();
            Atividade atividade = FabricarAtividade.Simples("Lugar");
            evento.Atividades.Adicionar(atividade);
            atividade.Preco = 100;
            Cupom cupom1 = FabricarCupom.DescontoAluno(50);
            Inscricao inscricao = FabricaInscricao.NovaInscricao();
            inscricao.User = FabricaUsuario.NovoUsuario("bla@gats", "123456").build();
            inscricao.AdicionarAtividade(atividade);
            inscricao.Participacao = TipoInscricao.PROFESSOR;
            inscricao.AdicionarCuponDeDesconto(cupom1);
            Assert.AreEqual(100, inscricao.ValorComDesconto);
        }
    }
}