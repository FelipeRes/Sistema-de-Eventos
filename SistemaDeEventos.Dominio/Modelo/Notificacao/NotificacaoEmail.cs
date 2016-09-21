using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Eventos.Modelo.Notificacoes {
    public class NotificacaoEmail : Notificavel {

        public virtual int Id { get; set; }

        public virtual void Atualizar(string message) {
            Console.WriteLine("Yep");
        }
    }
}
