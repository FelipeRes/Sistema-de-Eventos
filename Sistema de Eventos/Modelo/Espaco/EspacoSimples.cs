using Sistema_de_Eventos.Modelo.Eventos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Eventos.Modelo.Espaco {
    public class EspacoSimples : EspacoFisico {

        protected int capacidade;
        protected string nome;

        public override string Nome { get { return nome; } }
        public override int Capacidade { get { return capacidade; } }

        public EspacoSimples(int capacidade, string nome) {
            this.capacidade = capacidade;
            this.nome = nome;
            Atividade = new ListaAtividade();
        }
    }
}
