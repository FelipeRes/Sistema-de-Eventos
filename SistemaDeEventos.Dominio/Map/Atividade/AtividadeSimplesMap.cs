using FluentNHibernate.Mapping;
using Sistema_de_Eventos.Modelo.Eventos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Eventos.Map.Atividades {
    public class AtividadeSimplesMap : SubclassMap<AtividadeSimples> {
        public AtividadeSimplesMap() {
            DiscriminatorValue(0);
        }
    }
}
