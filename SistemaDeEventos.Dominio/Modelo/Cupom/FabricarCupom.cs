using Sistema_de_Eventos.Modelo.Eventos;
using Sistema_de_Eventos.NHibernateHelp;
using SistemaDeEventos.Dominio.Modelo.Cupons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Eventos.Modelo.Cupons {
    public class FabricarCupom {
        //A fabrica cria um desconto, um descontavel e adiciona os dois ao banco
        public static Cupom DescontoPorcentagem(double valor) {
            DescontoPorcentagem desconto = new DescontoPorcentagem();
            desconto.porcentagem = valor;
            NHibernateHelper.SaveOrUpdate(ref desconto);
            Cupom cupom = new Cupom();
            cupom.Desconto = desconto;
            NHibernateHelper.SaveOrUpdate(ref cupom);
            return cupom;
        }
        public static Cupom DescontoAluno(double valor) {
            DescontoAluno desconto = new DescontoAluno();
            desconto.porcentagem = valor;
            NHibernateHelper.SaveOrUpdate(ref desconto);
            Cupom cupom = new Cupom();
            cupom.Desconto = desconto;
            NHibernateHelper.SaveOrUpdate(ref cupom);
            return cupom;
        }
        public static Cupom DescontoPorValor(double valor) {
            DescontoValor desconto = new DescontoValor();
            desconto.valor = valor;
            NHibernateHelper.SaveOrUpdate(ref desconto);
            Cupom cupom = new Cupom();
            cupom.Desconto = desconto;
            NHibernateHelper.SaveOrUpdate(ref cupom);
            return cupom;
        }
    }
}
