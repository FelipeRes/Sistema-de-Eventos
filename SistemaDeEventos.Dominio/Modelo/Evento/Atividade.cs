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

        //No set das datas, há o disparo de uma notificação
        protected DateTime dataInicio;
        public virtual DateTime DataInicio { get { return dataInicio; } set { dataInicio = value; Notificar("Horario de inicio:" + dataInicio.ToString()); } }

        protected DateTime dataFim;
        public virtual DateTime DataFim { get { return dataFim; } set { dataFim = value; Notificar("Horario de termino: " + dataFim.ToString()); } }

        //O estado da atividade é um enum
        protected EstadoDaAtividade estadoDaAtividade;
        public virtual EstadoDaAtividade Estado { get { return estadoDaAtividade; } set { estadoDaAtividade = value; } }

        protected double preco;
        public virtual double Preco { get { return preco; } set { preco = value; } }

        //A implementação muda em evento pq ele irá ver quem tá inscrito nas atividades
        public virtual int QuantidadeDeInscritos { get { return inscritos.Count; } }

        //Geração de agenda, em atividade, mostra apenas a atividade, em evento, mostra tudo
        public abstract string Agenda { get; }

        //Marca se a atividade pode receber uma inscricao automatica de evento 
        //ou se ela obrigatoriamente tem que ser inscrita de forma individual
        protected bool isolada;
        public abstract bool Isolada { get; set; }

        //O espaco fisico tem o registro da atividade relacionada a ele
        //se a atividade muda de espaco, ele recebe o valor da nova atividade que ele terá
        public virtual EspacoFisico espacoFisico { get; set; }
        public virtual EspacoFisico Lugar {
            get {
                return espacoFisico;
            }
            set {
                if (value != null) {
                    espacoFisico.Atividades.Remover(this);
                    value.Atividades.Adicionar(this);
                    espacoFisico = value;
                } else {
                    espacoFisico = value;
                }
            }
        }
        //checkin é só um boleando da inscricao, ele só pode ser confirmado pela atividade ou evento
        public virtual void ChecarCheckIn(Inscricao inscricao) {
            if (inscritos.Contains(inscricao)) {
                inscricao.ConfirmarCheckIn();
            }
        }

        //A implementação de notificação e a forma como adicionar inscritos fica em quem herda
        protected abstract void Notificar(string Mensagem);
        public abstract void AdicionarInscritos(Inscricao inscricao, Inscricao.AddAtividade addAtividade);
        public abstract void RemoverInscritos(Inscricao inscricao, Inscricao.RemoveAtividade removeAtividade);
    }
}
