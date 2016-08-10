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
        public EspacoFisico lugar {
            get {
                if (espacoFisico == null) {
                    return new EspacoVazio();
                } else {
                    return espacoFisico;
                }
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

        public int QuantidadeMaximaPessoas { get { return lugar.Capacidade; } set {
                if (value >= QuantidadeDeInscritosPagos) {
                    EspacoSimples espaco = new EspacoSimples(value, lugar.Nome);
                    this.espacoFisico = espaco;
                }
            }
        }
        public Atividade(Evento evento, string lugar, int quantidade) {
            this.evento = evento;
            evento.AdicionarAtividade(this);
            QuantidadeMaximaPessoas = quantidade;
            EspacoSimples espaco = new EspacoSimples(quantidade, nome);
            this.espacoFisico = espaco;
        }
        public void AdicionarInscritos(Inscricao inscricao) {
            if (QuantidadeDeInscritos < QuantidadeMaximaPessoas && !inscritos.Contains(inscricao)) {
                inscritos.Add(inscricao);
            }
        }
        public void RemoverInscritos(Inscricao inscricao) {
            if (inscritos.Contains(inscricao)) {
                inscritos.Remove(inscricao);
            }
        }
        public void MudarEspacoFisico(string nome, int capacidade) {
            EspacoSimples espaco = new EspacoSimples(capacidade, nome);
            this.espacoFisico = espaco;
        }
    }
}
