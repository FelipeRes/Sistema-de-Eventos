using Sistema_de_Eventos.Modelo;
using Sistema_de_Eventos.Modelo.Controle;
using Sistema_de_Eventos.Modelo.Cupons;
using Sistema_de_Eventos.Modelo.Espaco;
using Sistema_de_Eventos.Modelo.Eventos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Eventos {
    public class Aplicacao {
        public static void Main() {

            Cupom cupom = FabricarCupom.DescontoPorcentagem(50);
            cupom.comboCupom.Add(FabricarCupom.DescontoPorValor(5));
            Console.WriteLine(cupom.GetDesconto(100));

            EspacoFisico espaco = FabricarEspaco.Composto("IFPI").CriarEspaco("B1", 10).CriarEspaco("B2",20).build();
            Console.WriteLine(espaco.Nome);

            Console.ReadKey();
        }
    }
}
