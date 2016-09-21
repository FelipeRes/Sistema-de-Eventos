using Sistema_de_Eventos.Modelo.Eventos;
using Sistema_de_Eventos.NHibernateHelp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Eventos.Modelo.Espaco {
    public class FabricarEspaco{
        static public EspacoSimples Simples(int capacidade, string nome) {
            EspacoSimples espaco = new EspacoSimples();
            espaco.nome = nome;
            espaco.capacidade = capacidade;
            ListaAtividade listaDeAtividades = new ListaAtividade();
            espaco.Atividades = listaDeAtividades;
            NHibernateHelper.SaveOrUpdate(ref listaDeAtividades);
            NHibernateHelper.SaveOrUpdate(ref espaco);
            return espaco;
        }
        static public BuilderEspcacoComposto Composto(string nome) {
            return new BuilderEspcacoComposto(nome);
        }
        static public EspacoSimples Vazio() {
            EspacoSimples espaco = new EspacoSimples();
            espaco.nome = "";
            espaco.capacidade = 0;
            ListaAtividade listaDeAtividades = new ListaAtividade();
            espaco.Atividades = listaDeAtividades;
            NHibernateHelper.SaveOrUpdate(ref listaDeAtividades);
            NHibernateHelper.SaveOrUpdate(ref espaco);
            return espaco;
        }

        public class BuilderEspcacoComposto {
            private EspacoComposto espacoComposto;
            public BuilderEspcacoComposto(string nome) {
                espacoComposto = new EspacoComposto();
                espacoComposto.nome = nome;
                ListaAtividade listaAtividade = new ListaAtividade();
                espacoComposto.Atividades = listaAtividade;
                NHibernateHelper.SaveOrUpdate(ref listaAtividade);
            }
            public BuilderEspcacoComposto CriarEspaco(string nome, int quantidade) {
                EspacoSimples espacoSimples = new EspacoSimples();
                espacoSimples.nome = nome;
                espacoSimples.capacidade = quantidade;
                ListaAtividade listaAtividade = new ListaAtividade();
                espacoSimples.Atividades = listaAtividade;
                NHibernateHelper.SaveOrUpdate(ref listaAtividade);
                NHibernateHelper.SaveOrUpdate(ref espacoSimples);
                espacoComposto.AdicionarInterior(espacoSimples);
                return this;
            }
            public BuilderEspcacoComposto AdicionarEspaco(EspacoFisico espaco) {
                NHibernateHelper.SaveOrUpdate(ref espaco);
                espacoComposto.AdicionarInterior(espaco);
                return this;
            }
            public EspacoComposto build() {
                NHibernateHelper.SaveOrUpdate(ref espacoComposto);
                return espacoComposto;
            }
        }
    }
}
