using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Eventos {
    public class Cupom {
        private Descontavel desconto;
        private Descontavel Desconto { get { return desconto; } }
        public double GetDesconto(double valor) {
            return desconto.GetDesconto(valor);
        }
        public Cupom(Descontavel desconto) {
            this.desconto = desconto;
        }
    }
}
