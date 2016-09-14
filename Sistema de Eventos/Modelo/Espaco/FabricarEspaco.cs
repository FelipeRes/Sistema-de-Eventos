using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Eventos {
    public class FabricarEspaco {
        static public EspacoSimples Simples(int capacidade, string nome) {
            return new EspacoSimples(capacidade, nome);
        }
        static public EspacoComposto Composto(string nome) {
            return new EspacoComposto(nome, new EspacoVazio());
        }
        static public EspacoVazio Vazio() {
            return new EspacoVazio();
        }
    }
}
