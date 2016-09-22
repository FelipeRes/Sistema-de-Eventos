using Sistema_de_Eventos.Modelo.Controle;
using Sistema_de_Eventos.Modelo.Notificacoes;
using Sistema_de_Eventos.NHibernateHelp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeEventos.Modelo.Controle {
    public class FabricaUsuario {
        static public CriaUsuario NovoUsuario(string email, string senha) {
            return new CriaUsuario(email,senha);
        }
    }
    public class CriaUsuario {
        private Usuario user;
        public CriaUsuario(string email, string senha) {
            user = new Usuario();
            user.Email = email;
            user.Senha = senha;
        }
        public virtual CriaUsuario AdicionaPessoa(Pessoa pessoa) {
            user.Pessoa = pessoa;
            return this;
        }
        public virtual Usuario build() {
            Notificador notificacao = FabricaNotificacao.CriarNotificador();
            NHibernateHelper.SaveOrUpdate(ref notificacao);
            user.Notificacao = notificacao;
            NHibernateHelper.SaveOrUpdate(ref user);
            return user;
        }
    }
}
