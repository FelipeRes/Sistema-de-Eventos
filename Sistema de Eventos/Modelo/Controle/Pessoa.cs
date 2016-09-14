using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Eventos {
    public class Pessoa {
        
        public static PessoaBuilder BuildNome(string nome) {
            return new PessoaBuilder(nome);
        }

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

        private string endereco;
        public string Endereco { get { return endereco; } set { this.endereco = value; } }

        private DateTime dataDeNascimento;
        public DateTime DataDeNascimento { get { return dataDeNascimento; } set { this.dataDeNascimento = value; } }

        public Pessoa() {
        }
    }
    public class PessoaBuilder {
        private Pessoa pessoa;

        public PessoaBuilder (string nome) {
            pessoa = new Pessoa();
            pessoa.Nome = nome;
        }
        public PessoaBuilder Idade(int idade) {
            pessoa.Idade = idade;
            return this;
        }
        public PessoaBuilder CPF(int cpf) {
            pessoa.CPF = cpf;
            return this;
        }
        public PessoaBuilder Email(string email) {
            pessoa.Email = email;
            return this;
        }
        public PessoaBuilder Descricao(string descricao) {
            pessoa.Descricao = descricao;
            return this;
        }
        public PessoaBuilder Endereco(string endereco) {
            pessoa.Endereco = endereco;
            return this;
        }
        public PessoaBuilder DataNascimento(DateTime data) {
            pessoa.DataDeNascimento = data;
            return this;
        }

        public Pessoa build() {
            return pessoa;
        }
    }
   
}
