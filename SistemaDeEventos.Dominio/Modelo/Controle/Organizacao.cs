using Sistema_de_Eventos.Modelo;
using Sistema_de_Eventos.Modelo.Controle;
using Sistema_de_Eventos.Modelo.Cupons;
using Sistema_de_Eventos.Modelo.Eventos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Eventos.Modelo.Controle {
    public class Organizacao {

        private Atividade atividade;
        public Atividade AtividadeOrganizacao { get { return atividade; } }
        private Usuario organizador;
        public Usuario Organizador { get { return organizador; } }
        private List<Usuario> colaboradores = new List<Usuario>();
        public List<Usuario> Colaboradores { get { return colaboradores; } }
        public string ResponsavelNome {
            get { return organizador.Pessoa.Nome; }
        }
        public string ResponsavelDescricao {
            get { return organizador.Pessoa.Descricao; }
        }
        public string NomeColaboradores {
            get {
                string colaboradores = organizador.Pessoa.Nome + "\n";
                for (int i = 0; i < Colaboradores.Count; i++){
                    colaboradores += Colaboradores[i].Pessoa.Nome + "\n";
                }
                return colaboradores;
            }
        }

        public Organizacao (Atividade atividade, Usuario organizador) {
            this.atividade = atividade;
            this.organizador = organizador;
        }
        public void AdicionarColaborador(Usuario pessoa) {
            if (pessoa != null && !colaboradores.Contains(pessoa)) {
                colaboradores.Add(pessoa);
            }else {
                throw new Exception("Colaborador ja existe");
            }
        }
        public void RemoverColaborador(Usuario pessoa) {
            if (pessoa != null && colaboradores.Contains(pessoa)) {
                colaboradores.Remove(pessoa);
            } else {
                throw new Exception("Colaborador nao Existe");
            }
        }
        public bool ChecarUsuario(Usuario pessoa) {
            if ((pessoa != null && colaboradores.Contains(pessoa)) || pessoa == organizador) {
                return true;
            }else {
                return false;
            }
        }
        void PermissaoDeUsuario(Usuario pessoa) {
            if ((pessoa != null && colaboradores.Contains(pessoa)) || pessoa == organizador) {
                return;
            } else {
                throw new Exception("Usuario Sem Permissao");
            }
        }

    }
}
