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
            Atividade ativiade = new AtividadeSimples("Lugar");
            evento.Atividades.Adicionar(ativiade);
            Inscricao inscricao = new Inscricao( new Usuario(new Pessoa()));
            inscricao.AdicionarAtividade(ativiade);
            inscricao.FinalizarInscricao();
        }
        
    }
}