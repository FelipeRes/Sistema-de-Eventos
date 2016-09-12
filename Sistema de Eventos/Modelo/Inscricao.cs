using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;

namespace Sistema_de_Eventos {
    public class Inscricao {
        
        private List<Cupom> listaDeCupons = new List<Cupom>();

        private Atividade Atividade;
        public Atividade AtividadeDaInscricao { get { return Atividade;}}

        private Usuario usuario;
        public Usuario PessoaInscrita { get { return usuario; } }

        private bool pagamento;
        public bool Pagamento { get { return pagamento; } }

        private ListaAtividade listaDeAtividades = new ListaAtividade();

        public double ValorTotal { get { return Atividade.Preco;}}
        public double ValorComDesconto {
            get {
                double valorComDesconto = ValorTotal;
                for (int i = 0; i < listaDeCupons.Count; i++) {
                    valorComDesconto -= listaDeCupons[i].GetDesconto(ValorTotal);
                }
                return valorComDesconto;
            }
        }
        public Inscricao(Atividade atividade, Usuario pessoa) {
            this.Atividade = atividade;
            AdicionarAtividade(atividade);
            this.usuario = usuario;
        }

        public void AdicionarAtividade(Atividade atividade) {
            if (!pagamento) {
                atividade.AdicionarInscritos(this);
                listaDeAtividades.Adicionar(atividade);
            }else {
                throw new Exception("Atividade Repetida ou não pertece a esse atividade");
            }
        }
        public void RemoverAtividade(Atividade atividade) {
            if (!pagamento) {
                listaDeAtividades.Remover(atividade);
                atividade.RemoverInscritos(this);
            }else {
                throw new Exception("Atividade nao encontrada");
            }
        }
        public void AdicionarCuponDeDesconto(Cupom cupom) {
            if (!pagamento) {
                if(cupom.Usado == false) { 
                    listaDeCupons.Add(cupom);
                } else {
                    throw new Exception("Cupom Invalido");
                }
            } else {
                throw new Exception("Inscricao Ja finalizada");
            }
        }
        public void FinalizarInscricao() {
            if (Atividade.Estado == EstadoDaAtividade.Aberto) {
                if (listaDeAtividades.Quantidade > 0) { 
                    pagamento = true;
                    for (int i = 0; i < listaDeCupons.Count; i++) {
                        listaDeCupons[i].Invalidar();
                    }
                } else {
                    throw new Exception("Voce deve se inscrever em ao menos uma atividade");
                }
            } else {
                throw new Exception("Inscricao encerrada");
            }
        }
    }
}
