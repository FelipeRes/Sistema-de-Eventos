using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Eventos {
    public class AtividadeSimples : Atividade {

        public override double Preco { get { return preco; } set { preco = value; } }

        public override int QuantidadeDeInscritos { get { return inscritos.Count;}}

        public override int QuantidadeDeInscritosPagos {
            get {
                int quantidadePagos = 0;
                for (int i = 0; i < QuantidadeDeInscritos; i++) {
                    if (inscritos[i].Pagamento) {
                        quantidadePagos++;
                    }
                }
                return quantidadePagos;
            }
        }

        public override String Agenda {
            get {
                string horarios = "\n";
                horarios += Nome;
                horarios += " - Inicio: ";
                horarios += DataInicio.ToString();
                horarios += " - Fim: ";
                horarios += DataFim.ToString();
                horarios += "\n";
                return horarios;
            }
        }

        public AtividadeSimples(String nome) {
            inscritos = new List<Inscricao>();
            this.nome = nome;
            espacoFisico = new EspacoVazio();
        }
    }
}
