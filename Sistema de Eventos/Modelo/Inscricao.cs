using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;

namespace Sistema_de_Eventos {
    public class Inscricao {
        
        private List<Cupom> listaDeCupons = new List<Cupom>();

        private Usuario usuario;
        public Usuario PessoaInscrita { get { return usuario; } }

        private bool pagamento;
        public bool Pagamento { get { return pagamento; } }

        private ListaAtividade Atividades;

        public double ValorTotal {
            get {
                double PrecoFinal = 0;
                for(int i =0; i< Atividades.Quantidade; i++) {
                    PrecoFinal += Atividades.Lista[i].Preco;
                }
                return PrecoFinal;
            }
        }
        public double ValorComDesconto {
            get {
                double valorComDesconto = ValorTotal;
                for (int i = 0; i < listaDeCupons.Count; i++) {
                    valorComDesconto -= listaDeCupons[i].GetDesconto(ValorTotal);
                }
                return valorComDesconto;
            }
        }
        public Inscricao(Usuario pessoa) {
            Atividades = new ListaAtividade();
            this.usuario = pessoa;
        }

        public void AdicionarAtividade(Atividade atividade) {
            if (!pagamento && atividade.Estado == EstadoDaAtividade.Aberto) {
                atividade.AdicionarInscritos(this);
                Atividades.Adicionar(atividade);
            }else {
                throw new Exception("Atividade Repetida ou não pertece a esse atividade");
            }
        }
        public void RemoverAtividade(Atividade atividade) {
            if (!pagamento) {
                Atividades.Remover(atividade);
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
                if (Atividades.Quantidade > 0) { 
                    pagamento = true;
                    for (int i = 0; i < listaDeCupons.Count; i++) {
                        listaDeCupons[i].Invalidar();
                    }
                } else {
                    throw new Exception("Voce deve se inscrever em ao menos uma atividade");
                }
        }
    }
}
