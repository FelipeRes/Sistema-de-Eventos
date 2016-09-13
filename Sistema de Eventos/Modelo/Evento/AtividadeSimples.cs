using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Eventos.AtividadePack {
    public class AtividadeSimples : Atividade {

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

        public AtividadeSimples(string nome) {
            inscritos = new List<Inscricao>();
            this.nome = nome;
            espacoFisico = new EspacoVazio();
            Estado = EstadoDaAtividade.Aberto;
        }

        public override void AdicionarInscritos(Inscricao inscricao, Inscricao.AddAtividade addAtividade) {
            if (!inscritos.Contains(inscricao)) {
                inscritos.Add(inscricao);
                addAtividade(this);
            }
        }
        public override void RemoverInscritos(Inscricao inscricao, Inscricao.RemoveAtividade removeAtividade) {
            if (inscritos.Contains(inscricao)) {
                inscritos.Remove(inscricao);
                removeAtividade(this);
            }
        }
    }
}
