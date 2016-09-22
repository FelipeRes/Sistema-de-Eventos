using Sistema_de_Eventos.Modelo.Espaco;
using Sistema_de_Eventos.Modelo.Notificacoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Eventos.Modelo.Eventos {
    public class AtividadeSimples : Atividade {

        public override bool Isolada { get { return isolada; } set { isolada = value; } }

        public override string Agenda {
            get {
                string horarios = "\n";
                horarios += Nome;
                horarios += " - Inicio: ";
                horarios += DataInicio.ToString();
                horarios += " - Fim: ";
                horarios += DataFim.ToString();
                return horarios;
            }
        }

        public AtividadeSimples() {
            inscritos = new List<Inscricao>();
            notificador = FabricaNotificacao.CriarNotificador();
            isolada = false;
        }

        public override void AdicionarInscritos(Inscricao inscricao, Inscricao.AddAtividade addAtividade) {
            if (!inscritos.Contains(inscricao)) {
                inscritos.Add(inscricao);
                addAtividade(this);
                notificador.AdicionarNotificavel(inscricao.User);
            }
        }
        public override void RemoverInscritos(Inscricao inscricao, Inscricao.RemoveAtividade removeAtividade) {
            if (inscritos.Contains(inscricao)) {
                inscritos.Remove(inscricao);
                removeAtividade(this);
                notificador.RemoverNotificavel(inscricao.User);
            }
        }

        protected override void Notificar(string Mensagem) {
            string Complemento = "Prezado incrito, a data e horario desta Atividade foram alteradas.";
            notificador.AtualizarNotificaveis(Complemento + Mensagem);
        }
    }
}
