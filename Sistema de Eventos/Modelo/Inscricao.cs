using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Eventos {
    public class Inscricao {

        private List<Atividade> listaDeAtividades = new List<Atividade>();
        private List<Cupom> listaDeCupons = new List<Cupom>();

        private Evento evento;
        public Evento eventoDaInscricao { get { return evento;}}

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
        public Inscricao(Evento evento, Pessoa pessoa) {
            this.evento = evento;
            this.pessoa = pessoa;
        }

        public void AdicionarAtividade(Atividade atividade) {
            if (!listaDeAtividades.Contains(atividade) && !pagamento && atividade.EventoDaAtividade == this.eventoDaInscricao) {
                atividade.AdicionarInscritos(this);
                listaDeAtividades.Add(atividade);
            }else {
                throw new Exception("Atividade Repetida ou não pertece a esse evento");
            }
        }
        public void RemoverAtividade(Atividade atividade) {
            if (listaDeAtividades.Contains(atividade) && !pagamento) {
                listaDeAtividades.Remove(atividade);
                atividade.RemoverInscritos(this);
            }else {
                throw new Exception("Atividade nao encontrada");
            }
        }
        public void AdicionarCuponDeDesconto(Cupom cupom) {
            if (!pagamento) {
                listaDeCupons.Add(cupom);
            } else {
                throw new Exception("Inscricao Ja finalizada");
            }
        }
        public void FinalizarInscricao() {
            if (evento.Estado == EstadoDoEvento.Aberto) { 
                pagamento = true;
            } else {
                throw new Exception("Inscricao encerrada");
            }
        }
    }
}
