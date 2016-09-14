using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sistema_de_Eventos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using Sistema_de_Eventos.AtividadePack;

namespace Sistema_de_Eventos.Tests {
    [TestClass()]
    public class NotificacaoEmailTests {
        [TestMethod()]
        public void enviar_notificacao() {
            Evento evento = FabricarAtividade.Evento();
            Atividade ativiade = FabricarAtividade.Simples("Lugar");
            evento.Atividades.Adicionar(ativiade);
            Inscricao inscricao = new Inscricao( new Usuario("bla@gats", "sou"));
            inscricao.AdicionarAtividade(ativiade);
            inscricao.FinalizarInscricao();
        }
        
    }
}