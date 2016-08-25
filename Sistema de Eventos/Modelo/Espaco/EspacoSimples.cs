using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Eventos{
    public class EspacoSimples : EspacoFisico {

        protected int capacidade;
        protected string nome;

        public override string Nome { get { return nome; } }
        public override int Capacidade { get { return capacidade; } }

        public EspacoSimples(int capacidade, string nome) {
            this.capacidade = capacidade;
            this.nome = nome;
            listaDeAtividades = new GerenciaAtividade();
        }
    }
}
