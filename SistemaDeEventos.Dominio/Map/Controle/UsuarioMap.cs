using FluentNHibernate.Mapping;
using Sistema_de_Eventos;
using Sistema_de_Eventos.Modelo.Controle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Eventos.Map.Controle {
    public class UsuarioMap : ClassMap<Usuario> {
        public UsuarioMap() {
            Id(x => x.Id);
            References(x => x.Pessoa);
            Map(x => x.Email);
            Map(x => x.Senha);
            References(x => x.Notificacao);

        }
    }
}
