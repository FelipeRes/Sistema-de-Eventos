using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Eventos.Modelo.Espaco {
    public class FabricarEspaco{
        static public EspacoSimples Simples(int capacidade, string nome) {
            return new EspacoSimples(capacidade, nome);
        }
        static public BuilderEspcacoComposto Composto(string nome) {
            return new BuilderEspcacoComposto(nome);
        }
        static public EspacoVazio Vazio() {
            return new EspacoVazio();
        }

        public class BuilderEspcacoComposto {
            private EspacoComposto espacoComposto;
            public BuilderEspcacoComposto(string nome) {
                espacoComposto = new EspacoComposto(nome);
            }
            public BuilderEspcacoComposto CriarEspaco(string nome, int quantidade) {
                EspacoSimples espacoSimples = new EspacoSimples(quantidade, nome);
                espacoComposto.AdicionarInterior(espacoSimples);
                return this;
            }
            public BuilderEspcacoComposto AdicionarEspaco(EspacoFisico espaco) {
                espacoComposto.AdicionarInterior(espaco);
                return this;
            }
            public EspacoComposto build() {
                return espacoComposto;
            }
        }
    }
}
