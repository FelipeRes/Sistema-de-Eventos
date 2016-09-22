using Sistema_de_Eventos.Modelo;
using Sistema_de_Eventos.Modelo.Cupons;
using Sistema_de_Eventos.Modelo.Eventos;
using Sistema_de_Eventos.NHibernateHelp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeEventos.Dominio.Modelo.Inscircoes {
    public class FabricaInscricao {
        public static Inscricao NovaInscricao() {
            Inscricao inscricao = new Inscricao();
            ListaAtividade listaAtividade = new ListaAtividade();
            inscricao.Atividades = listaAtividade;
            NHibernateHelper.SaveOrUpdate(ref listaAtividade);
            inscricao.listaDeCupons = new List<Cupom>();
            inscricao.Participacao = TipoInscricao.VISITANTE;
            NHibernateHelper.SaveOrUpdate(ref inscricao);
            return inscricao;
        }
    }
}
