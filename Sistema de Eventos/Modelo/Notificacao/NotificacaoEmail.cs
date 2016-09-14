using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Eventos {
    public class NotificacaoEmail : Notificavel {
        public string message;
        public void Atualizar(string message) {
            this.message = message;
            //Console.WriteLine(message);
            //throw new NotImplementedException(message);
        }
    }
}
