using FluentNHibernate.Mapping;
using Sistema_de_Eventos;
using Sistema_de_Eventos.Modelo;
using SistemaDeEventos.Dominio.Modelo.Inscircoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Eventos.Map.Atividades {
    public class InscricaoMap : ClassMap<Inscricao> {
        public InscricaoMap() {
            Id(x => x.Id);
            HasMany(x => x.listaDeCupons).Cascade.All();
            Map(x => x.Pagamento);
            Map(x => x.Participacao).CustomType<TipoInscricao>();
            References(x => x.User);
            References(x => x.Atividades);
        }
    }
}
