using Sistema_de_Eventos.Modelo.Espaco;
using Sistema_de_Eventos.Modelo.Notificacoes;
using System;
using System.Collections.Generic;

namespace Sistema_de_Eventos.Modelo.Eventos {
    public abstract class Atividade {

        public virtual int Id { get; set; }

        public virtual IList<Inscricao> inscritos { get; set; }

        protected Notificador notificador;

        protected string nome;
        public virtual string Nome { get { return nome; } set { nome = value; } }

        protected DateTime dataInicio;
        public virtual DateTime DataInicio { get { return dataInicio; } set { dataInicio = value; Notificar("Horario de inicio:" + dataInicio.ToString()); } }

        protected DateTime dataFim;
        public virtual DateTime DataFim { get { return dataFim; } set { dataFim = value; Notificar("Horario de termino: " + dataFim.ToString()); } }

        protected EstadoDaAtividade estadoDaAtividade;
        public virtual EstadoDaAtividade Estado { get { return estadoDaAtividade; } set { estadoDaAtividade = value; } }

        protected double preco;
        public virtual double Preco { get { return preco; } set { preco = value; } }

        public virtual int QuantidadeDeInscritos { get { return inscritos.Count; } }

        public abstract string Agenda { get; }

        public virtual EspacoFisico espacoFisico { get; set; }
        public virtual EspacoFisico Lugar {
            get {
                return espacoFisico;
            }
            set {
                espacoFisico.Atividades.Remover(this);
                value.Atividades.Adicionar(this);
                espacoFisico = value;
            }
        }
        public virtual void ChecarCheckIn(Inscricao inscricao) {
            if (inscritos.Contains(inscricao)) {
                inscricao.ConfirmarCheckIn();
            }
        }

        protected abstract void Notificar(string Mensagem);
        public abstract void AdicionarInscritos(Inscricao inscricao, Inscricao.AddAtividade addAtividade);
        public abstract void RemoverInscritos(Inscricao inscricao, Inscricao.RemoveAtividade removeAtividade);
    }
}
