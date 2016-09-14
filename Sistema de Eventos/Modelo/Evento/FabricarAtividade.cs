using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Eventos.AtividadePack {
    public class FabricarAtividade {
        public static Atividade Complementar(string nome) {
            AtividadeDefault atividade = new AtividadeDefault(nome);
            atividade.Estado = EstadoDaAtividade.Aberto;
            return atividade;
        }
        public static Atividade Simples(string nome) {
            AtividadeSimples atividade = new AtividadeSimples(nome);
            atividade.Estado = EstadoDaAtividade.Aberto;
            return atividade;
        }
        public static Evento Evento() {
            Evento evento = new Evento();
            evento.Estado = EstadoDaAtividade.Aberto;
            return evento;
        }
    }
}
