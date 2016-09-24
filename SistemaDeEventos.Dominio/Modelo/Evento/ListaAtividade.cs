using SistemaDeEventos.Dominio.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Eventos.Modelo.Eventos {
    public class ListaAtividade {

        //Essa classe é apenas uma abstração de lista com várias implementações uteis pare esse sistema
        //Ela é usada para evitar repetição de código

        public virtual int Id { get; set; }
        public virtual IList<Atividade> lista { get; set; }

        public ListaAtividade() {
            lista = new List<Atividade>();
        }

        public virtual void Adicionar(Atividade atividade) {
            if (!lista.Contains(atividade)) {
                lista.Add(atividade);
            } else {
                throw new AtividadeRepetidaException("Esta lista ja contem esta atividade");
            }
        }
        public virtual void Remover(Atividade atividade) {
            if (lista.Contains(atividade)) {
                lista.Remove(atividade);
            }else {
                //throw new AtividadeNaoEncontradaException("Essa atividade nao existe nessa lista");
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
