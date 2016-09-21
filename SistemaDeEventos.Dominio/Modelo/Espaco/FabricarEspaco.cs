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
            NHibernateHelper.SaveOrUpdate(ref espaco);
            return espaco;
        }

        public class BuilderEspcacoComposto {
            private EspacoComposto espacoComposto;
            public BuilderEspcacoComposto(string nome) {
                espacoComposto = new EspacoComposto();
                espacoComposto.nome = nome;
            }
            public BuilderEspcacoComposto CriarEspaco(string nome, int quantidade) {
                EspacoSimples espacoSimples = new EspacoSimples();
                espacoSimples.nome = nome;
                espacoSimples.capacidade = quantidade;
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
