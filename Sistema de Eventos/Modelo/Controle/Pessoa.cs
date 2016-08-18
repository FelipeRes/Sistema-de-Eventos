using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Eventos {
    public class Pessoa {
        private string nome;
        public string Nome { get { return nome; } set { this.nome = value; } }

        private int idade;
        public int Idade { get { return idade; } set { this.idade = value; } }

        private int cpf;
        public int CPF { get { return cpf; } set { this.cpf = value; } }

        private string email;
        public string Email { get { return email; } set { this.email = value; } }

        private string descricao;
        public string Descricao { get { return descricao; } set { this.email = value; } }

        public Pessoa() {
        }
        public Pessoa(string nome, int idade, int CPF, string email) {
            this.nome = nome;
            this.idade = idade;
            this.CPF = CPF;
            this.email = email;
         }

    }
}
