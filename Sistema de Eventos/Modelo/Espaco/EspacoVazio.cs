using Sistema_de_Eventos.AtividadePack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Eventos {
    public class EspacoVazio : EspacoFisico {
        public override int Capacidade { get {return 0;}}
        public override string Nome {get {return "vazio"; }}
        public EspacoVazio() {
            Atividade = new ListaAtividade();
        }
    }
}
