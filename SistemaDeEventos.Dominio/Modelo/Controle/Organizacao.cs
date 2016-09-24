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

        //Classe que assossia atividade a uma equipe organizadora
        //Ela tem um usuario principal que é um organizadoe e uma lista de colaboradores

        public virtual int Id { get; set; }

        private Atividade atividade;
        public virtual Atividade AtividadeOrganizacao { get { return atividade; } set { atividade = value; } }

        private Usuario organizador;
        public virtual Usuario Organizador { get { return organizador; } set { organizador = value; } }

        private IList<Usuario> colaboradores;
        public virtual IList<Usuario> Colaboradores { get { return colaboradores; } set { colaboradores = value; } }

        public virtual string ResponsavelNome {
            get { return organizador.Pessoa.Nome; }
        }
        public virtual string ResponsavelDescricao {
            get { return organizador.Pessoa.Descricao; }
        }
        public virtual string NomeColaboradores {
            get {
                string colaboradores = organizador.Pessoa.Nome + "\n";
                for (int i = 0; i < Colaboradores.Count; i++){
                    colaboradores += Colaboradores[i].Pessoa.Nome + "\n";
                }
                return colaboradores;
            }
        }

        public Organizacao () {
            colaboradores = new List<Usuario>();
        }
        public virtual void AdicionarColaborador(Usuario pessoa) {
            if (pessoa != null && !colaboradores.Contains(pessoa)) {
                colaboradores.Add(pessoa);
            }else {
                throw new Exception("Colaborador ja existe");
            }
        }
        public virtual void RemoverColaborador(Usuario pessoa) {
            if (pessoa != null && colaboradores.Contains(pessoa)) {
                colaboradores.Remove(pessoa);
            } else {
                throw new Exception("Colaborador nao Existe");
            }
        }
        public virtual bool ChecarUsuario(Usuario pessoa) {
            if ((pessoa != null && colaboradores.Contains(pessoa)) || pessoa == organizador) {
                return true;
            }else {
                return false;
            }
        }
        //verifica se o usuario faz parte da equipe, será utilizada 
        //pelo perfil para saber se o usuario pode ou não fazer alguma ação
        public virtual void PermissaoDeUsuario(Usuario pessoa) {
            if ((pessoa != null && colaboradores.Contains(pessoa)) || pessoa == organizador) {
                return;
            } else {
                throw new Exception("Usuario Sem Permissao");
            }
        }

    }
}
