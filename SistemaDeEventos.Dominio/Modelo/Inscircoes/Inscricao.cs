﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using Sistema_de_Eventos.Modelo.Eventos;
using Sistema_de_Eventos.Modelo.Cupons;
using Sistema_de_Eventos.Modelo.Controle;
using SistemaDeEventos.Dominio.Modelo.Inscircoes;
using SistemaDeEventos.Dominio.Exceptions;

namespace Sistema_de_Eventos.Modelo {
    public class Inscricao {

        //Funcoes que são delegadas a atividade para garantir integridade de dados
        //e repetição de codigo
        public delegate void AddAtividade(Atividade atividade);
        public delegate void RemoveAtividade(Atividade atividade);

        //Tipo de participacao é pra aluno, professor, ou convidado
        private TipoInscricao participacao;
        public virtual TipoInscricao Participacao { get { return participacao; } set { participacao = value; } } 

        public virtual int Id { get; set; }

        public virtual IList<Cupom> listaDeCupons { get; set; }

        private Usuario usuario;
        public virtual Usuario User { get { return usuario; } set { usuario = value; } }

        //checa se foi pago ou nao
        private bool pagamento;
        public virtual bool Pagamento { get { return pagamento; } }

        private bool checkIn;
        public virtual bool CheckIn { get { return checkIn; } }

        public virtual ListaAtividade Atividades { get; set; }

        //O valor total da inscricao é o valor de todas as atividades
        public virtual double ValorTotal {
            get {
                double PrecoFinal = 0;
                for (int i = 0; i < Atividades.Quantidade; i++) {
                    PrecoFinal += Atividades.lista[i].Preco;
                }
                return PrecoFinal;
            }
        }
        //Esse é o valor com desconto em cima do valor total
        public virtual double ValorComDesconto {
            get {
                double valorComDesconto = ValorTotal;
                for (int i = 0; i < listaDeCupons.Count; i++) {
                    valorComDesconto -= listaDeCupons[i].GetDesconto(ValorTotal, this);
                }
                return valorComDesconto;
            }
        }
        internal Inscricao() {
        }
        //AddAtividade é um delegate que guarda a função de adicionar inscrito
        // essa funçao delega essa responsabilidade a propria atividade que irá checar
        // a integridade de dados
        public virtual void AdicionarAtividade(Atividade atividade) {
            if (!pagamento && atividade.Estado == EstadoDaAtividade.Aberto) {
                AddAtividade a = new AddAtividade(Atividades.Adicionar);
                atividade.AdicionarInscritos(this, a);
            } else {
                throw new AtividadeRepetidaException("Inscricao ja contém essa atividade");
            }
        }
        public virtual void RemoverAtividade(Atividade atividade) {
            if (!pagamento) {
                RemoveAtividade a = new RemoveAtividade(Atividades.Adicionar);
                atividade.RemoverInscritos(this, a);
            } else {
                throw new AtividadeNaoEncontradaException("Atividade nao encontrada");
            }
        }
        //não é possivel adicionar um cupom de desconto que foi invalidado
        public virtual void AdicionarCuponDeDesconto(Cupom cupom) {
            if (!pagamento) {
                if (!cupom.IsUsado) {
                    listaDeCupons.Add(cupom);
                }else {
                    throw new CupomInvalidoException("Cupom Invalido");
                }
            } else {
                throw new PagamentoJaRealizadoExcpetion("Inscricao Ja finalizada ou cupom ja utilizado");
            }
        }
        //A finalização da inscrição invalida os cupons
        //só pode ser feita se tiver mais de uma atividade inscrita
        public virtual void FinalizarInscricao() {
            if (Atividades.Quantidade > 0) {
                pagamento = true;
                foreach(var cupom in listaDeCupons) {
                    if (!cupom.IsUsado) {
                        cupom.Invalidar();
                    }
                }
                //Notificacao de inscricao
                usuario.Notificacao.AtualizarNotificaveis("Inscição finalizada com sucesso!");
            } else {
                throw new FinalizarInscricaoException("Voce deve se inscrever em ao menos uma atividade");
            }
        }
        //A geração de uma nota com todas as informações do inscrito 
        public virtual string nota {
            get {
                string nota = "\n";
                for (int i = 0; i < Atividades.lista.Count; i++) {
                    nota += Atividades.lista[i].Nome + " - Preco: " + Atividades.lista[i].Preco + "\n";
                }
                nota += "Valor Total: " + ValorTotal + "\n";
                nota += "Valor Com Desconto: " + ValorComDesconto;
                return nota;
            }
        }
        public virtual void ConfirmarCheckIn() {
            checkIn = true;
        }
    }
}
