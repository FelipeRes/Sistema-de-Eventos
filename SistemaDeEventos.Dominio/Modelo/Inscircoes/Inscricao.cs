using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using Sistema_de_Eventos.Modelo.Eventos;
using Sistema_de_Eventos.Modelo.Cupons;
using Sistema_de_Eventos.Modelo.Controle;

namespace Sistema_de_Eventos.Modelo {
    public class Inscricao {

        public delegate void AddAtividade(Atividade atividade);
        public delegate void RemoveAtividade(Atividade atividade);

        public virtual int Id { get; set; }

        public virtual IList<Cupom> listaDeCupons { get; set; }

        private Usuario usuario;
        public virtual Usuario User { get { return usuario; } set { usuario = value; } }

        private bool pagamento;
        public virtual bool Pagamento { get { return pagamento; } }

        private bool checkIn;
        public virtual bool CheckIn { get { return checkIn; } }

        public virtual ListaAtividade Atividades { get; set; }


        public virtual double ValorTotal {
            get {
                double PrecoFinal = 0;
                for (int i = 0; i < Atividades.Quantidade; i++) {
                    PrecoFinal += Atividades.lista[i].Preco;
                }
                return PrecoFinal;
            }
        }
        public virtual double ValorComDesconto {
            get {
                double valorComDesconto = ValorTotal;
                for (int i = 0; i < listaDeCupons.Count; i++) {
                    valorComDesconto -= listaDeCupons[i].GetDesconto(ValorTotal);
                }
                return valorComDesconto;
            }
        }
        internal Inscricao() {
        }

        public virtual void AdicionarAtividade(Atividade atividade) {
            if (!pagamento && atividade.Estado == EstadoDaAtividade.Aberto) {
                AddAtividade a = new AddAtividade(Atividades.Adicionar);
                atividade.AdicionarInscritos(this, a);
            } else {
                throw new Exception("Atividade Repetida ou não pertece a esse atividade");
            }
        }
        public virtual void RemoverAtividade(Atividade atividade) {
            if (!pagamento) {
                RemoveAtividade a = new RemoveAtividade(Atividades.Adicionar);
                atividade.RemoverInscritos(this, a);
            } else {
                throw new Exception("Atividade nao encontrada");
            }
        }
        public virtual void AdicionarCuponDeDesconto(Cupom cupom) {
            if (!pagamento) {
                listaDeCupons.Add(cupom);
            } else {
                throw new Exception("Inscricao Ja finalizada");
            }
        }
        public virtual void FinalizarInscricao() {
            if (Atividades.Quantidade > 0) {
                pagamento = true;
                foreach(var cupom in listaDeCupons) {
                    if (!cupom.IsUsado) {
                        cupom.Invalidar();
                    }
                }
                usuario.Notificacao.AtualizarNotificaveis("Inscição finalizada com sucesso!");
                //User.(this);
            } else {
                throw new Exception("Voce deve se inscrever em ao menos uma atividade");
            }
        }
        public virtual string nota {
            get {
                string nota = "\n";
                for (int i = 0; i < Atividades.lista.Count; i++) {
                    nota += Atividades.lista[i].Nome + " - Preco: " + Atividades.lista[i].Preco + "\n";
                }
                nota += "Valor Total: " + ValorTotal + "\n";
                nota += "Valor Com Desconto: " + ValorComDesconto;
                return nota;
            }
        }
        public virtual void ConfirmarCheckIn() {
            checkIn = true;
        }
    }
}
