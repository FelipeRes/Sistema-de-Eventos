using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Eventos {
    public class GerenciaAtividade {

        public List<Atividade> ListaDeAtividades = new List<Atividade>();

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
            } else {
                throw new Exception("Atividade nao existe");
            }
        }
    }
}
