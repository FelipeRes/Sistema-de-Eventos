using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sistema_de_Eventos;
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
            inscricao = new Inscricao(evento, new Pessoa());
            Atividade atividade = new Atividade("Lugar");
            evento.Atividades.Adicionar(atividade);
            atividade.Preco = 45;
            Atividade atividade2 = new Atividade("Lugar");
            evento.Atividades.Adicionar(atividade2);
            atividade2.Preco = 45;
            inscricao.AdicionarAtividade(atividade);
            inscricao.AdicionarAtividade(atividade2);
            Assert.AreEqual(90, inscricao.ValorTotal);
        }
        [TestMethod]
        public void adicionar_atividade_repetida_na_inscricao() {
            inscricao = new Inscricao(evento, new Pessoa());
            Atividade palestra = new Atividade("Lugar");
            evento.Atividades.Adicionar(palestra);
            Atividade atividade2 = new Atividade("Lugar");
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
            inscricao = new Inscricao(evento, new Pessoa());
            Atividade palestra = new Atividade("Lugar");
            evento.Atividades.Adicionar(palestra);
            try {
                inscricao.RemoverAtividade(new Atividade("Lugar"));
                Assert.Fail();
            } catch (Exception e) {
                Assert.IsTrue(true);
            }
        }
        [TestMethod]
        public void valor_da_inscricao_com_cupom_de_desconto_para_estudante() {
            inscricao = new Inscricao(evento, new Pessoa());
            Atividade atividade = new Atividade("Lugar");
            evento.Atividades.Adicionar(atividade);
            atividade.Preco = 90;
            inscricao.AdicionarAtividade(atividade);
            inscricao.AdicionarCuponDeDesconto(new Cupom(new DescontoPorcentagem(50)));
            Assert.AreEqual(45, inscricao.ValorComDesconto);
        }
        [TestMethod]
        public void adicionar_atividade_apos_finalizar_inscricao() {
            inscricao = new Inscricao(evento, new Pessoa());
            Atividade atividade1 = new Atividade("Lugar");
            evento.Atividades.Adicionar(atividade1);
            Atividade atividade2 = new Atividade("Lugar");
            evento.Atividades.Adicionar(atividade2);
            Atividade atividade3 = new Atividade("Lugar");
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
            inscricao = new Inscricao(evento, new Pessoa());
            Atividade atividade = new Atividade("Lugar");
            evento.Atividades.Adicionar(atividade);
            atividade.Preco = 90;
            inscricao.AdicionarAtividade(atividade);
            inscricao.AdicionarCuponDeDesconto(new Cupom(new DescontoPorcentagem(90)));
            Assert.AreEqual(9, inscricao.ValorComDesconto);
        }
        [TestMethod]
        public void adiciona_inscrito_repetido() {
            inscricao = new Inscricao(evento, new Pessoa());
            Atividade atividade = new Atividade("Lugar");
            evento.Atividades.Adicionar(atividade);
            Inscricao jose = new Inscricao(evento, new Pessoa());
            atividade.AdicionarInscritos(jose);
            atividade.AdicionarInscritos(jose);
            Assert.AreEqual(atividade.QuantidadeDeInscritos, 1);
        }
        [TestMethod]
        public void inscrever_em_atividade_que_nao_pertece_ao_evento() {
            inscricao = new Inscricao(evento, new Pessoa());
            Atividade atividade = new Atividade("Lugar");
            evento.Atividades.Adicionar(atividade);
            Evento evento2 = new Evento();
            Inscricao inscricaoDeEvento2 = new Inscricao(evento2, new Pessoa());
            try {
                inscricaoDeEvento2.AdicionarAtividade(atividade);
                Assert.Fail();
            }catch{

            }
            
        }
        [TestMethod]
        public void inscrever_em_evento_ja_fechado() {
            inscricao = new Inscricao(evento, new Pessoa());
            Atividade atividade = new Atividade("Lugar");
            evento.Atividades.Adicionar(atividade);
            evento.Estado = EstadoDoEvento.Encerrado;
            try {
                inscricao.AdicionarAtividade(atividade);
                Assert.Fail();
            } catch {

            }

        }
        [TestMethod]
        public void inscrever_em_evento_aberto() {
            inscricao = new Inscricao(evento, new Pessoa());
            Atividade atividade = new Atividade("Lugar");
            evento.Atividades.Adicionar(atividade);
            evento.Estado = EstadoDoEvento.Aberto;
            try {
                inscricao.AdicionarAtividade(atividade);
                Assert.Fail();
            } catch {

            }
        }
    }
}
