using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Eventos.Modelo.Eventos {
    public class ListaAtividade {

        public virtual int Id { get; set; }
        public virtual IList<Atividade> lista { get; set; }

        public ListaAtividade() {
            lista = new List<Atividade>();
        }

        public virtual void Adicionar(Atividade atividade) {
            if (!lista.Contains(atividade)) {
                lista.Add(atividade);
            } else {
                throw new Exception("Atividade repetida");
            }
        }
        public virtual void Remover(Atividade atividade) {
            if (lista.Contains(atividade)) {
                lista.Remove(atividade);
            }
        }
        public virtual double ValorDeTodasAtividades {
            get {
                double valor = 0;
                for (int i = 0; i < lista.Count; i++) {
                    valor += lista[i].Preco;
                }
                return valor;
            }
        }
        public virtual int Quantidade { get { return lista.Count; } }

        public virtual bool Possui(Atividade atividade) {
            if (lista.Contains(atividade)) {
                return true;
            } else {
                return false;
            }
        }
    }
}
