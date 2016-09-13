using Sistema_de_Eventos.AtividadePack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Eventos.Modelo {
    public class Organizacao {

        private Atividade atividade;
        public Atividade AtividadeOrganizacao { get { return atividade; } }
        private Pessoa organizador;
        public Pessoa Organizador { get { return organizador; } }
        private List<Pessoa> colaboradores = new List<Pessoa>();
        public List<Pessoa> Colaboradores { get { return colaboradores; } }
        public String ResponsavelNome {
            get { return organizador.Nome; }
        }
        public String ResponsavelDescricao {
            get { return organizador.Descricao; }
        }
        public String NomeColaboradores {
            get {
                string colaboradores = organizador.Nome + "\n";
                for (int i = 0; i < Colaboradores.Count; i++){
                    colaboradores += Colaboradores[i].Nome + "\n";
                }
                return colaboradores;
            }
        }

        public Organizacao (Atividade atividade, Pessoa organizador) {
            this.atividade = atividade;
            this.organizador = organizador;
        }
        public void AdicionarColaborador(Pessoa pessoa) {
            if (pessoa != null && !colaboradores.Contains(pessoa)) {
                colaboradores.Add(pessoa);
            }else {
                throw new Exception("Colaborador ja existe");
            }
        }
        public void RemoverColaborador(Pessoa pessoa) {
            if (pessoa != null && colaboradores.Contains(pessoa)) {
                colaboradores.Remove(pessoa);
            } else {
                throw new Exception("Colaborador nao Existe");
            }
        }
        public bool ChecarUsuario(Pessoa pessoa) {
            if ((pessoa != null && colaboradores.Contains(pessoa)) || pessoa == organizador) {
                return true;
            }else {
                return false;
            }
        }
        void PermissaoDeUsuario(Pessoa pessoa) {
            if ((pessoa != null && colaboradores.Contains(pessoa)) || pessoa == organizador) {
                return;
            } else {
                throw new Exception("Usuario Sem Permissao");
            }
        }

    }
}
