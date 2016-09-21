using Sistema_de_Eventos.Modelo.Espaco;
using Sistema_de_Eventos.NHibernateHelp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Eventos.Modelo.Eventos {
    public class FabricarAtividade {
        public static Atividade Complementar(string nome) {
            AtividadeDefault atividade = new AtividadeDefault(nome);
            atividade.Estado = EstadoDaAtividade.Aberto;
            atividade.espacoFisico = FabricarEspaco.Vazio();
            return atividade;
        }
        public static Atividade Simples(string nome) {
            AtividadeSimples atividade = new AtividadeSimples();
            atividade.Nome = nome;
            atividade.Estado = EstadoDaAtividade.Aberto;
            atividade.espacoFisico = FabricarEspaco.Vazio();
            NHibernateHelper.SaveOrUpdate(ref atividade);
            return atividade;
        }
        public static Evento Evento() {
            Evento evento = new Evento();
            evento.Estado = EstadoDaAtividade.Aberto;
            evento.espacoFisico = FabricarEspaco.Vazio();
            ListaAtividade listaAtividade = new ListaAtividade();
            evento.Atividades = listaAtividade;
            NHibernateHelper.SaveOrUpdate(ref listaAtividade);
            NHibernateHelper.SaveOrUpdate(ref evento);
            return evento;
        }
    }
}
