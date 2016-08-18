using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Eventos.Modelo {
    public class Organizacao {

        private Evento evento;
        public Evento EventoOrganizado { get { return evento; } }
        private Usuario organizador;
        public Usuario Organizador { get { return organizador; } }
        private List<Usuario> colaboradores = new List<Usuario>();
        public List<Usuario> Colaboradores { get { return colaboradores; } }

        public Organizacao (Evento evento, Usuario organizador) {
            this.evento = evento;
            this.organizador = organizador;
        }
        public void AdicionarColaborador(Usuario usuario) {
            if (usuario != null && !colaboradores.Contains(usuario)) {
                colaboradores.Add(usuario);
            }
        }
        public void RemoverColaborador(Usuario usuario) {
            if (usuario != null && colaboradores.Contains(usuario)) {
                colaboradores.Remove(usuario);
            }
        }
        public bool ChecarUsuario(Usuario usuario) {
            if ((usuario != null && colaboradores.Contains(usuario)) || usuario == organizador) {
                return true;
            }else {
                return false;
            }
        }
        void PermissaoDeUsuario(Usuario usuario) {
            if ((usuario != null && colaboradores.Contains(usuario)) || usuario == organizador) {
                return;
            } else {
                throw new Exception("Usuario Sem Permissao");
            }
        }
    }
}
