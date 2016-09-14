using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Eventos.AtividadePack {
    public class FabricarAtividade {
        public static Atividade Complementar(string nome) {
            AtividadeDefault atividade = new AtividadeDefault(nome);
            return atividade;
        }
        public static Atividade Simples(string nome) {
            AtividadeSimples atividade = new AtividadeSimples(nome);
            return atividade;
        }
        public static Evento Evento() {
            return new Evento();
        }
    }
}
