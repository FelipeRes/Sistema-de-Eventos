using Sistema_de_Eventos.Modelo.Eventos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Eventos.Modelo.Cupons {
    public class Cupom {

        public virtual int Id { get; set; }
        
        //Todo desconto recebe um descontavel, esssa será a implementação de desconto
        private Descontavel desconto;
        public virtual Descontavel Desconto { get { return desconto; } set { desconto = value;} }

        private bool isUsado;
        public virtual bool IsUsado { get { return isUsado; } set { isUsado = value; } }

        //Um cupom tem uma lista de outros cupons
        public virtual IList<Cupom> comboCupom { get; set; }

        //Função que verifica que soma o desconto aos descontos que estão na lista
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
        //A marcação internal diz que o cupom não pode ser instanciado pela aplicação
        internal Cupom() {
            comboCupom = new List<Cupom>();
            isUsado = false;
        }
        //Função para adicionar mais cupons e fazer um combo deles
        public virtual Cupom AdicionarCupom(Cupom cupom) {
            comboCupom.Add(cupom);
            return this;
        }
    }
}
