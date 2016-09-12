using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Eventos.Modelo {
    public class AgendaUtils {
        static public String QuadroDeHorariosDoEvento(Atividade evento) {
            /*List<Atividade> lista = (List<Atividade>)Atividade.Atividades.Lista;
            lista.Add(Atividade);
            List<Atividade> listaOrdenada = lista.OrderBy(o => o.DataInicio).ToList(); 
            string horarios = "\n";
            for (int i = 0; i < listaOrdenada.Count; i++) {
                horarios += listaOrdenada[i].Nome;
                horarios += " - Inicio: ";
                horarios += listaOrdenada[i].DataInicio.ToString();
                horarios += " - Fim: ";
                horarios += listaOrdenada[i].DataFim.ToString();
                horarios += "\n";
            }*/
            string horarios = "\n";
            return horarios;
        }
        static public String QuadroDeHorariosDoLocal(EspacoFisico espaco) {
            List<Atividade> lista = (List<Atividade>)espaco.ListaDeAtividades;
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
