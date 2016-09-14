using System;
using System.Collections.Generic;

namespace Sistema_de_Eventos.AtividadePack {
    public abstract class Atividade {

        protected List<Inscricao> inscritos;
        public IReadOnlyList<Inscricao> ListaDeInscritos { get { return inscritos; } }

        protected Notificador notificador;

        protected string nome;
        public string Nome { get { return nome; } set { nome = value; } }

        protected DateTime dataInicio;
        public DateTime DataInicio { get { return dataInicio; } set { dataInicio = value; Notificar("Horario de inicio:" + dataInicio.ToString()); } }

        protected DateTime dataFim;
        public DateTime DataFim { get { return dataFim; } set { dataFim = value; Notificar("Horario de termino: " + dataFim.ToString()); } }

        protected EstadoDaAtividade estadoDaAtividade;
        public EstadoDaAtividade Estado { get { return estadoDaAtividade; } set { estadoDaAtividade = value; } }

        protected double preco;
        public virtual double Preco { get { return preco; } set { preco = value; } }

        public int QuantidadeDeInscritos { get { return inscritos.Count; } }

        public abstract string Agenda { get; }

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
        public void ChecarCheckIn(Inscricao inscricao) {
            if (inscritos.Contains(inscricao)) {
                inscricao.ConfirmarCheckIn();
            }
        }

        protected abstract void Notificar(string Mensagem);
        public abstract void AdicionarInscritos(Inscricao inscricao, Inscricao.AddAtividade addAtividade);
        public abstract void RemoverInscritos(Inscricao inscricao, Inscricao.RemoveAtividade removeAtividade);
    }
}
