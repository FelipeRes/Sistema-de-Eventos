using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sistema_de_Eventos.AtividadePack;

namespace Sistema_de_Eventos {
    public class Aplicacao {
        public static void Main() {
            Evento meuEvento = new Evento();
            meuEvento.Nome = "Arduino Day";
            Atividade atividade = new AtividadeDefault("Credenciamento");
            Atividade atividade2 = new AtividadeDefault("Sorteio");
            Atividade atividade3 = new AtividadeSimples("Minicurso");
            atividade3.Preco = 15;
            Atividade atividade4 = new AtividadeSimples("Palestra");
            atividade4.Preco = 50;
            meuEvento.Atividades.Adicionar(atividade);
            meuEvento.Atividades.Adicionar(atividade2);
            meuEvento.Atividades.Adicionar(atividade3);
            meuEvento.Atividades.Adicionar(atividade4);
            Console.WriteLine(meuEvento.Agenda);

            Evento evento2 = new Evento();
            evento2.Nome = "SBGames";
            Atividade atividadeA = new AtividadeDefault("Credenciamento");
            Atividade atividadeB = new AtividadeSimples("Stand");
            atividadeB.Preco = 1000;
            evento2.Atividades.Adicionar(atividadeA);
            evento2.Atividades.Adicionar(atividadeB);

            meuEvento.Atividades.Adicionar(evento2);

            //Console.WriteLine(evento2.Agenda);
            //Console.WriteLine(meuEvento.Agenda);

            Pessoa pessoa = new Pessoa();
            pessoa.Nome = "José";
            Usuario user = new Usuario(pessoa);
            Inscricao inscricao = new Inscricao(user);
            inscricao.AdicionarAtividade(meuEvento);
            inscricao.FinalizarInscricao();
            Console.WriteLine(inscricao.nota);

            for (int i = 0; i < meuEvento.ListaDeInscritos.Count; i++) {
                Console.WriteLine(meuEvento.ListaDeInscritos[i].User.Pessoa.Nome);
            }
            Console.WriteLine(user.MinhasInscricoes[0].Pagamento);

            atividade3.DataInicio = new DateTime(2016, 9, 13, 20, 30, 0);
           evento2.DataFim = new DateTime(2016, 9, 13, 20, 30, 0);

            Console.ReadKey();
        }
    }
}
