using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Eventos {
    class DescontoNulo : Descontavel {
        public double GetDesconto(double valorRecebido) {
            return 0;
        }
    }
}
