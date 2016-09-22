using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Eventos.Modelo.Cupons {
    public class DescontoPorcentagem : Descontavel {

        public virtual int Id { get; set; }

        public virtual double porcentagem { get; set; }

        public virtual double GetDesconto(double valorRecebido, Inscricao inscricao) {
            return valorRecebido / 100 * porcentagem;
        }
        internal DescontoPorcentagem() {
        }
    }
}
