using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Eventos {
    public class DescontoValor : Descontavel {
        private double valor;
        public double GetDesconto(double valorRecebido) {
            return valor;
        }
        public DescontoValor(double valor) {
            this.valor = valor;
        }
    }
}
