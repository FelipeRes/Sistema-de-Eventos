using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;

namespace Sistema_de_Eventos {
    public class NotificacaoEmail : Notificavel {
        private MailMessage mail;
        public MailMessage Mail { get { return mail; } set { mail = value; } }

        public void EnviarNotificacao(string menssagem) {
            //faz de conta que enviou
        }
        public NotificacaoEmail() {

        }
    }
}
