using Sistema_de_Eventos.Modelo;
using Sistema_de_Eventos.Modelo.Controle;
using Sistema_de_Eventos.Modelo.Cupons;
using Sistema_de_Eventos.Modelo.Eventos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Eventos.Modelo.Espaco {
    public abstract class EspacoFisico {

        protected int capacidade;
        protected string nome;

        abstract public string Nome { get; }
        abstract public int Capacidade { get; }

        protected ListaAtividade Atividade;
        public IReadOnlyList<Atividade> ListaDeAtividades { get {return Atividade.Lista; } }

        public void AdicionarAtividade(Atividade atividade) {
            Atividade.Adicionar(atividade);
        }
        public void RemoverAtividade(Atividade atividade) {
            Atividade.Remover(atividade);
        }
    }
}
