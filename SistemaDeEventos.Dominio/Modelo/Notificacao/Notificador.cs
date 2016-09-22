using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Eventos.Modelo.Notificacoes {
    public interface Notificador {
        int Id { get; set; }
        void AdicionarNotificavel(Notificavel notificavel);
        void RemoverNotificavel(Notificavel notificavel);
        void AtualizarNotificaveis(string message);
    }
}
