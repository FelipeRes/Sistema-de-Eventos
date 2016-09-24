using Sistema_de_Eventos.Modelo.Controle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeEventos.Dominio.Modelo.Controle {
    public abstract class Perfil {
        //Isso não está totamente implementado
        //mas seria as funções que o usario tanto como administrador
        // ou como apenas usuario
        public virtual int Id { get; set; }
        protected Usuario user;
        public virtual Usuario User { get { return user; } set { user = value; } }
    }
}
