using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Eventos {
    public class Usuario : Notificavel {

        private Pessoa pessoa;
        public Pessoa Pessoa { get { return pessoa; } set { pessoa = value; } }

        private string email;
        public string Email { get { return email; } set { email = value; } }       

        private string senha;
        public string Senha { set { senha = value; } }

        private Notificador notificacao;
        public Notificador Notificacao {get{return notificacao;}set { notificacao = value; }}

        private List<Inscricao> minhasInscricoes;
        public IReadOnlyList<Inscricao> MinhasInscricoes {
            get { return minhasInscricoes; }
        }

        public Usuario(string email, string senha) {
            this.Email = email;
            this.Senha = senha;
            minhasInscricoes = new List<Inscricao>();
            notificacao = new Notificacao();
            notificacao.AdicionarNotificavel(new NotificacaoEmail());
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
