using Sistema_de_Eventos.Modelo;
using Sistema_de_Eventos.Modelo.Cupons;
using SistemaDeEventos.Dominio.Modelo.Inscircoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeEventos.Dominio.Modelo.Cupons {
    public class DescontoAluno : Descontavel {

        public virtual int Id { get; set; }

        public virtual double porcentagem { get; set; }

        public virtual double GetDesconto(double valorRecebido, Inscricao inscricao) {
            if (inscricao.Participacao == TipoInscricao.ESTUDADNTE) {
                return valorRecebido / 100 * porcentagem;
            } else {
                return valorRecebido;
            }
        }
        internal DescontoAluno() {
        }
    }
}
