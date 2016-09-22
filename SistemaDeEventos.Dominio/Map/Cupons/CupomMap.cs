using FluentNHibernate.Mapping;
using Sistema_de_Eventos;
using Sistema_de_Eventos.Modelo.Cupons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Eventos.Map.Cupons {
    public class CupomMap : ClassMap<Cupom> {
        public CupomMap() {
            Id(x => x.Id);
            Map(x => x.IsUsado);
            References(x => x.Desconto);
            HasMany(x => x.comboCupom).Cascade.All();
        }
    }
}
