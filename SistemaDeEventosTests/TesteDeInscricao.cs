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
            Atividade atividade = new Atividade(evento, "Lugar", 3);
            atividade.Preco = 45;
            Atividade atividade2 = new Atividade(evento, "Lugar", 4);
            atividade2.Preco = 45;
            inscricao.AdicionarAtividade(atividade);
            inscricao.AdicionarAtividade(atividade2);
            Assert.AreEqual(90, inscricao.ValorTotal);
        }
        [TestMethod]
        public void adicionar_atividade_repetida_na_inscricao() {
            inscricao = new Inscricao(evento, new Pessoa());
            Atividade palestra = new Atividade(evento, "Lugar", 3);
            inscricao.AdicionarAtividade(new Atividade(evento, "Lugar", 3));
            try {
                inscricao.AdicionarAtividade(new Atividade(evento, "Lugar", 3));
                Assert.Fail();
            }catch(Exception e) {
                Assert.IsTrue(true);
            }
        }
        [TestMethod]
        public void remover_atividade_que_nao_existe_da_inscricao() {
            inscricao = new Inscricao(evento, new Pessoa());
            Atividade palestra = new Atividade(evento, "Lugar", 3);
            try {
                inscricao.RemoverAtividade(new Atividade(evento, "Lugar", 3));
                Assert.Fail();
            } catch (Exception e) {
                Assert.IsTrue(true);
            }
        }
        [TestMethod]
        public void valor_da_inscricao_com_cupom_de_desconto_para_estudante() {
            inscricao = new Inscricao(evento, new Pessoa());
            Atividade atividade = new Atividade(evento, "Lugar", 3);
            atividade.Preco = 90;
            inscricao.AdicionarAtividade(atividade);
            inscricao.AdicionarCuponDeDesconto(new Cupom(new DescontoPorcentagem(50)));
            Assert.AreEqual(45, inscricao.ValorComDesconto);
        }
        [TestMethod]
        public void adicionar_atividade_apos_finalizar_inscricao() {
            inscricao = new Inscricao(evento, new Pessoa());
            inscricao.AdicionarAtividade(new Atividade(evento, "Lugar", 3));
            inscricao.AdicionarAtividade(new Atividade(evento, "Lugar", 3));
            //inscricao.AdicionarCuponDeDesconto(new Cupom(new DescontoPorcentagem(50)));
            inscricao.FinalizarInscricao();
            try {
                inscricao.AdicionarAtividade(new Atividade(evento, "Lugar", 3));
                Assert.Fail();
            }catch(Exception e) {

            }
        }
        [TestMethod]
        public void exceder_numero_maxio_de_inscritos() {
            inscricao = new Inscricao(evento, new Pessoa());
            Atividade atividade = new Atividade(evento, "Lugar", 3);
            Inscricao inscrito1 = new Inscricao(evento, new Pessoa());
            inscrito1.AdicionarAtividade(atividade);
            Inscricao inscrito2 = new Inscricao(evento, new Pessoa());
            inscrito2.AdicionarAtividade(atividade);
            Inscricao inscrito3 = new Inscricao(evento, new Pessoa());
            inscrito3.AdicionarAtividade(atividade);
            Inscricao inscrito4 = new Inscricao(evento, new Pessoa());
            inscrito4.AdicionarAtividade(atividade);
            Assert.AreEqual(atividade.QuantidadeMaximaPessoas, atividade.QuantidadeDeInscritos);
        }
        [TestMethod]
        public void valor_da_inscricao_com_cupom_de_desconto_por_porcentagem() {
            inscricao = new Inscricao(evento, new Pessoa());
            Atividade atividade = new Atividade(evento, "Lugar", 3);
            atividade.Preco = 90;
            inscricao.AdicionarAtividade(atividade);
            inscricao.AdicionarCuponDeDesconto(new Cupom(new DescontoPorcentagem(90)));
            Assert.AreEqual(9, inscricao.ValorComDesconto);
        }
        [TestMethod]
        public void adiciona_inscrito_repetido() {
            inscricao = new Inscricao(evento, new Pessoa());
            Atividade atividade = new Atividade(evento, "Lugar", 3);
            Inscricao jose = new Inscricao(evento, new Pessoa());
            atividade.AdicionarInscritos(jose);
            atividade.AdicionarInscritos(jose);
            Assert.AreEqual(atividade.QuantidadeDeInscritos, 1);
        }
        [TestMethod]
        public void inscrever_em_atividade_que_nao_pertece_ao_evento() {
            inscricao = new Inscricao(evento, new Pessoa());
            Atividade atividade = new Atividade(evento, "Lugar", 3);
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
            Atividade atividade = new Atividade(evento, "Lugar", 3);
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
            Atividade atividade = new Atividade(evento, "Lugar", 3);
            evento.Estado = EstadoDoEvento.Aberto;
            try {
                inscricao.AdicionarAtividade(atividade);
                Assert.Fail();
            } catch {

            }
        }
        [TestMethod]
        public void inscrever_em_pelo_menos_uma_atividade() {
            inscricao = new Inscricao(evento, new Pessoa());
            evento.Estado = EstadoDoEvento.Aberto;
            try {
                inscricao.FinalizarInscricao();
                Assert.Fail();
            } catch (Exception e){
                Assert.AreEqual("Voce deve se inscrever em ao menos uma atividade", e.Message);
            }
        }
    }
}
