using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Eventos.Modelo.Notificacoes {
    public class Notificacao : Notificador {

        public virtual int Id { get; set; }

        public virtual IList<Notificavel> listaObservadores { get; set; }

        internal Notificacao() {
            listaObservadores = new List<Notificavel>();
        }

        public virtual void AdicionarNotificavel(Notificavel notificavel) {
            if (!listaObservadores.Contains(notificavel)) {
                listaObservadores.Add(notificavel);
            }
        }

        public virtual void AtualizarNotificaveis(string message) {
            foreach(Notificavel n in listaObservadores) {
                n.Atualizar(message);
            }
        }

        public virtual void RemoverNotificavel(Notificavel notificavel) {
            if (listaObservadores.Contains(notificavel)) {
                listaObservadores.Add(notificavel);
            }
        }
    }
}
