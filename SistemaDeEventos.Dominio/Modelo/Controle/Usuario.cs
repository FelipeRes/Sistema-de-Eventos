using NHibernate;
using Sistema_de_Eventos.Modelo;
using Sistema_de_Eventos.Modelo.Controle;
using Sistema_de_Eventos.Modelo.Cupons;
using Sistema_de_Eventos.Modelo.Eventos;
using Sistema_de_Eventos.Modelo.Notificacoes;
using Sistema_de_Eventos.NHibernateHelp;
using SistemaDeEventos.Dominio.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Sistema_de_Eventos.Modelo.Controle {
    public class Usuario : Notificavel {

        public virtual int Id { get; set; }

        private Pessoa pessoa;
        public virtual Pessoa Pessoa { get { return pessoa; } set { pessoa = value; } }

        //O set de email e senha passa por um filtro de regex
        //Não era para ser possivel fazer o get da senha
        //mas o ORM me obrigou, tendo a necessidade de se buscar outra estratégia

        private string email;
        public virtual string Email {
            get {
                return email;
            } set {
                Match match = RegexStrings.regMail.Match(value);
                if (match.Success) {
                    email = value;
                }else {
                    throw new Exception("Formato de e-mail errado");
                }
                
            }
        }       

        private string senha;
        public virtual string Senha {
            get {
                return senha;
            }
            set {
                Match match = RegexStrings.regSenha.Match(value);
                if (match.Success) {
                    senha = value;
                } else {
                    throw new Exception("Apenas letras e numeros, minimo 6 letras");
                }
            }
        }

        private Notificador notificacao;
        public virtual Notificador Notificacao {get{return notificacao;}set { notificacao = value; }}

        internal Usuario() {;
        }

        //checa se a senha está correta
        public virtual bool Check(string senha) {
            if(this.senha == senha) {
                return true;
            }else {
                throw new ArgumentException("Senha Invalida");
            }
                
        }
        //Notificacao de usuario, só irá funcionar se o usuario adicionar um notificador
        //isso pode ser uma opção na interface grafica 
        public virtual void Atualizar(string message) {
            if (notificacao != null) {
                Notificacao.AtualizarNotificaveis(message);
            }
        }
    }
}
