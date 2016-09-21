using Sistema_de_Eventos.Modelo;
using Sistema_de_Eventos.Modelo.Controle;
using Sistema_de_Eventos.Modelo.Cupons;
using Sistema_de_Eventos.Modelo.Eventos;
using Sistema_de_Eventos.Modelo.Notificacoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Sistema_de_Eventos.Modelo.Controle {
    public class Usuario : Notificavel {

        public virtual int Id { get; set; }

        private Regex regMail = new Regex(@".*@(.*(\.|))*", RegexOptions.IgnoreCase);
        private Regex regSenha = new Regex(@"[a-zA-z0-9]{6,}", RegexOptions.IgnoreCase);

        private Pessoa pessoa;
        public virtual Pessoa Pessoa { get { return pessoa; } set { pessoa = value; } }

        private string email;
        public virtual string Email {
            get {
                return email;
            } set {
                Match match = regMail.Match(value);
                if (match.Success) {
                    email = value;
                }else {
                    throw new Exception("Formato de e-mail errado");
                }
                
            }
        }       

        private string senha;
        public virtual string Senha {
            get {
                return senha;
            }
            set {
                Match match = regSenha.Match(value);
                if (match.Success) {
                    senha = value;
                } else {
                    throw new Exception("Apenas letras e numeros, minimo 6 letras");
                }
            }
        }

        private Notificador notificacao;
        public virtual Notificador Notificacao {get{return notificacao;}set { notificacao = value; }}

        /*private IList<Inscricao> minhasInscricoes

        private List<Atividade> atividadeQueParticipei;
        public IReadOnlyList<Atividade> AtividadeQueParticipei {
            get {
                atividadeQueParticipei.Clear();
                foreach(Inscricao inscricao in MinhasInscricoes) {
                    foreach(Atividade atividade in inscricao.listaDeAtividades) {
                        atividadeQueParticipei.Add(atividade);
                    }
                }
                return atividadeQueParticipei;
            }
        }*/

        internal Usuario() {
            //notificacao = new Notificacao();
            //notificacao.AdicionarNotificavel(new NotificacaoEmail());
        }

        public virtual bool Check(string senha) {
            if(this.senha == senha) {
                return true;
            }else {
                throw new ArgumentException("Senha Invalida");
            }
                
        }
        /*public void InserirInscricao(Inscricao inscricao) {
            if (inscricao.User == this && !minhasInscricoes.Contains(inscricao)) {
                minhasInscricoes.Add(inscricao);
            }
        }*/
        public virtual void Atualizar(string message) {
            Notificacao.AtualizarNotificaveis(message);
        }

    }
}
