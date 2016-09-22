using FluentNHibernate.Mapping;
using Sistema_de_Eventos.Modelo.Eventos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Eventos.Map.Atividades {
    public class ListaAtividadeMap : ClassMap<ListaAtividade> {
        public ListaAtividadeMap() {
            Id(x => x.Id);
            HasMany(x => x.lista).Cascade.All();
        }
    }
}
