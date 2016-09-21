using FluentNHibernate.Mapping;
using Sistema_de_Eventos.Modelo;
using Sistema_de_Eventos.Modelo.Controle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Eventos.Map.Controle {
    public class OrganizacaoMap : ClassMap<Organizacao> {
        public OrganizacaoMap() {
            Id(x => x.Id);
            References(x => x.Organizador);
            HasMany(x => x.Colaboradores).Cascade.All();
        }

    }
}
