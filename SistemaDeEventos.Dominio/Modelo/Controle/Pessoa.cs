using Sistema_de_Eventos.NHibernateHelp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Sistema_de_Eventos.Modelo.Controle {
    public class Pessoa {

        public virtual int Id { get; set; }

        public static PessoaBuilder BuildNome(string nome) {
            return new PessoaBuilder(nome);
        }

        private string nome;
        public virtual string Nome { get { return nome; } set { this.nome = value; } }

        private int idade;
        public virtual int Idade { get { return idade; } set { this.idade = value; } }

        private int cpf;
        public virtual int CPF { get { return cpf; } set { this.cpf = value; } } 

        private string descricao;
        public virtual string Descricao { get { return descricao; } set { this.descricao = value; } }

        private string endereco;
        public virtual string Endereco { get { return endereco; } set { this.endereco = value; } }

        private DateTime dataDeNascimento;
        public virtual DateTime DataDeNascimento { get { return dataDeNascimento; } set { this.dataDeNascimento = value; } }

        public Pessoa() {
        }
    }
    public class PessoaBuilder {
        private Pessoa pessoa;

        public PessoaBuilder (string nome) {
            pessoa = new Pessoa();
            pessoa.Nome = nome;
        }
        public virtual PessoaBuilder Idade(int idade) {
            pessoa.Idade = idade;
            return this;
        }
        public virtual PessoaBuilder CPF(int cpf) {
            pessoa.CPF = cpf;
            return this;
        }
        public virtual PessoaBuilder Descricao(string descricao) {
            pessoa.Descricao = descricao;
            return this;
        }
        public virtual PessoaBuilder Endereco(string endereco) {
            pessoa.Endereco = endereco;
            return this;
        }
        public virtual PessoaBuilder DataNascimento(DateTime data) {
            pessoa.DataDeNascimento = data;
            return this;
        }

        public virtual Pessoa build() {
            NHibernateHelper.SaveOrUpdate(ref pessoa);
            return pessoa;
        }
    }
   
}
