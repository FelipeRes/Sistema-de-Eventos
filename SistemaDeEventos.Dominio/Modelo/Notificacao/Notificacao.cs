using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Eventos.Modelo.Notificacoes {
    public class Notificacao : Notificador {

        private List<Notificavel> listaObservadores;

        public Notificacao() {
            listaObservadores = new List<Notificavel>();
        }

        public void AdicionarNotificavel(Notificavel notificavel) {
            if (!listaObservadores.Contains(notificavel)) {
                listaObservadores.Add(notificavel);
            }
        }

        public void AtualizarNotificaveis(string message) {
            foreach(Notificavel n in listaObservadores) {
                n.Atualizar(message);
            }
        }

        public void RemoverNotificavel(Notificavel notificavel) {
            if (listaObservadores.Contains(notificavel)) {
                listaObservadores.Add(notificavel);
            }
        }
    }
}
