using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Eventos {
    public class ListaAtividade {

        public List<Atividade> ListaDeAtividades;

        public ListaAtividade() {
            ListaDeAtividades = new List<Atividade>();
        }

        public void AdicionarAtividade(Atividade atividade) {
            if (!ListaDeAtividades.Contains(atividade)) {
                ListaDeAtividades.Add(atividade);
            } else {
                throw new Exception("Atividade repetida");
            }
        }
        public void RemoverAtividade(Atividade atividade) {
            if (ListaDeAtividades.Contains(atividade)) {
                ListaDeAtividades.Remove(atividade);
            }
        }
        public double ValorDeTodasAtividades() {
            double valor = 0;
            for (int i = 0; i < ListaDeAtividades.Count; i++) {
                valor += ListaDeAtividades[i].Preco;
            }
            return valor;
        }
        public int QunatidadeDeInscritos() {
            return ListaDeAtividades.Count;
        }
    }
}
