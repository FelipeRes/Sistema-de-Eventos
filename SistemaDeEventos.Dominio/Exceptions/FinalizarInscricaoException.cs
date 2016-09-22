using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeEventos.Dominio.Exceptions {
    public class FinalizarInscricaoException : Exception {
        public FinalizarInscricaoException(string message): base(message) {
        }
    }
}
