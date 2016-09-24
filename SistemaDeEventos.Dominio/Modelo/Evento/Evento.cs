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

        //Essa lista é uma abstração que fiz para reduzir a repetição de código
        //ela é customizada e possui algumas implementações básicas
        public virtual ListaAtividade Atividades { get; set; }
        public override bool Isolada { get { return isolada; } set { isolada = value; } }

        //o evento marcado como unico inscreve automaticamente todos os incritos nas atividades
        public virtual bool isUnique { get; set;}

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
            isUnique = true;
            isolada = false;
        }
        //Ao adicionar um inscrito ele, o adiciona na lista do notificador
        //mas o inscrito só será notificado se ele adicionar algum veiculo de divulgação
        public override void AdicionarInscritos(Inscricao inscricao, Inscricao.AddAtividade addAtividade) {
            if (!inscritos.Contains(inscricao) && estadoDaAtividade != EstadoDaAtividade.InscricoesEncerradas) {
                inscritos.Add(inscricao);
                //usando delegate:
                //A inscricao delega a funcção de adicionar atividades (em inscricao) a propria atividade
                //a razão disso é para que condições como inscritos repetidos ou atividade encerrada ja são verificadas
                //nessa função e evita a repetição desse código lá em inscrição
                addAtividade(this);
                notificador.AdicionarNotificavel(inscricao.User);

                //quando o evento é unico, ele inscreve todas as atividades que não são isoladas
                if (isUnique) {
                    for (int i = 0; i < Atividades.lista.Count; i++) {
                        if (!Atividades.lista[i].Isolada) {
                            Atividades.lista[i].AdicionarInscritos(inscricao, addAtividade);
                        }
                    }
                }
            }
        }
        //aqui funciona como adicionar, só que removendo
        public override void RemoverInscritos(Inscricao inscricao, Inscricao.RemoveAtividade removeAtividade) {
            if (inscritos.Contains(inscricao) && estadoDaAtividade != EstadoDaAtividade.InscricoesEncerradas) {
                inscritos.Remove(inscricao);
                removeAtividade(this);
                notificador.RemoverNotificavel(inscricao.User);
                if (isUnique) {
                    for (int i = 0; i < Atividades.lista.Count; i++) {
                        if (!Atividades.lista[i].Isolada) {
                            Atividades.lista[i].RemoverInscritos(inscricao, removeAtividade);
                        }
                    }
                }
            }
        }
        //Implementação de notificação
        protected override void Notificar(string Mensagem) {
            string Complemento = "Prezado incrito, a data e horario do evento foram alteradas.";
            notificador.AtualizarNotificaveis(Complemento + Mensagem);
        }
    }
}
