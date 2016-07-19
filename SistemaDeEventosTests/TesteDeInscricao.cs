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
        Inscricao inscricao = new Inscricao(new Pessoa());
        Evento evento = new Evento();
        [TestMethod]
        public void preco_da_inscricao() {
            Atividade atividade = new Atividade(evento, 3);
            atividade.Preco = 45;
            Atividade atividade2 = new Atividade(evento, 4);
            atividade2.Preco = 45;
            inscricao.AdicionarAtividade(atividade);
            inscricao.AdicionarAtividade(atividade2);
            Assert.AreEqual(90, inscricao.ValorTotal);
        }
        [TestMethod]
        public void adicionar_atividade_repetida_na_inscricao() {
            Atividade palestra = new Atividade(evento, 3);
            inscricao.AdicionarAtividade(new Atividade(evento, 3));
            try {
                inscricao.AdicionarAtividade(new Atividade(evento, 3));
                Assert.Fail();
            }catch(Exception e) {
                Assert.IsTrue(true);
            }
        }
        [TestMethod]
        public void remover_atividade_que_nao_existe_da_inscricao() {
            Atividade palestra = new Atividade(evento, 3);
            try {
                inscricao.RemoverAtividade(new Atividade(evento, 3));
                Assert.Fail();
            } catch (Exception e) {
                Assert.IsTrue(true);
            }
        }
        [TestMethod]
        public void valor_da_inscricao_com_cupom_de_desconto_para_estudante() {
            Atividade atividade = new Atividade(evento, 3);
            atividade.Preco = 90;
            inscricao.AdicionarAtividade(atividade);
            inscricao.AdicionarCuponDeDesconto(new Cupom(new DescontoEstudante()));
            Assert.AreEqual(45, inscricao.ValorComDesconto);
        }
        [TestMethod]
        public void adicionar_atividade_apos_finalizar_inscricao() {
            inscricao.AdicionarAtividade(new Atividade(evento, 3));
            inscricao.AdicionarAtividade(new Atividade(evento, 3));
            inscricao.AdicionarCuponDeDesconto(new Cupom(new DescontoEstudante()));
            inscricao.FinalizarInscricao();
            try {
                inscricao.AdicionarAtividade(new Atividade(evento, 3));
                Assert.Fail();
            }catch(Exception e) {

            }
        }
        [TestMethod]
        public void exceder_numero_maxio_de_inscritos() {
            Atividade atividade = new Atividade(evento, 3);
            Inscricao inscrito1 = new Inscricao(new Pessoa());
            inscrito1.AdicionarAtividade(atividade);
            Inscricao inscrito2 = new Inscricao(new Pessoa());
            inscrito2.AdicionarAtividade(atividade);
            Inscricao inscrito3 = new Inscricao(new Pessoa());
            inscrito3.AdicionarAtividade(atividade);
            Inscricao inscrito4 = new Inscricao(new Pessoa());
            inscrito4.AdicionarAtividade(atividade);
            Assert.AreEqual(atividade.QuantidadeMaximaPessoas, atividade.QuantidadeDeInscritos);
        }
        [TestMethod]
        public void valor_da_inscricao_com_cupom_de_desconto_por_porcentagem() {
            Atividade atividade = new Atividade(evento, 3);
            atividade.Preco = 90;
            inscricao.AdicionarAtividade(atividade);
            inscricao.AdicionarCuponDeDesconto(new Cupom(new DescontoPorcentagem()));
            Assert.AreEqual(9, inscricao.ValorComDesconto);
        }
    }
}
