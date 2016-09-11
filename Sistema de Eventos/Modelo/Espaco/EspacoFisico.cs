using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Eventos {
    public abstract class EspacoFisico {

        protected int capacidade;
        protected string nome;

        abstract public string Nome { get; }
        abstract public int Capacidade { get; }

        protected ListaAtividade listaDeAtividades;
        public List<Atividade> ListaDeAtividades { get {return listaDeAtividades.ListaDeAtividades; } }

        public void AdicionarAtividade(Atividade atividade) {
            listaDeAtividades.AdicionarAtividade(atividade);
        }
        public void RemoverAtividade(Atividade atividade) {
            listaDeAtividades.RemoverAtividade(atividade);
        }
    }
}
