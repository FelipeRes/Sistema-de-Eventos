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
                horarios += "Evento: "+Nome;
                horarios += " - Inicio: ";
                horarios += DataInicio.ToString();
                horarios += " - Fim: ";
                horarios += DataFim.ToString();
                List<Atividade> lista = Atividades.Lista;
                List<Atividade> listaOrdenada = lista.OrderBy(o => o.DataInicio).ToList();
                for (int i = 0; i < listaOrdenada.Count; i++) {
                    horarios += listaOrdenada[i].Agenda;
                    //horarios += "\n";
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
                notificador.AdicionarNotificavel(inscricao.User);
                for (int i = 0; i<Atividades.Lista.Count; i++) {
                    Atividades.Lista[i].AdicionarInscritos(inscricao, addAtividade);
                }
            }
        }
        public override void RemoverInscritos(Inscricao inscricao, Inscricao.RemoveAtividade removeAtividade) {
            if (inscritos.Contains(inscricao)) {
                inscritos.Remove(inscricao);
                notificador.AdicionarNotificavel(inscricao.User);
                for (int i = 0; i < Atividades.Lista.Count; i++) {
                    Atividades.Lista[i].RemoverInscritos(inscricao, removeAtividade);
                }
            }
        }

        protected override void Notificar(string Mensagem) {
            notificador.AtualizarNotificaveis(Mensagem);
        }
    }
}
