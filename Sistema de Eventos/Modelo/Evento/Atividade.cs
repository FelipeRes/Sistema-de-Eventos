using System;
using System.Collections.Generic;

namespace Sistema_de_Eventos {
    public class Atividade {

        private List<Inscricao> inscritos = new List<Inscricao>();

        private Evento evento;
        public Evento EventoDaAtividade { get { return evento; }}

        private string nome;
        public string Nome { get { return nome; } set {nome = value; } }

        private DateTime dataInicio;
        public DateTime DataInicio { get { return dataInicio; } set { dataInicio = value; } }

        private EspacoFisico espacoFisico;
        public EspacoFisico Lugar {
            get {
                if (espacoFisico == null) {
                    return new EspacoVazio();
                } else {
                    return espacoFisico;
                }
            }
            set {
                espacoFisico.RemoverAtividade(this);
                value.AdicionarAtividade(this);
                espacoFisico = value;
            }
        }

        private DateTime dataFim;
        public DateTime DataFim { get { return dataFim; } set { dataFim = value; } }

        public int QuantidadeDeInscritos { get {return inscritos.Count; } }

        public int QuantidadeDeInscritosPagos {
            get {
                int quantidadePagos =0;
                for (int i = 0; i < QuantidadeDeInscritos; i++) {
                    if (inscritos[i].Pagamento) {
                        quantidadePagos++;
                    }
                }
                return quantidadePagos;
            }
        }

        private double preco;
        public double Preco { get { return preco; } set { preco = value; } }
        public Atividade(Evento evento, string nome) {
            this.evento = evento;
            evento.AdicionarAtividade(this);
            this.nome = nome;
            espacoFisico = new EspacoVazio();
        }
        public void AdicionarInscritos(Inscricao inscricao) {
            if (!inscritos.Contains(inscricao)) {
                inscritos.Add(inscricao);
            }
        }
        public void RemoverInscritos(Inscricao inscricao) {
            if (inscritos.Contains(inscricao)) {
                inscritos.Remove(inscricao);
            }
        }
    }
}
