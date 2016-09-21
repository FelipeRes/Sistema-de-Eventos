using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sistema_de_Eventos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using Sistema_de_Eventos.Modelo.Eventos;
using Sistema_de_Eventos.Modelo;
using Sistema_de_Eventos.Modelo.Controle;
using SistemaDeEventos.Modelo.Controle;

namespace Sistema_de_Eventos.Tests {
    [TestClass()]
    public class NotificacaoEmailTests {
        [TestMethod()]
        public void enviar_notificacao() {
            Evento evento = FabricarAtividade.Evento();
            Atividade ativiade = FabricarAtividade.Simples("Lugar");
            evento.Atividades.Adicionar(ativiade);
            Inscricao inscricao = new Inscricao(FabricaUsuario.NovoUsuario("bla@gats", "123456").build());
            inscricao.AdicionarAtividade(ativiade);
            inscricao.FinalizarInscricao();
        }
        
    }
}