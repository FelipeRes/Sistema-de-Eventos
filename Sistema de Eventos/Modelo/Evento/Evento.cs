using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;


namespace Sistema_de_Eventos.AtividadePack {
    public class Evento : Atividade {
        
        public ListaAtividade Atividades;

        public override string Agenda {
            get {
                string horarios = "\n";
                List<Atividade> lista = Atividades.Lista;
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

        public Evento() {
            EspacoFisico espacoFisico = new EspacoVazio();
            Estado = EstadoDaAtividade.Aberto;
            Atividades = new ListaAtividade();
        }
        public override void AdicionarInscritos(Inscricao inscricao, Inscricao.AddAtividade addAtividade) {
            if (!inscritos.Contains(inscricao)) {
                inscritos.Add(inscricao);
                addAtividade(this);
                for(int i = 0; i<Atividades.Lista.Count; i++) {
                    Atividades.Lista[i].AdicionarInscritos(inscricao, addAtividade);
                }
            }
        }
        public override void RemoverInscritos(Inscricao inscricao, Inscricao.RemoveAtividade removeAtividade) {
            if (inscritos.Contains(inscricao)) {
                inscritos.Remove(inscricao);
                for (int i = 0; i < Atividades.Lista.Count; i++) {
                    Atividades.Lista[i].RemoverInscritos(inscricao, removeAtividade);
                }
            }
        }

    }
}
