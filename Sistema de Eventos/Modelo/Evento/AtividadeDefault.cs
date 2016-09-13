using Sistema_de_Eventos.AtividadePack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Eventos{
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
            this.nome = nome;
            espacoFisico = new EspacoVazio();
            Estado = EstadoDaAtividade.Aberto;
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
