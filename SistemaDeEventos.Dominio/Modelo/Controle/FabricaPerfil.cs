using Sistema_de_Eventos.Modelo.Controle;
using Sistema_de_Eventos.NHibernateHelp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeEventos.Dominio.Modelo.Controle {
    public class FabricaPerfil {
        static public PerfilParticipante Participante(Usuario user) {
            PerfilParticipante participante = new PerfilParticipante();
            participante.User = user;
            NHibernateHelper.SaveOrUpdate(ref user);
            return participante;
        }
    }
}
