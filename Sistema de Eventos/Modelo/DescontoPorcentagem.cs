﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Eventos {
    public class DescontoPorcentagem : Descontavel {
        public double GetDesconto(double valor) {
            return valor/100 *valor;
        }
    }
}
