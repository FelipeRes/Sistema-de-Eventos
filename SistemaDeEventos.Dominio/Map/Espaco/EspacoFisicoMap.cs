using FluentNHibernate.Mapping;
using Sistema_de_Eventos;
using Sistema_de_Eventos.Modelo.Espaco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Eventos.Map.Espaco {
    public class EspacoFisicoMap : ClassMap<EspacoFisico> {
        public EspacoFisicoMap() {
            Id(x => x.Id);
            Map(x => x.capacidade);
            Map(x => x.nome);
            References(x => x.Atividades);
            DiscriminateSubClassesOnColumn("type");
        }
    }
}
