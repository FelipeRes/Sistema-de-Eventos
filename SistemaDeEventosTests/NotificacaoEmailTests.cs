using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sistema_de_Eventos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;

namespace Sistema_de_Eventos.Tests {
    [TestClass()]
    public class NotificacaoEmailTests {
        [TestMethod()]
        public void enviar_notificacao() {
            Evento evento = new Evento();
            Atividade ativiade = new Atividade(evento, "Lugar");
            Inscricao inscricao = new Inscricao(evento, new Pessoa());
            inscricao.AdicionarAtividade(ativiade);
            inscricao.FinalizarInscricao();
        }
        
    }
}