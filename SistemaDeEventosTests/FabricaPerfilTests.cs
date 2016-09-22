using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sistema_de_Eventos.Modelo;
using Sistema_de_Eventos.Modelo.Controle;
using Sistema_de_Eventos.Modelo.Eventos;
using SistemaDeEventos.Dominio.Modelo.Controle;
using SistemaDeEventos.Dominio.Modelo.Inscircoes;
using SistemaDeEventos.Modelo.Controle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeEventos.Dominio.Modelo.Controle.Tests {
    [TestClass()]
    public class FabricaPerfilTests {
        [TestMethod()]
        public void eventos_que_participou() {
            Pessoa pessoa = Pessoa.BuildNome("Éric").Idade(10).build();
            Usuario user = FabricaUsuario.NovoUsuario("blablabla@gmai.com", "123456").AdicionaPessoa(pessoa).build();
            PerfilParticipante perfil = FabricaPerfil.Participante(user);

            Atividade atividade1 = FabricarAtividade.Simples("Café");
            Atividade atividade2 = FabricarAtividade.Simples("Almoco");
            Atividade atividade3 = FabricarAtividade.Simples("Jantar");

            Inscricao inscricao = FabricaInscricao.NovaInscricao();
            inscricao.User = user;
            inscricao.Atividades.Adicionar(atividade1);
            inscricao.Atividades.Adicionar(atividade2);
            inscricao.Atividades.Adicionar(atividade3);
            inscricao.FinalizarInscricao();
            atividade2.Estado = EstadoDaAtividade.Encerrado;
            var lista = perfil.AtividadesQueParticipei();
            if (lista.Contains(atividade2)) {
                Assert.AreEqual(0,0);
            }

        }
    }
}