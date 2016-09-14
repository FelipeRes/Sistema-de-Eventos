using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Eventos {
    public class FabricaNotificacao {
        public static Notificador CriarNotificador() {
            return new Notificacao();
        }
        public static Notificavel CriarNotificavelEmail() {
            return new NotificacaoEmail();
        }
    }
}
