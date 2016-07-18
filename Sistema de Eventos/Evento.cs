using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Eventos {
    public class Evento {
        private string nome;
        public string Nome { get { return nome; } set { this.nome = value; } }

        public List<Atividade> ListaDeAtividades = new List<Atividade>();
       
        public Evento() {
            ListaDeAtividades = new List<Atividade>();
        }
        public void AdicionarAtividade(Atividade atividade) {
            ListaDeAtividades.Add(atividade);
        }
        public void RemoverAtividade(Atividade atividade) {
            ListaDeAtividades.Remove(atividade);
        }
        
    }
}
