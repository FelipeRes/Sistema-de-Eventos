using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Eventos {
    public class FabricarCupom {
        public static Cupom DescontoPorcentagem(double valor) {
            Descontavel desconto = new DescontoPorcentagem(valor);
            Cupom cupom = new Cupom(desconto);
            return cupom;
        }
        public static Cupom DescontoPorValor(double valor) {
            Descontavel desconto = new DescontoValor(valor);
            Cupom cupom = new Cupom(desconto);
            return cupom;
        }
    }
}
