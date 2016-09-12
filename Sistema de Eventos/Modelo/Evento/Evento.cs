using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;


namespace Sistema_de_Eventos {
    public class Evento : Atividade {
        
        public ListaAtividade Atividades;

        public Evento() {
            EspacoFisico espacoFisico = new EspacoVazio();
            Estado = EstadoDoEvento.Aberto;
            Atividades = new ListaAtividade();
        }

        public override String Agenda {
            get {
                string horarios = "\n";
                List<Atividade> lista = (List<Atividade>)this.Atividades.Lista;
                lista.Add(this);
                List<Atividade> listaOrdenada = lista.OrderBy(o => o.DataInicio).ToList();
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
}
