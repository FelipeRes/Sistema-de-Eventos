using FluentNHibernate.Mapping;
using Sistema_de_Eventos.Modelo.Eventos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Eventos.Map.Atividades {
    public class AtividadeMap : ClassMap<Atividade> {
        public AtividadeMap() {
            Id(x => x.Id);
            HasMany(x => x.inscritos);
            Map(x => x.Nome);
            References(x => x.Lugar);
            Map(x => x.Preco);
            Map(x => x.Isolada);
            Map(o => o.Estado).CustomType<EstadoDaAtividade>();
            Map(x => x.DataInicio).CustomSqlType("datetime2").Not.Nullable();
            Map(x => x.DataFim).CustomSqlType("datetime2").Not.Nullable();
            //Map(x => x.Estado);
            DiscriminateSubClassesOnColumn("type");
        }
    }
}
