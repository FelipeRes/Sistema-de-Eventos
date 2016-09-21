using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Eventos.Modelo.Cupons {
    public class DescontoPorcentagem : Descontavel {
        private double porcentagem;
        public double GetDesconto(double valorRecebido) {
            return valorRecebido / 100 * porcentagem;
        }
        public DescontoPorcentagem(double porcentagem) {
            this.porcentagem = porcentagem;
        }
    }
}
