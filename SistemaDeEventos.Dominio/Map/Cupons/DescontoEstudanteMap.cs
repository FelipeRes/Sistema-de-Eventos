using FluentNHibernate.Mapping;
using Sistema_de_Eventos.Map.Cupons;
using SistemaDeEventos.Dominio.Modelo.Cupons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Eventos.Map.Cupons {
    public class DescontoEstudanteMap : SubclassMap<DescontoAluno> {
        public DescontoEstudanteMap() {
            DiscriminatorValue(2);
            Map(x => x.porcentagem);
        }
    }
}
