using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Eventos {
    public class Notificacao {
        private Notificavel veiculo;
        public Notificavel Veiculo { get { return veiculo; }}

        public void EnviarNotificacao(string Menssagem) {
            Veiculo.EnviarNotificacao(Menssagem);
        }
        public Notificacao(Notificavel notificavel) {
            veiculo = notificavel;
        }

    }
}
