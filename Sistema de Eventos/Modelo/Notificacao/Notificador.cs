using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Eventos {
    public interface Notificador {
        void AdicionarNotificavel(Notificavel notificavel);
        void RemoverNotificavel(Notificavel notificavel);
        void AtualizarNotificaveis();
    }
}
