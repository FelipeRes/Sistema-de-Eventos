using FluentNHibernate.Mapping;
using SistemaDeEventos.Dominio.Modelo.Controle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeEventos.Dominio.Map.Controle {
    public class PerfilParticipanteMap : SubclassMap<PerfilParticipante> {
        public PerfilParticipanteMap() {
            DiscriminatorValue(0);
        }
    }
}
