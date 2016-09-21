using FluentNHibernate.Mapping;
using Sistema_de_Eventos;
using Sistema_de_Eventos.Modelo.Notificacoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Eventos.Map.Notificao {
    public class NotificavelMap : ClassMap<Notificavel> {
        public NotificavelMap() {
            Id(x => x.Id);
            DiscriminateSubClassesOnColumn("type");
        }
    }
}
