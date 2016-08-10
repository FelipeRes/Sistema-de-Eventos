using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;


namespace Sistema_de_Eventos {
    public class Evento {

        private Evento eventoSatelite;
        private Evento EventoSatelite { get { return eventoSatelite; } }

        private string nome;
        public string Nome { get { return nome; } set { this.nome = value; } }

        private EstadoDoEvento estadoEvento;
        public EstadoDoEvento Estado { get { return estadoEvento; } set { estadoEvento = value; } }

        public List<Atividade> ListaDeAtividades = new List<Atividade>();

        private Notificacao notificacao;
        public Notificacao Notificacao { get { return notificacao; } set { notificacao = value; } }

        private EspacoFisico espacoFisico;
        public EspacoFisico Lugar {
            get {
                if (espacoFisico == null) {
                    return new EspacoVazio();
                } else {
                    return espacoFisico;
                }
            }
            set {
                    espacoFisico = value;
            }
        }

        public Evento() {
            Estado = EstadoDoEvento.Aberto;
            ListaDeAtividades = new List<Atividade>();
        }
        public void AdicionarAtividade(Atividade atividade) {
            if (!ListaDeAtividades.Contains(atividade)) {
                ListaDeAtividades.Add(atividade);
            } else {
                throw new Exception("Atividade repetida");
            }
        }
        public void RemoverAtividade(Atividade atividade) {
            if (ListaDeAtividades.Contains(atividade)) {
                ListaDeAtividades.Remove(atividade);
            } else {
                throw new Exception("Atividade nao existe");
            }
        }

        public void EnviarNotificacao(String menssagem) {
            notificacao = new Notificacao(new NotificacaoEmail());
            notificacao.EnviarNotificacao(menssagem);
        }

        public void AdicionarEventoSatelite(Evento evento) {
            eventoSatelite = evento;
        }

        public void RemoverEventoSatelite() {
            eventoSatelite = null;
        }
    }
}
