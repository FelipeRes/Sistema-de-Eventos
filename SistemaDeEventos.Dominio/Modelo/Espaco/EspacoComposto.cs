using Sistema_de_Eventos.Modelo.Eventos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Eventos.Modelo.Espaco {
    public class EspacoComposto : EspacoFisico {

        public virtual IList<EspacoFisico> espacoInterior { get; set; }

        public override int Capacidade {
            get {
                int capacidade = 0;
                for (int i = 0; i < espacoInterior.Count; i++) {
                    capacidade += espacoInterior[i].Capacidade;
                }
                return capacidade;
            }set {
                capacidade = value;
            }
        }
        public override string Nome {
            get {
                string nomeLocalCompleto = "";
                for (int i = 0; i < espacoInterior.Count; i++) {
                    nome += " - " + espacoInterior[i].Nome;
                }
                return nome + nomeLocalCompleto;
            }
            set {
                nome = value;
            }
        }

        internal EspacoComposto() {
            espacoInterior = new List<EspacoFisico>();
        }

        public virtual void AdicionarInterior(EspacoFisico interior) {
            if (!espacoInterior.Contains(interior) && interior != null) {
                espacoInterior.Add(interior);
            } else {
                throw new Exception("Ja contem esse elemento ou elemento nulo");
            }
        }

        public virtual void RemoverInterior(EspacoFisico interior) {
            if (espacoInterior.Contains(interior)) {
                espacoInterior.Remove(interior);
            } else {
                throw new Exception("Interior nao encontrado");
            }
        }
    }
}
