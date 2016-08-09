using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Eventos.Modelo {
    public class Sala : EspacoFisico {

        private int capacidade;
        private string nome;
        public int Capacidade {get {return capacidade;}}
        public string Nome {get {return nome; } }

        public Sala(int capacidade, string nome) {
            this.capacidade = capacidade;
            this.nome = nome;
        }
    }
}
