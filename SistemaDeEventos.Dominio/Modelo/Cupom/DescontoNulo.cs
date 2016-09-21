using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Eventos.Modelo.Cupons {
    class DescontoNulo : Descontavel {
        public virtual int Id { get; set; }
        public double GetDesconto(double valorRecebido) {
            return 0;
        }
    }
}
