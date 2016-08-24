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
        public string Nome { get { return atividadePrincipal.Nome; } set { atividadePrincipal.Nome = value; } }

        private EstadoDoEvento estadoEvento;
        public EstadoDoEvento Estado { get { return estadoEvento; } set { estadoEvento = value; } }

        private Atividade atividadePrincipal;
        public Atividade AtividadePrinciapal { get { return atividadePrincipal; } set { atividadePrincipal = value; } }

        public List<Atividade> ListaDeAtividades = new List<Atividade>();

        private Notificacao notificacao;
        public Notificacao Notificacao { get { return notificacao; } }

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
            espacoFisico = new EspacoVazio();
            Estado = EstadoDoEvento.Aberto;
            ListaDeAtividades = new List<Atividade>();
            AtividadePrinciapal = new Atividade(this, espacoFisico.Nome, 100);
            Nome = "Novo Evento";
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
