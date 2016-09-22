using Sistema_de_Eventos.NHibernateHelp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Eventos.Modelo.Cupons {
    public class FabricarCupom {
        public static Cupom DescontoPorcentagem(double valor) {
            DescontoPorcentagem desconto = new DescontoPorcentagem();
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
