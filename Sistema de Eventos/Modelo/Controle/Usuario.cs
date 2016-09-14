using Sistema_de_Eventos.AtividadePack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Sistema_de_Eventos {
    public class Usuario : Notificavel {

        private Regex regMail = new Regex(@".*@(.*(\.|))*", RegexOptions.IgnoreCase);
        private Regex regSenha = new Regex(@"[a-zA-z0-9]{6,}", RegexOptions.IgnoreCase);

        private Pessoa pessoa;
        public Pessoa Pessoa { get { return pessoa; } set { pessoa = value; } }

        private string email;
        public string Email {
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
        public string Senha {
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
        public Notificador Notificacao {get{return notificacao;}set { notificacao = value; }}

        private List<Inscricao> minhasInscricoes;
        public IReadOnlyList<Inscricao> MinhasInscricoes {
            get { return minhasInscricoes; }
        }
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
        }

        public Usuario(string email, string senha) {
            this.Email = email;
            this.Senha = senha;
            minhasInscricoes = new List<Inscricao>();
            notificacao = new Notificacao();
            notificacao.AdicionarNotificavel(new NotificacaoEmail());
            atividadeQueParticipei = new List<Atividade>();
        }

        public bool Check(string senha) {
            if(this.senha == senha) {
                return true;
            }else {
                throw new ArgumentException("Senha Invalida");
            }
                
        }
        public void InserirInscricao(Inscricao inscricao) {
            if (inscricao.User == this && !minhasInscricoes.Contains(inscricao)) {
                minhasInscricoes.Add(inscricao);
            }
        }
        public void Atualizar(string message) {
            Notificacao.AtualizarNotificaveis(message);
        }

    }
}
