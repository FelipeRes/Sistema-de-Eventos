using FluentNHibernate.Mapping;
using Sistema_de_Eventos;
using Sistema_de_Eventos.Modelo.Cupons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Eventos.Map.Cupons {
    public class DescontoValorMap : SubclassMap<DescontoValor> {
        public DescontoValorMap() {
            DiscriminatorValue(1);
            Map(x => x.valor);
        }
    }
}
