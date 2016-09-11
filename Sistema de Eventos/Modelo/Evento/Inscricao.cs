using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;

namespace Sistema_de_Eventos {
    public class Inscricao {
        
        private List<Cupom> listaDeCupons = new List<Cupom>();

        private Evento evento;
        public Evento eventoDaInscricao { get { return evento;}}

        private Pessoa pessoa;
        public Pessoa PessoaInscrita { get { return pessoa; } }

        private bool pagamento;
        public bool Pagamento { get { return pagamento; } }

        private ListaAtividade listaDeAtividades = new ListaAtividade();

        public double ValorTotal { get {return listaDeAtividades.ValorDeTodasAtividades();}}
        public double ValorComDesconto {
            get {
                double valorComDesconto = ValorTotal;
                for (int i = 0; i < listaDeCupons.Count; i++) {
                    valorComDesconto -= listaDeCupons[i].GetDesconto(ValorTotal);
                }
                return valorComDesconto;
            }
        }
        public Inscricao(Evento evento, Pessoa pessoa) {
            this.evento = evento;
            AdicionarAtividade(evento.AtividadePrinciapal);
            this.pessoa = pessoa;
        }

        public void AdicionarAtividade(Atividade atividade) {
            if (!pagamento && evento.PossuiAtividade(atividade)) {
                atividade.AdicionarInscritos(this);
                listaDeAtividades.AdicionarAtividade(atividade);
            }else {
                throw new Exception("Atividade Repetida ou não pertece a esse evento");
            }
        }
        public void RemoverAtividade(Atividade atividade) {
            if (!pagamento) {
                listaDeAtividades.RemoverAtividade(atividade);
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
            if (evento.Estado == EstadoDoEvento.Aberto) {
                if (listaDeAtividades.QunatidadeDeInscritos() > 0) { 
                    pagamento = true;
                    for (int i = 0; i < listaDeCupons.Count; i++) {
                        listaDeCupons[i].Invalidar();
                    }
                    evento.EnviarNotificacao("Inscricao Realizada com sucesso");
                } else {
                    throw new Exception("Voce deve se inscrever em ao menos uma atividade");
                }
            } else {
                throw new Exception("Inscricao encerrada");
            }
        }
    }
}
