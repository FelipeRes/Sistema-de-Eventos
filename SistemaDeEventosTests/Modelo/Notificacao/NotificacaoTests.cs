using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sistema_de_Eventos;
using Sistema_de_Eventos.AtividadePack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Eventos.Tests {
    [TestClass()]
    public class NotificacaoTests {

        [TestMethod()]
        public void receber_notificacao_de_alteracao_de_horario() {
            Evento meuEvento = new Evento();
            meuEvento.Nome = "Arduino Day";
            Usuario user = new Usuario(new Pessoa());
            Inscricao inscrito = new Inscricao(user);
            inscrito.AdicionarAtividade(meuEvento);
            meuEvento.DataInicio = new DateTime(2016, 12, 09, 18, 15, 0);
            Assert.AreEqual(0, 0);
            //Assert.AreEqual(meuEvento.)

        }
        
    }
}