using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sistema_de_Eventos.AtividadePack;

namespace Sistema_de_Eventos {
    public class Aplicacao {
        public static void Main() {
            Evento meuEvento = FabricarAtividade.Evento();
            meuEvento.Nome = "Arduino Day";
            Atividade atividade = FabricarAtividade.Complementar ("Credenciamento");
            Atividade atividade2 = FabricarAtividade.Complementar("Sorteio");
            Atividade atividade3 = FabricarAtividade.Simples("Minicurso");
            atividade3.Preco = 15;
            Atividade atividade4 = FabricarAtividade.Simples("Palestra");
            atividade4.Preco = 50;
            meuEvento.Atividades.Adicionar(atividade);
            meuEvento.Atividades.Adicionar(atividade2);
            meuEvento.Atividades.Adicionar(atividade3);
            meuEvento.Atividades.Adicionar(atividade4);
            Console.WriteLine(meuEvento.Agenda);

            Evento evento2 = new Evento();
            evento2.Nome = "SBGames";
            Atividade atividadeA = FabricarAtividade.Complementar("Credenciamento");
            Atividade atividadeB = FabricarAtividade.Simples("Stand");
            atividadeB.Preco = 1000;
            evento2.Atividades.Adicionar(atividadeA);
            evento2.Atividades.Adicionar(atividadeB);

            meuEvento.Atividades.Adicionar(evento2);

            Pessoa pessoa = Pessoa.BuildNome("Felipe").CPF(000100101).build();
            Usuario user = new Usuario("bla@gats", "sou");
            user.Pessoa = pessoa;
            Inscricao inscricao = new Inscricao(user);
            inscricao.AdicionarAtividade(meuEvento);
            Console.WriteLine(inscricao.nota);

            Cupom cupom = FabricarCupom.DescontoPorcentagem(50);
            inscricao.AdicionarCuponDeDesconto(cupom);
            Console.WriteLine(inscricao.nota);
            inscricao.FinalizarInscricao();

            for (int i = 0; i < meuEvento.ListaDeInscritos.Count; i++) {
                Console.WriteLine(meuEvento.ListaDeInscritos[i].User.Pessoa.Nome);
            }
            Console.WriteLine(user.MinhasInscricoes[0].listaDeAtividades[0].Nome);

            atividade3.DataInicio = new DateTime(2016, 9, 13, 20, 30, 0);
            evento2.DataFim = new DateTime(2016, 9, 13, 20, 30, 0);

            Console.ReadKey();
        }
    }
}
