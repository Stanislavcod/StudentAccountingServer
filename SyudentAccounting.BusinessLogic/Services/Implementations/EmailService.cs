using MimeKit;
using StudentAccounting.BusinessLogic.Services.Contracts;
using MailKit.Net.Smtp;

namespace StudentAccounting.BusinessLogic.Services.Implementations
{
    public class EmailService : IEmailService
    {
        public void SendEmailMessage(string email, string subject, string message)
        {
            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress("PolessUp", "polessup@gmail.com"));

            emailMessage.To.Add(new MailboxAddress("", email));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = message
            };
                    
            using (SmtpClient client = new SmtpClient())
            {
                client.Connect("smtp.gmail.com", 465, true);

                client.Authenticate("polessup@gmail.com", "xdskhxhcbwycmaut");

                client.Send(emailMessage);
                client.Disconnect(true);
            }
        }
    }
}
