using Sistema_de_Eventos.Modelo.Eventos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Eventos.Modelo.Espaco {
    public class EspacoSimples : EspacoFisico {

        public override string Nome { get { return nome; } set { nome = value; } }
        public override int Capacidade { get { return capacidade; } set { capacidade = value; } }

        internal EspacoSimples() {
        }
    }
}
