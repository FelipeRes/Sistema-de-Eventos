using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Eventos.Modelo.Evento {
    public class ListaAtividade {

        private List<Atividade> lista;

        public ListaAtividade() {
            lista = new List<Atividade>();
        }

        public void Adicionar(Atividade atividade) {
            if (!lista.Contains(atividade)) {
                lista.Add(atividade);
            } else {
                throw new Exception("Atividade repetida");
            }
        }
        public void Remover(Atividade atividade) {
            if (lista.Contains(atividade)) {
                lista.Remove(atividade);
            }
        }
        public double ValorDeTodasAtividades{
            get {
                double valor = 0;
                for (int i = 0; i < lista.Count; i++) {
                    valor += lista[i].Preco;
                }
                return valor;
            }
        }
        public int Quantidade {get { return lista.Count; }}

        public bool Possui(Atividade atividade) {
                if (lista.Contains(atividade)) {
                    return true;
                } else {
                    return false;
                }
        }
        public List<Atividade> Lista {
            get { return lista; }
        }
    }
}
