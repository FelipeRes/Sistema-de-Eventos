using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sistema_de_Eventos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Eventos.Tests {
    [TestClass()]
    public class AtividadeTests {
        public Evento evento = new Evento();
        [TestMethod()]
        public void horaio_da_ativdade_Inicio_hoje() {
            Atividade atividade = new Atividade(new Evento(),"Lugar",3);
            atividade.DataInicio = DateTime.Today;
            Assert.AreEqual(atividade.DataInicio, DateTime.Today);
        }
        [TestMethod()]
        public void horaio_da_ativdade_Inicio_as_dez_da_manha() {
            Atividade atividade = new Atividade(new Evento(),"Lugar", 3);
            atividade.DataInicio = new DateTime(2016, 7, 18, 10, 30, 0);
            Assert.AreEqual(atividade.DataInicio.Hour, 10);
        }
        [TestMethod()]
        public void horaio_da_ativdade_Saida_as_23_da_noite() {
            Atividade atividade = new Atividade(new Evento(), "Lugar", 3);
            atividade.DataInicio = new DateTime(2016, 7, 18, 23, 30, 0);
            Assert.AreEqual(atividade.DataInicio.Hour, 23);
        }
        [TestMethod()]
        public void horaio_da_ativdade_as_38_horas_que_nao_existe() {
            Atividade atividade = new Atividade(new Evento(), "Lugar", 3);
            try {
                atividade.DataInicio = new DateTime(2016, 7, 18, 38, 30, 0);
                Assert.Fail();
            } catch {
                
            }
        }
        [TestMethod()]
        public void diminuir_quantidade_de_inscritos_quando_ja_tem_inscritos_pagos() {
            Atividade atividade = new Atividade(evento, "Lugar", 4);

            Inscricao joao = new Inscricao(evento, new Pessoa());
            joao.AdicionarAtividade(atividade);
            joao.FinalizarInscricao();

            Inscricao maria = new Inscricao(evento, new Pessoa());
            maria.AdicionarAtividade(atividade);
            maria.FinalizarInscricao();

            Inscricao jose = new Inscricao(evento, new Pessoa());
            jose.AdicionarAtividade(atividade);
            jose.FinalizarInscricao();

            Inscricao antonio = new Inscricao(evento, new Pessoa());
            antonio.AdicionarAtividade(atividade);
            antonio.FinalizarInscricao();
            
            atividade.QuantidadeMaximaPessoas = 2;
            Assert.AreEqual(4, atividade.QuantidadeMaximaPessoas);
        }
        [TestMethod()]
        public void diminuir_quantidade_de_inscritos_quando_ja_tem_inscritos_pagos_mas_nao_vai_diminuir_tanto() {
            Atividade atividade = new Atividade(evento, "Lugar", 5);

            Inscricao joao = new Inscricao(evento, new Pessoa());
            joao.AdicionarAtividade(atividade);
            joao.FinalizarInscricao();

            Inscricao maria = new Inscricao(evento, new Pessoa());
            maria.AdicionarAtividade(atividade);
            maria.FinalizarInscricao();

            Inscricao jose = new Inscricao(evento, new Pessoa());
            jose.AdicionarAtividade(atividade);
            jose.FinalizarInscricao();

            atividade.QuantidadeMaximaPessoas = 3;
            Assert.AreEqual(3, atividade.QuantidadeMaximaPessoas);
        }
        [TestMethod()]
        public void adicionar_espaco_fisico() {
            Atividade atividade = new Atividade(evento, "Lugar", 5);
            atividade.MudarEspacoFisico("Outro Lugar", 10);
            Assert.AreEqual("Outro Lugar", atividade.lugar.Nome);
        }
    }
    
}