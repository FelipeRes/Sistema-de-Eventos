using FluentNHibernate.Mapping;
using SistemaDeEventos.Dominio.Modelo.Controle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeEventos.Dominio.Map.Controle {
    public class PerfilMap : ClassMap<Perfil> {
        public PerfilMap() {
            Id(x => x.Id);
            References(x => x.User);
            DiscriminateSubClassesOnColumn("type");
        }
    }
}
