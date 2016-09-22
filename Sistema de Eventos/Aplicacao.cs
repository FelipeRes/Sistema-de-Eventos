using Sistema_de_Eventos.Modelo;
using Sistema_de_Eventos.Modelo.Controle;
using Sistema_de_Eventos.Modelo.Cupons;
using Sistema_de_Eventos.Modelo.Espaco;
using Sistema_de_Eventos.Modelo.Eventos;
using Sistema_de_Eventos.NHibernateHelp;
using SistemaDeEventos.Dominio.Modelo.Controle;
using SistemaDeEventos.Dominio.Modelo.Inscircoes;
using SistemaDeEventos.Modelo.Controle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Eventos {
    public class Aplicacao {
        public static void Main() {
            

            EspacoFisico espaco = FabricarEspaco.Composto("IFPI").CriarEspaco("B1", 10).CriarEspaco("B2",20).build();
            Console.WriteLine(espaco.Nome);

            Pessoa pessoa = Pessoa.BuildNome("Maria").CPF(1234123).DataNascimento(DateTime.Now).build();
            Usuario user = FabricaUsuario.NovoUsuario("blblbl@algo.com", "123456").AdicionaPessoa(pessoa).build();
            user.Notificacao.AtualizarNotificaveis("Hello");
            Console.WriteLine(user.Pessoa.Nome);

            Evento evento = FabricarAtividade.Evento();
            evento.Nome = "BGS";
            evento.Preco = 100;
            evento.Lugar = espaco;
            evento.DataInicio = DateTime.Now;

            Atividade atividade = FabricarAtividade.Simples("Zawarudo");
            atividade.Preco = 100;
            evento.Atividades.Adicionar(atividade);
            NHibernateHelper.SaveOrUpdate(ref atividade);
            NHibernateHelper.SaveOrUpdate(ref evento);
            Console.WriteLine(evento.Agenda);

            Inscricao inscricao = FabricaInscricao.NovaInscricao();
            inscricao.User = user;

            Cupom cupom = FabricarCupom.DescontoPorcentagem(50);
            cupom.comboCupom.Add(FabricarCupom.DescontoPorValor(1));
            Console.WriteLine(cupom.GetDesconto(100, inscricao));

            inscricao.AdicionarCuponDeDesconto(cupom);
            ListaAtividade listaAtividade = new ListaAtividade();
            inscricao.Atividades = listaAtividade;
            inscricao.Atividades.Adicionar(evento);
            inscricao.FinalizarInscricao();
            atividade.Estado = EstadoDaAtividade.Encerrado;
            Console.WriteLine(inscricao.nota);

            NHibernateHelper.SaveOrUpdate(ref listaAtividade);
            NHibernateHelper.SaveOrUpdate(ref inscricao);
            atividade.Estado = EstadoDaAtividade.Encerrado;
            NHibernateHelper.SaveOrUpdate(ref atividade);
            

            Console.ReadKey();
        }
    }
}
