using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Eventos {
    public class EspacoVazio : EspacoFisico { 
        public int Capacidade { get {return 0;}}
        public string Nome {get {return "vazio"; }}
    }
}
