using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using Sistema_de_Eventos.Modelo.Notificacoes;
using Sistema_de_Eventos.Modelo.Espaco;

namespace Sistema_de_Eventos.Modelo.Eventos {
    public class Evento : Atividade {

        public virtual ListaAtividade Atividades { get; set; }

        public override string Agenda {
            get {
                string horarios = "\n";
                horarios += "Evento: " + Nome;
                horarios += " - Inicio: ";
                horarios += DataInicio.ToString();
                horarios += " - Fim: ";
                horarios += DataFim.ToString();
                IList<Atividade> lista = Atividades.lista;
                List<Atividade> listaOrdenada = lista.OrderBy(o => o.DataInicio).ToList();
                for (int i = 0; i < listaOrdenada.Count; i++) {
                    horarios += listaOrdenada[i].Agenda;
                }
                return horarios;
            }
        }

        internal Evento() {
            inscritos = new List<Inscricao>();
            notificador = FabricaNotificacao.CriarNotificador();
            //espacoFisico = FabricarEspaco.Vazio();
        }
        public override void AdicionarInscritos(Inscricao inscricao, Inscricao.AddAtividade addAtividade) {
            if (!inscritos.Contains(inscricao)) {
                inscritos.Add(inscricao);
                addAtividade(this);
                //notificador.AdicionarNotificavel(inscricao.User);
                for (int i = 0; i < Atividades.lista.Count; i++) {
                    Atividades.lista[i].AdicionarInscritos(inscricao, addAtividade);
                }
            }
        }
        public override void RemoverInscritos(Inscricao inscricao, Inscricao.RemoveAtividade removeAtividade) {
            if (inscritos.Contains(inscricao)) {
                inscritos.Remove(inscricao);
                //notificador.RemoverNotificavel(inscricao.User);
                for (int i = 0; i < Atividades.lista.Count; i++) {
                    Atividades.lista[i].RemoverInscritos(inscricao, removeAtividade);
                }
            }
        }

        protected override void Notificar(string Mensagem) {
            string Complemento = "Prezado incrito, a data e horario do evento foram alteradas.";
            notificador.AtualizarNotificaveis(Complemento + Mensagem);
        }
    }
}
