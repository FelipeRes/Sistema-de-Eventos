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

        private Notificacao notificacao;
        public Notificacao Notificacao { get { return notificacao; } set { notificacao = value; } }

        private GerenciaAtividade gerenciadorDeAtividades = new GerenciaAtividade();
        public int QuantidadeDeAtividades { get { return gerenciadorDeAtividades.ListaDeAtividades.Count; } }

        private Atividade atividadePrincipal;
        public Atividade AtividadePrinciapal { get { return atividadePrincipal; } set { atividadePrincipal = value; } }

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
            nome = "Novo Evento";
            espacoFisico = new EspacoVazio();
            Estado = EstadoDoEvento.Aberto;
            AtividadePrinciapal = new Atividade(this, espacoFisico.Nome);
        }
        public void AdicionarAtividade(Atividade atividade) {
            gerenciadorDeAtividades.AdicionarAtividade(atividade);
        }
        public void RemoverAtividade(Atividade atividade) {
            gerenciadorDeAtividades.RemoverAtividade(atividade);
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
