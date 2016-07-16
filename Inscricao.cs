using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Eventos {
    public class Inscricao {

        private List<Atividade> listaDeAtividades = new List<Atividade>();
        private List<Cupom> listaDeCupons = new List<Cupom>();

        private Pessoa pessoa;
        public Pessoa PessoaInscrita { get { return pessoa; } }

        private bool pagamento;
        public bool Pagamento { get { return pagamento; } }

        private double valor;
        public double ValorTotal {
            get {
                valor = 0;
                for (int i = 0; i < listaDeAtividades.Count; i++) {
                    valor += listaDeAtividades[i].Preco;
                }
                return valor;
            }
        }
        public double ValorComDesconto {
            get {
                valor = ValorTotal;
                for (int i = 0; i < listaDeAtividades.Count; i++) {
                    valor -= listaDeCupons[i].GetDesconto(ValorTotal);
                }
                return valor;
            }
        }
        public Inscricao(Pessoa pessoa) {
            this.pessoa = pessoa;
        }

        public void AdicionarAtividade(Atividade atividade) {
            if (!listaDeAtividades.Contains(atividade) && !pagamento) {
                atividade.AdicionarInscritos(this);
                listaDeAtividades.Add(atividade);
            }
        }
        public void RemoverAtividade(Atividade atividade) {
            if (listaDeAtividades.Contains(atividade) && !pagamento) {
                listaDeAtividades.Remove(atividade);
                atividade.RemoverInscritos(this);
            }
        }
        public void AdicionarCuponDeDesconto(Cupom cupom) {
            if (!pagamento) {
                listaDeCupons.Add(cupom);
            }
        }
        public void FinalizarInscricao() {
            pagamento = true;
        }
    }
}
