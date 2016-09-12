using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;


namespace Sistema_de_Eventos {
    public class Evento : Atividade {
        
        public ListaAtividade Atividades;

        public override double Preco {
            get {
                double PrecoFinal = 0;
                for (int i = 0; i < Atividades.Quantidade; i++) {
                    PrecoFinal += Atividades.Lista[i].Preco;
                }
                return preco + PrecoFinal;
            }
            set {
                preco = value;
            }
        }

        public override int QuantidadeDeInscritos {
            get {
                int quantidade = 0;
                for (int i = 0; i < Atividades.Lista.Count; i++) {
                    quantidade += Atividades.Lista[i].QuantidadeDeInscritos;
                }
                return quantidade + inscritos.Count;
            }
        }

        public override int QuantidadeDeInscritosPagos {
            get {
                int quantidadePagos = 0;
                for (int i = 0; i < QuantidadeDeInscritos; i++) {
                    if (inscritos[i].Pagamento) {
                        quantidadePagos++;
                    }
                }
                return quantidadePagos;
            }
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

        public Evento() {
            EspacoFisico espacoFisico = new EspacoVazio();
            Estado = EstadoDaAtividade.Aberto;
            Atividades = new ListaAtividade();
        }

    }
}
