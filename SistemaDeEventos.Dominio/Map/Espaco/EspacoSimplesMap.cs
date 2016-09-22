using FluentNHibernate.Mapping;
using Sistema_de_Eventos;
using Sistema_de_Eventos.Modelo.Espaco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Eventos.Map.Espaco {
    public class EspacoSimplesMap : SubclassMap<EspacoSimples> {
        public EspacoSimplesMap() {
            DiscriminatorValue(0);
        }
    }
}
