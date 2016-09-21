using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Eventos.Modelo.Cupons {
    public class Cupom {
        private Descontavel desconto;
        private Descontavel Desconto { get { return desconto; } }
        private bool usado;
        private List<Cupom> comboCupom = new List<Cupom>();
        public bool Usado { get { return usado; }}
        public double GetDesconto(double valorRecebido) {
            if (!Usado) {
                double descontoTotal = 0;
                descontoTotal += desconto.GetDesconto(valorRecebido);
                if (comboCupom.Count > 0) {
                   for(int i = 0; i < comboCupom.Count; i++) {
                        descontoTotal +=comboCupom[i].GetDesconto(descontoTotal);
                    }
                }
                return descontoTotal;
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
        public Cupom AdicionarCupom(Cupom cupom) {
            comboCupom.Add(cupom);
            return this;
        }
    }
}
