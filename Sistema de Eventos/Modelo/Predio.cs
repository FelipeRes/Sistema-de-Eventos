using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Eventos.Modelo {
    public class Predio : EspacoFisico {

        private List<EspacoFisico> espacoInterior = new List<EspacoFisico>();
        private string nome;

        public int Capacidade {
            get {
                int capacidade = 0;
                for (int i = 0; i < espacoInterior.Count; i++) {
                    capacidade += espacoInterior[i].Capacidade;
                }
                return capacidade;
            }
        }
        public string Nome { get { return nome; } }

        public Predio(string Titulo, EspacoFisico interior) {
            nome = Titulo;
            AdicionarInterior(interior);
        }
        public void AdicionarInterior(EspacoFisico interior) {
            if (!espacoInterior.Contains(interior) && interior != null) {
                espacoInterior.Add(interior);
            } else {
                throw new Exception("Ja contem esse elemento ou elemento nulo");
            }
        }

        public void RemoverInterior(EspacoFisico interior) {
            if (espacoInterior.Contains(interior)) {
                espacoInterior.Remove(interior);
            } else {
                throw new Exception("Interior nao encontrado");
            }
        }
    }
}
