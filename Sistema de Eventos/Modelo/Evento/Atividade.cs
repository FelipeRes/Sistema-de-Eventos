using System;
using System.Collections.Generic;

namespace Sistema_de_Eventos {
    public abstract class Atividade {

        protected List<Inscricao> inscritos;

        protected string nome;
        public string Nome { get { return nome; } set { nome = value; } }

        protected DateTime dataInicio;
        public DateTime DataInicio { get { return dataInicio; } set { dataInicio = value; } }

        protected DateTime dataFim;
        public DateTime DataFim { get { return dataFim; } set { dataFim = value; } }

        protected EstadoDaAtividade estadoDaAtividade;
        public EstadoDaAtividade Estado { get { return estadoDaAtividade; } set { estadoDaAtividade = value; } }

        protected double preco;
        public abstract double Preco { get; set; }

        public abstract int QuantidadeDeInscritos { get; }

        public abstract int QuantidadeDeInscritosPagos { get; }

        public abstract String Agenda { get; }

        protected EspacoFisico espacoFisico;
        public EspacoFisico Lugar {
            get {
                return espacoFisico;
            }
            set {
                espacoFisico.RemoverAtividade(this);
                value.AdicionarAtividade(this);
                espacoFisico = value;
            }
        }

        public Atividade(String nome) {
            inscritos = new List<Inscricao>();
            this.nome = nome;
            espacoFisico = new EspacoVazio();
        }
        public Atividade() {
            inscritos = new List<Inscricao>();
            espacoFisico = new EspacoVazio();
        }

        public abstract void AdicionarInscritos(Inscricao inscricao);
        public abstract void RemoverInscritos(Inscricao inscricao);
    }
}
