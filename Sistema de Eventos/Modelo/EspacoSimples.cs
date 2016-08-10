using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Eventos{
    public class EspacoSimples : EspacoFisico {

        private int capacidade;
        private string nome;
        public int Capacidade {get {return capacidade;}}
        public string Nome {get {return nome; } }

        public EspacoSimples(int capacidade, string nome) {
            this.capacidade = capacidade;
            this.nome = nome;
        }
    }
}
