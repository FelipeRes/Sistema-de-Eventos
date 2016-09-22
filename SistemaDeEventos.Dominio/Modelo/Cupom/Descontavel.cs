using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Eventos.Modelo.Cupons {
    public interface Descontavel {
        int Id { get; set; }
        double GetDesconto(double valorRecebido);
    }
}
