using Sistema_de_Eventos.Modelo;
using Sistema_de_Eventos.Modelo.Eventos;
using Sistema_de_Eventos.NHibernateHelp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeEventos.Dominio.Modelo.Controle {
    public class PerfilParticipante : Perfil {
        internal PerfilParticipante() {
        }
        public virtual IList<Atividade> AtividadesQueParticipei() {
            List<Atividade> lista = new List<Atividade>();
            var sessionFactory = NHibernateHelper.sessionFactory;
            using (var session = sessionFactory.OpenSession()) {
                using (session.BeginTransaction()) {
                    var inscricoes = session.CreateCriteria(typeof(Inscricao)).List<Inscricao>();
                    foreach (var i in inscricoes) {
                        if (i.User.Id == this.User.Id) {
                            Console.WriteLine(i.User.Pessoa.Nome);
                            foreach (var a in i.Atividades.lista) {
                                if (a.Estado == EstadoDaAtividade.Encerrado) {
                                    lista.Add(a);
                                }
                            }
                        }
                    }
                }
            }
            return lista;
        }
    }
}
