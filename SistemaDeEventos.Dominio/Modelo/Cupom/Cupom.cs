using Sistema_de_Eventos.Modelo.Eventos;
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

        public virtual double GetDesconto(double valorRecebido, Inscricao inscricao) {
                double descontoTotal = 0;
                descontoTotal += desconto.GetDesconto(valorRecebido, inscricao);
                if (comboCupom.Count > 0) {
                   for(int i = 0; i < comboCupom.Count; i++) {
                        descontoTotal +=comboCupom[i].GetDesconto(descontoTotal, inscricao);
                    }
                }
                return descontoTotal;
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
