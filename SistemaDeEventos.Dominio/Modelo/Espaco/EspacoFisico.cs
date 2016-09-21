using Sistema_de_Eventos.Modelo;
using Sistema_de_Eventos.Modelo.Controle;
using Sistema_de_Eventos.Modelo.Cupons;
using Sistema_de_Eventos.Modelo.Eventos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Eventos.Modelo.Espaco {
    public abstract class EspacoFisico {

        public virtual int Id { get; set; }

        public virtual int capacidade { get; set; }
        public virtual string nome { get; set; }

        abstract public string Nome { get; set; }
        abstract public int Capacidade { get; set; }

        public virtual ListaAtividade Atividades { get; set; }
    }
}
