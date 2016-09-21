using FluentNHibernate.Mapping;
using Sistema_de_Eventos;
using Sistema_de_Eventos.Modelo.Controle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Eventos.Map.Controle {
    public class PessoaMap : ClassMap<Pessoa>{
        public PessoaMap() {
            Id(x => x.Id);
            Map(x => x.CPF);
            Map(x => x.DataDeNascimento).CustomSqlType("datetime2").Not.Nullable();
            Map(x => x.Descricao);
            Map(x => x.Endereco);
            Map(x => x.Idade);
            Map(x => x.Nome);
        }
    }
}
