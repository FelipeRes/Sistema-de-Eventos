using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;

namespace Sistema_de_Eventos {
    public class NotificacaoEmail : Notificavel {
        private MailMessage Email;
        public void Atualizar(string message) {
            Console.WriteLine(message);
            /*/cria uma mensagem
            MailMessage mail = new MailMessage();
            //Cria o Remetente (administrador do sistema)
            string remetente = "feliperesendehq@outlook.com";
            string destinatario = "feliperesendehq@outlook.com";
            //define os endereços
            mail.From = new MailAddress(destinatario);
            mail.To.Add(destinatario);
            //define o conteúdo
            mail.Subject = "Atenção! Erros com o Sistema da Ferragem!";
            mail.SubjectEncoding = System.Text.Encoding.UTF8;//colocando msg no padrao utf8
            mail.IsBodyHtml = true;
            mail.Body = "Foi reportado o erro a seguir com o aplicativo: ";
            //Credenciais para acesso ao E-mail
            //smtp para hotmail, pois utilizei o hotmail para enviar a mensagem
            SmtpClient smtp = new SmtpClient("smtp.live.com");
            //Recursos adicionais para o envio da mensagem
            smtp.EnableSsl = true;
            smtp.Port = 465;//aqui foi onde resolvi a questão
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.UseDefaultCredentials = false;

            //Autenticação
            smtp.Credentials = new NetworkCredential(remetente, "MasterGig26.psy");

            //envia a mensagem
            smtp.Send(mail);*/
        }
    }
}
