using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Eventos.Exceptions {
    public class NumeroMaximoDeInscritosException : Exception {
        public NumeroMaximoDeInscritosException() {
        }
        public NumeroMaximoDeInscritosException(string message):base(message){
        }
        public NumeroMaximoDeInscritosException(string message, Exception inner) : base(message, inner) {
        }
    }
    public class AtividadeRepetida : Exception {
        public AtividadeRepetida() {
        }
        public AtividadeRepetida(string message) : base(message) {
        }
        public AtividadeRepetida(string message, Exception inner) : base(message, inner) {
        }
    }
    public class CuponRepetido : Exception {
        public CuponRepetido() {
        }
        public CuponRepetido(string message) : base(message) {
        }
        public CuponRepetido(string message, Exception inner) : base(message, inner) {
        }
    }
}
