using Sistema_de_Eventos.Modelo.Espaco;
using Sistema_de_Eventos.Modelo.Notificacoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Eventos.Modelo.Evento {
    public class AtividadeDefault :Atividade {

        public override double Preco { get { return 0; } set { throw new Exception("Não pode ter valor"); } }

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

        public AtividadeDefault(string nome) {
            inscritos = new List<Inscricao>();
            notificador = FabricaNotificacao.CriarNotificador();
            espacoFisico = FabricarEspaco.Vazio();
            this.nome = nome;
        }

        public override void AdicionarInscritos(Inscricao inscricao, Inscricao.AddAtividade addAtividade) {
            return;
        }
        public override void RemoverInscritos(Inscricao inscricao, Inscricao.RemoveAtividade remove) {
            return;
        }

        protected override void Notificar(string Mensagem) {
            return;
        }
    }
}
