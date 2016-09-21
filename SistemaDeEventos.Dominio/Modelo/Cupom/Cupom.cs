using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Eventos.Modelo.Cupons {
    public class Cupom {

        public virtual int Id { get; set; }

        private Descontavel desconto;
        public virtual Descontavel Desconto { get { return desconto; } set { desconto = value;} }

        private bool isUsado;
        public virtual bool IsUsado { get { return isUsado; } set { isUsado = value; } }

        public virtual IList<Cupom> comboCupom { get; set; }

        public virtual double GetDesconto(double valorRecebido) {
            if (!IsUsado) {
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
        public virtual void Invalidar() {
            isUsado = true;
        }
        internal Cupom() {
            comboCupom = new List<Cupom>();
            isUsado = false;
        }
        public virtual Cupom AdicionarCupom(Cupom cupom) {
            comboCupom.Add(cupom);
            return this;
        }
    }
}
