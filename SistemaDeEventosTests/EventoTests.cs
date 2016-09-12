﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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
            Atividade atividade1 = new Atividade("Lugar");
            Atividade atividade2 = new Atividade("Lugar");
            Atividade atividade3 = new Atividade("Lugar");
            Atividade atividade4 = new Atividade("Lugar");
            Atividade atividade5 = new Atividade("Lugar");
            evento.Atividades.Adicionar(atividade1);
            evento.Atividades.Adicionar(atividade2);
            evento.Atividades.Adicionar(atividade3);
            evento.Atividades.Adicionar(atividade4);
            evento.Atividades.Adicionar(atividade5);
            evento.Atividades.Remover(atividade1);
            evento.Atividades.Remover(atividade2);
            Assert.AreEqual(3, evento.Atividades.Quantidade);
        }
        [TestMethod()]
        public void adicao_de_atividade_pelo_contrutor_da_atividade() {
            Atividade atividade1 = new Atividade("Lugar");
            Atividade atividade2 = new Atividade("Lugar");
            Atividade atividade3 = new Atividade("Lugar");
            evento.Atividades.Adicionar(atividade1);
            evento.Atividades.Adicionar(atividade2);
            evento.Atividades.Adicionar(atividade3);
            Assert.AreEqual(3, evento.Atividades.Quantidade);
        }
        [TestMethod()]
        public void adicionar_local_ao_evento() {
            Atividade atividade1 = new Atividade("Lugar");
            Atividade atividade2 = new Atividade("Lugar");
            Atividade atividade3 = new Atividade("Lugar");
            evento.Atividades.Adicionar(atividade1);
            evento.Atividades.Adicionar(atividade2);
            evento.Atividades.Adicionar(atividade3);
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
        public void modificando_atividade_principal_do_evento() {
            evento.Nome = "Arduiono Day";
            Assert.AreEqual(evento.Nome, "Arduiono Day");
        }
        [TestMethod()]
        public void inscricao_em_atividade_principal() {
            evento.Nome = "Arduiono Day";
            evento.Preco = 30;
            Inscricao inscricao = new Inscricao(evento, new Pessoa());
            inscricao.FinalizarInscricao();
            Assert.AreEqual(inscricao.ValorTotal, 30);
        }
        [TestMethod()]
        public void confirmacao_de_inscricao() {
            evento.Nome = "Arduiono Day";
            evento.Preco = 30;
            Inscricao inscricao = new Inscricao(evento, new Pessoa());
            Inscricao inscricao2 = new Inscricao(evento, new Pessoa());
            Assert.AreEqual(evento.QuantidadeDeInscritos, 2);
        }
    }
}