using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeEventos.Dominio.Exceptions {
    public class AtividadeNaoEncontradaException : Exception {
        public AtividadeNaoEncontradaException(string message) : base(message) {
        }
    }
}
