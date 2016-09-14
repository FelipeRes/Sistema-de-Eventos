using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sistema_de_Eventos;
using Sistema_de_Eventos.AtividadePack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeEventosTests {
    [TestClass]
    public class TesteDeInscricao {
        public Evento evento = new Evento();
        public Inscricao inscricao;
        [TestMethod]
        public void preco_da_inscricao() {
            inscricao = new Inscricao(new Usuario("bla@gats", "sou"));
            Atividade atividade = new AtividadeSimples("Lugar");
            evento.Atividades.Adicionar(atividade);
            atividade.Preco = 45;
            Atividade atividade2 = new AtividadeSimples("Lugar");
            evento.Atividades.Adicionar(atividade2);
            atividade2.Preco = 45;
            inscricao.AdicionarAtividade(atividade);
            inscricao.AdicionarAtividade(atividade2);
            Assert.AreEqual(90, inscricao.ValorTotal);
        }
        [TestMethod]
        public void adicionar_atividade_repetida_na_inscricao() {
            inscricao = new Inscricao(new Usuario("bla@gats", "sou"));
            Atividade palestra = new AtividadeSimples("Lugar");
            evento.Atividades.Adicionar(palestra);
            Atividade atividade2 = new AtividadeSimples("Lugar");
            evento.Atividades.Adicionar(atividade2);
            inscricao.AdicionarAtividade(atividade2);
            try {
                inscricao.AdicionarAtividade(atividade2);
                Assert.Fail();
            }catch(Exception e) {
                Assert.IsTrue(true);
            }
        }
        [TestMethod]
        public void remover_atividade_que_nao_existe_da_inscricao() {
            inscricao = new Inscricao(new Usuario("bla@gats", "sou"));
            Atividade palestra = new AtividadeSimples("Lugar");
            evento.Atividades.Adicionar(palestra);
            try {
                inscricao.RemoverAtividade(new AtividadeSimples("Lugar"));
                Assert.Fail();
            } catch (Exception e) {
                Assert.IsTrue(true);
            }
        }
        [TestMethod]
        public void valor_da_inscricao_com_cupom_de_desconto_para_estudante() {
            inscricao = new Inscricao(new Usuario("bla@gats", "sou"));
            Atividade atividade = new AtividadeSimples("Lugar");
            evento.Atividades.Adicionar(atividade);
            atividade.Preco = 90;
            inscricao.AdicionarAtividade(atividade);
            inscricao.AdicionarCuponDeDesconto(new Cupom(new DescontoPorcentagem(50)));
            Assert.AreEqual(45, inscricao.ValorComDesconto);
        }
        [TestMethod]
        public void adicionar_atividade_apos_finalizar_inscricao() {
            inscricao = new Inscricao(new Usuario("bla@gats", "sou"));
            Atividade atividade1 = new AtividadeSimples("Lugar");
            evento.Atividades.Adicionar(atividade1);
            Atividade atividade2 = new AtividadeSimples("Lugar");
            evento.Atividades.Adicionar(atividade2);
            Atividade atividade3 = new AtividadeSimples("Lugar");
            evento.Atividades.Adicionar(atividade3);
            inscricao.AdicionarAtividade(atividade1);
            inscricao.AdicionarAtividade(atividade2);
            //inscricao.AdicionarCuponDeDesconto(new Cupom(new DescontoPorcentagem(50)));
            inscricao.FinalizarInscricao();
            try {
                inscricao.AdicionarAtividade(atividade3);
                Assert.Fail();
            }catch(Exception e) {

            }
        }
        [TestMethod]
        public void valor_da_inscricao_com_cupom_de_desconto_por_porcentagem() {
            inscricao = new Inscricao(new Usuario("bla@gats", "sou"));
            Atividade atividade = new AtividadeSimples("Lugar");
            evento.Atividades.Adicionar(atividade);
            atividade.Preco = 90;
            inscricao.AdicionarAtividade(atividade);
            inscricao.AdicionarCuponDeDesconto(new Cupom(new DescontoPorcentagem(90)));
            Assert.AreEqual(9, inscricao.ValorComDesconto);
        }
        [TestMethod]
        public void adiciona_inscrito_repetido() {
            inscricao = new Inscricao(new Usuario("bla@gats", "sou"));
            Atividade atividade = new AtividadeSimples("Lugar");
            evento.Atividades.Adicionar(atividade);
            Inscricao jose = new Inscricao(new Usuario("bla@gats", "sou"));
            jose.AdicionarAtividade(atividade);
            jose.AdicionarAtividade(atividade);
            Assert.AreEqual(atividade.QuantidadeDeInscritos, 1);
        }
        [TestMethod]
        public void inscrever_em_atividade_que_nao_pertece_ao_evento() {
            inscricao = new Inscricao(new Usuario("bla@gats", "sou"));
            Atividade atividade = new AtividadeSimples("Lugar");
            evento.Atividades.Adicionar(atividade);
            Evento evento2 = new Evento();
            Inscricao inscricaoDeEvento2 = new Inscricao(new Usuario("bla@gats", "sou"));
            try {
                inscricaoDeEvento2.AdicionarAtividade(atividade);
                Assert.Fail();
            }catch{

            }
            
        }
        [TestMethod]
        public void inscrever_em_evento_ja_fechado() {
            inscricao = new Inscricao(new Usuario("bla@gats", "sou"));
            Atividade atividade = new AtividadeSimples("Lugar");
            evento.Atividades.Adicionar(atividade);
            evento.Estado = EstadoDaAtividade.Encerrado;
            try {
                inscricao.AdicionarAtividade(atividade);
                Assert.Fail();
            } catch {

            }

        }
        [TestMethod]
        public void inscrever_em_evento_aberto() {
            inscricao = new Inscricao(new Usuario("bla@gats", "sou"));
            Atividade atividade = new AtividadeSimples("Lugar");
            evento.Atividades.Adicionar(atividade);
            evento.Estado = EstadoDaAtividade.Aberto;
            try {
                inscricao.AdicionarAtividade(atividade);
                Assert.Fail();
            } catch {

            }
        }
        [TestMethod()]
        public void printar_nota_de_inscricao() {
            evento.Nome = "Arduino Day";
            evento.Preco = 30;
            Atividade atividade = new AtividadeSimples("Palestra");
            atividade.Preco = 30;
            evento.Atividades.Adicionar(atividade);
            Inscricao inscricao = new Inscricao(new Usuario("bla@gats", "sou"));
            inscricao.AdicionarAtividade(evento);
            Assert.AreEqual("\nArduino Day - Preco: 30\nPalestra - Preco: 30\nValor Total: 60\nValor Com Desconto: 60", inscricao.nota);
        }
        [TestMethod()]
        public void tentar_inscrever_em_atividade_complementar() {
            evento.Nome = "Arduino Day";
            evento.Preco = 30;
            Atividade atividade = new AtividadeDefault("Palestra");
            evento.Atividades.Adicionar(atividade);
            Inscricao inscricao = new Inscricao(new Usuario("bla@gats", "sou"));
            inscricao.AdicionarAtividade(evento);
            try {
                inscricao.AdicionarAtividade(atividade);
                Assert.Fail();
            } catch {

            }
        }
        [TestMethod()]
        public void verifica_se_atividade_complementar_esta_na_nota() {
            evento.Nome = "Arduino Day";
            evento.Preco = 30;
            Atividade atividade = new AtividadeDefault("Café");
            evento.Atividades.Adicionar(atividade);
            Inscricao inscricao = new Inscricao(new Usuario("bla@gats", "sou"));
            inscricao.AdicionarAtividade(evento);
            Assert.AreEqual("\nArduino Day - Preco: 30\nValor Total: 30\nValor Com Desconto: 30", inscricao.nota);
        }
    }
}
