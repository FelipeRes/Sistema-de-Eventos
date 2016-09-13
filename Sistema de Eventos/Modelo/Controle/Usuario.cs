using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Eventos {
    public class Usuario {
        private string email;
        public string Email { get { return email;  } set { email = value; } }

        private Pessoa pessoa;
        public Pessoa Pessoa { get { return pessoa; } set { pessoa = value; } }

        private string senha;
        public string Senha {set { senha = value; } }

        private List<Inscricao> minhasInscricoes;
        public IReadOnlyList<Inscricao> MinhasInscricoes {
            get { return minhasInscricoes; }
        }

        public Usuario() {
            minhasInscricoes = new List<Inscricao>();
        }

        public Usuario(Pessoa pessoa) {
            minhasInscricoes = new List<Inscricao>();
            this.pessoa = pessoa;
        }

        public string GetSenha(string senha) {
            if(this.senha == senha) {
                return senha;
            }else {
                throw new ArgumentException("Senha Invalida");
            }
                
        }
        public void InserirInscricao(Inscricao inscricao) {
            if (inscricao.User == this && !minhasInscricoes.Contains(inscricao)) {
                minhasInscricoes.Add(inscricao);
            }
        }

    }
}
