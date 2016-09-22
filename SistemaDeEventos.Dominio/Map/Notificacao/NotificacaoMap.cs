using FluentNHibernate.Mapping;
using Sistema_de_Eventos;
using Sistema_de_Eventos.Modelo.Notificacoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Eventos.Map.Notificao {
    public class NotificacaoMap : SubclassMap<Notificacao>{
        public NotificacaoMap() {
            HasMany(x => x.listaObservadores).Cascade.All();
            DiscriminatorValue(0);
        }
    }
}
