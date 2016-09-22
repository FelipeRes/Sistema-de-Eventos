using Microsoft.VisualStudio.TestTools.UnitTesting;
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

namespace SistemaDeEventosTests {
    [TestClass]
    public class TesteDeInscricao {
        public Evento evento = FabricarAtividade.Evento();
        public Inscricao inscricao;
        [TestMethod]
        public void preco_da_inscricao() {
            inscricao = FabricaInscricao.NovaInscricao();
            inscricao.User = FabricaUsuario.NovoUsuario("bla@gats", "123456").build();
            Atividade atividade = FabricarAtividade.Simples("Lugar");
            evento.Atividades.Adicionar(atividade);
            atividade.Preco = 45;
            Atividade atividade2 = FabricarAtividade.Simples("Lugar");
            evento.Atividades.Adicionar(atividade2);
            atividade2.Preco = 45;
            inscricao.AdicionarAtividade(atividade);
            inscricao.AdicionarAtividade(atividade2);
            Assert.AreEqual(90, inscricao.ValorTotal);
        }
        [TestMethod]
        public void adicionar_atividade_repetida_na_inscricao() {
            inscricao = FabricaInscricao.NovaInscricao();
            inscricao.User = FabricaUsuario.NovoUsuario("bla@gats", "123456").build();
            Atividade palestra = FabricarAtividade.Simples("Lugar");
            evento.Atividades.Adicionar(palestra);
            Atividade atividade2 = FabricarAtividade.Simples("Lugar");
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
            inscricao = FabricaInscricao.NovaInscricao();
            inscricao.User = FabricaUsuario.NovoUsuario("bla@gats", "123456").build();
            Atividade palestra = FabricarAtividade.Simples("Lugar");
            evento.Atividades.Adicionar(palestra);
            try {
                inscricao.RemoverAtividade(FabricarAtividade.Simples("Lugar"));
                Assert.Fail();
            } catch (Exception e) {
                Assert.IsTrue(true);
            }
        }
        [TestMethod]
        public void valor_da_inscricao_com_cupom_de_desconto_para_estudante() {
            inscricao = FabricaInscricao.NovaInscricao();
            inscricao.User = FabricaUsuario.NovoUsuario("bla@gats", "123456").build();
            Atividade atividade = FabricarAtividade.Simples("Lugar");
            evento.Atividades.Adicionar(atividade);
            atividade.Preco = 90;
            inscricao.AdicionarAtividade(atividade);
            inscricao.AdicionarCuponDeDesconto(FabricarCupom.DescontoPorcentagem(50));
            Assert.AreEqual(45, inscricao.ValorComDesconto);
        }
        [TestMethod]
        public void adicionar_atividade_apos_finalizar_inscricao() {
            inscricao = FabricaInscricao.NovaInscricao();
            inscricao.User = FabricaUsuario.NovoUsuario("bla@gats", "123456").build();
            Atividade atividade1 = FabricarAtividade.Simples("Lugar");
            evento.Atividades.Adicionar(atividade1);
            Atividade atividade2 = FabricarAtividade.Simples("Lugar");
            evento.Atividades.Adicionar(atividade2);
            Atividade atividade3 = FabricarAtividade.Simples("Lugar");
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
            inscricao = FabricaInscricao.NovaInscricao();
            inscricao.User = FabricaUsuario.NovoUsuario("bla@gats", "123456").build();
            Atividade atividade = FabricarAtividade.Simples("Lugar");
            //evento.Atividades.Adicionar(atividade);
            atividade.Preco = 100;
            inscricao.AdicionarAtividade(atividade);
            inscricao.AdicionarCuponDeDesconto(FabricarCupom.DescontoPorValor(90));
            Assert.AreEqual(10, inscricao.ValorComDesconto);
        }
        [TestMethod]
        public void adiciona_inscrito_repetido() {
            Inscricao inscricao = FabricaInscricao.NovaInscricao();
            inscricao.User = FabricaUsuario.NovoUsuario("bla@gats", "123456").build();
            Atividade atividade = FabricarAtividade.Simples("Lugar");
            evento.Atividades.Adicionar(atividade);
            Inscricao jose = FabricaInscricao.NovaInscricao();
            inscricao.User = FabricaUsuario.NovoUsuario("bla@gats", "123456").build();
            jose.AdicionarAtividade(atividade);
            jose.AdicionarAtividade(atividade);
            Assert.AreEqual(atividade.QuantidadeDeInscritos, 1);
        }
        [TestMethod]
        public void inscrever_em_atividade_que_nao_pertece_ao_evento() {
            Inscricao inscricao = FabricaInscricao.NovaInscricao();
            inscricao.User = FabricaUsuario.NovoUsuario("bla@gats", "123456").build();
            Atividade atividade = FabricarAtividade.Simples("Lugar");
            evento.Atividades.Adicionar(atividade);
            Evento evento2 = FabricarAtividade.Evento();
            Inscricao inscricaoDeEvento2 = FabricaInscricao.NovaInscricao();
            inscricao.User = FabricaUsuario.NovoUsuario("bla@gats", "123456").build();
            try {
                inscricaoDeEvento2.AdicionarAtividade(atividade);
                Assert.Fail();
            }catch{

            }
            
        }
        [TestMethod]
        public void inscrever_em_evento_ja_fechado() {
            Inscricao inscricao = FabricaInscricao.NovaInscricao();
            inscricao.User = FabricaUsuario.NovoUsuario("bla@gats", "123456").build();
            Atividade atividade = FabricarAtividade.Simples("Lugar");
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
            Inscricao inscricao = FabricaInscricao.NovaInscricao();
            inscricao.User = FabricaUsuario.NovoUsuario("bla@gats", "123456").build();
            Atividade atividade = FabricarAtividade.Simples("Lugar");
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
            Atividade atividade = FabricarAtividade.Simples("Palestra");
            atividade.Preco = 30;
            evento.Atividades.Adicionar(atividade);
            Inscricao inscricao = FabricaInscricao.NovaInscricao();
            inscricao.User = FabricaUsuario.NovoUsuario("bla@gats", "123456").build();
            inscricao.AdicionarAtividade(evento);
            Assert.AreEqual("\nArduino Day - Preco: 30\nPalestra - Preco: 30\nValor Total: 60\nValor Com Desconto: 60", inscricao.nota);
        }
        [TestMethod()]
        public void tentar_inscrever_em_atividade_complementar() {
            evento.Nome = "Arduino Day";
            evento.Preco = 30;
            Atividade atividade = FabricarAtividade.Complementar("Minicurso");
            evento.Atividades.Adicionar(atividade);
            Inscricao inscricao = FabricaInscricao.NovaInscricao();
            inscricao.User = FabricaUsuario.NovoUsuario("bla@gats", "123456").build();
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
            Atividade atividade = FabricarAtividade.Complementar("Minicurso");
            evento.Atividades.Adicionar(atividade);
            Inscricao inscricao = FabricaInscricao.NovaInscricao();
            inscricao.User = FabricaUsuario.NovoUsuario("bla@gats", "123456").build();
            inscricao.AdicionarAtividade(evento);
            Assert.AreEqual("\nArduino Day - Preco: 30\nValor Total: 30\nValor Com Desconto: 30", inscricao.nota);
        }
        [TestMethod()]
        public void checar_check_in() {
            evento.Nome = "Arduino Day";
            evento.Preco = 30;
            Atividade atividade = FabricarAtividade.Complementar("Café");
            evento.Atividades.Adicionar(atividade);
            Inscricao inscricao = FabricaInscricao.NovaInscricao();
            inscricao.User = FabricaUsuario.NovoUsuario("bla@gats", "123456").build();
            inscricao.AdicionarAtividade(evento);
            evento.ChecarCheckIn(inscricao);
            Assert.AreEqual(inscricao.CheckIn, true);
        }

        [TestMethod()]
        public void checar_inscricao_unica_no_evento() {
            evento.Nome = "Arduino Day";
            evento.Preco = 30;
            evento.isUnique = true;
            Atividade atividade = FabricarAtividade.Complementar("Café");
            Atividade palestra = FabricarAtividade.Simples("Palestra1");
            Atividade palestra2 = FabricarAtividade.Simples("Palestra2");
            evento.Atividades.Adicionar(atividade);
            evento.Atividades.Adicionar(palestra);
            evento.Atividades.Adicionar(palestra2);
            Inscricao inscricao = FabricaInscricao.NovaInscricao();
            inscricao.User = FabricaUsuario.NovoUsuario("bla@gats", "123456").build();
            inscricao.AdicionarAtividade(evento);
            inscricao.FinalizarInscricao();
            List<Atividade> listaDeAtividade = new List<Atividade>();
            listaDeAtividade.Add(evento);
            listaDeAtividade.Add(palestra);
            //listaDeAtividade.Add(palestra2);
            Assert.AreEqual(inscricao.Atividades.lista, listaDeAtividade);
        }
    }
}
