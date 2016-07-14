using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sistema_de_Eventos.Exceptions;

namespace Sistema_de_Eventos {
    public class Inscricao {

        private List<Atividade> listaDeAtividades = new List<Atividade>();
        private List<Cupom> listaDeCupons = new List<Cupom>();

        private Pessoa pessoa;
        public Pessoa Pessoa { get { return pessoa; }set { pessoa = value; } }

        private Evento evento;
        public Evento Evento { get { return evento; } set { evento = value; } }

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
        public Inscricao(/*Evento evento, Pessoa pessoa*/) {
            //Evento = evento;
            //Pessoa = pessoa;
        }

        public void AdicionarAtividade(Atividade atividade) {
            if (!listaDeAtividades.Contains(atividade) && !pagamento) {
                try {
                    atividade.AdicionarInscritos(this);
                    listaDeAtividades.Add(atividade);
                }catch(NumeroMaximoDeInscritosException e) {

                }
            } else {
                throw new AtividadeRepetida();
            }
        }
        public void RemoverAtividade(Atividade atividade) {
            if (listaDeAtividades.Contains(atividade) && !pagamento) {
                listaDeAtividades.Remove(atividade);
                atividade.RemoverInscritos(this);
            } else {
                throw new AtividadeRepetida();
            }
        }
        public void AdicionarCuponDeDesconto(Cupom cupom) {
            if (!pagamento) {
                listaDeCupons.Add(cupom);
            }else {
                throw new CuponRepetido();
            }
        }
        public void FinalizarInscricao() {
            pagamento = true;
        }
    }
}
