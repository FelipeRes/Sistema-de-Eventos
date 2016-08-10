using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Eventos {
    public class Cupom {
        private Descontavel desconto;
        private Descontavel Desconto { get { return desconto; } }
        private bool usado;
        private Cupom comboCupom;
        public bool Usado { get { return usado; }}
        public double GetDesconto(double valorRecebido) {
            if (!Usado) {
                return desconto.GetDesconto(valorRecebido);
            }else {
                throw new Exception("Cupom ja utilizado");
            }
        }
        public void Invalidar() {
            usado = true;
        }
        public Cupom(Descontavel desconto) {
            this.desconto = desconto;
            usado = false;
        }
    }
}
