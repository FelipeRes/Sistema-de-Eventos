using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Eventos.Modelo {
    public class AgendaUtils {
        static public String QuadroDeHorariosDoEvento(Evento evento) {
            List<Atividade> lista = evento.ListaDeAtividades;
            List<Atividade> listaOrdenada = lista.OrderBy(o => o.DataInicio).ToList();
            string horarios = "\n";
            for (int i = 0; i < listaOrdenada.Count; i++) {
                horarios += listaOrdenada[i].Nome;
                horarios += " - Inicio: ";
                horarios += listaOrdenada[i].DataInicio.ToString();
                horarios += " - Fim: ";
                horarios += listaOrdenada[i].DataFim.ToString();
                horarios += "\n";
            }
            return horarios;
        }
        static public String QuadroDeHorariosDoLocal(EspacoFisico espaco) {
            List<Atividade> lista = espaco.ListaDeAtividades;
            List<Atividade> listaOrdenada = lista.OrderBy(o => o.DataInicio).ToList();
            string horarios = "\n";
            for (int i = 0; i < listaOrdenada.Count; i++) {
                horarios += listaOrdenada[i].Nome;
                horarios += " - Inicio: ";
                horarios += listaOrdenada[i].DataInicio.ToString();
                horarios += " - Fim: ";
                horarios += listaOrdenada[i].DataFim.ToString();
                horarios += "\n";
            }
            return horarios;
        }
    }
}
