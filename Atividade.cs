using System;
using System.Collections.Generic;
using Sistema_de_Eventos.Exceptions;

namespace Sistema_de_Eventos {
    public class Atividade {

        private List<Inscricao> inscritos = new List<Inscricao>();

        private string nome;
        public string Nome { get { return nome; } set {nome = value; } }

        private DateTime data;
        public DateTime Data { get { return data; } set { data = value; } }

        private int horarioInicio;
        public int HorarioInicio {
            get {
                return horarioInicio;
            }
            set {
                if (value > 12 || value < 0) {
                    throw new ArgumentException("Horario Invalido");
                } else {
                    horarioInicio = value;
                }
            }
        }
        public int QuantidadeDeInscritos { get {return inscritos.Count; } }

        private int horarioFim;
        public int HorarioFim {
            get {
                return horarioFim; }
            set {
                if (value > 12 || value < 0) {
                    throw new ArgumentException("Horario Invalido");
                }else {
                    horarioFim = value;
                }
            }
        }

        private double preco;
        public double Preco { get { return preco; } set { preco = value; } }

        private string local;
        public string Local { get { return local; } set { local = value; } }

        private int quantidadeMaximaPessoas;
        public int QuantidadeMaximaPessoas { get { return quantidadeMaximaPessoas; } set { quantidadeMaximaPessoas = value; } }

        public Atividade() {

        }
        public Atividade(string nome, double preco) {
            Nome = nome;
            Preco = preco;
        }
        public Atividade(string nome, double preco, int quantidade) {
            Nome = nome;
            Preco = preco;
            quantidadeMaximaPessoas = quantidade;
        }
        public void AdicionarInscritos(Inscricao inscricao) {
            if (QuantidadeDeInscritos < QuantidadeMaximaPessoas) {
                inscritos.Add(inscricao);
            }else {
                throw new NumeroMaximoDeInscritosException();
            }
        }
        public void RemoverInscritos(Inscricao inscricao) {
            if (inscritos.Contains(inscricao)) {
                inscritos.Remove(inscricao);
            }
        }
    }
}
