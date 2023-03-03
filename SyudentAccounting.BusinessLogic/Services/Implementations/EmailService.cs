using MimeKit;
using StudentAccounting.BusinessLogic.Services.Contracts;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;

namespace StudentAccounting.BusinessLogic.Services.Implementations
{
    public class EmailService : IEmailService
    {
        private const string Name = "PolessUp";
        private const string Host = "smtp.gmail.com";
        private const int Port = 465;
        private readonly string _emailAddress;
        private readonly string _emailPassword;

        public EmailService(IConfiguration configuration)
        {
            _emailAddress = configuration["Email:Address"];
            _emailPassword = configuration["Email:Password"];
        }
        
        public void SendEmailMessage(string email, string subject, string message)
        {
            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress(Name, _emailAddress));

            emailMessage.To.Add(new MailboxAddress("", email));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = message
            };
                    
            using (SmtpClient client = new SmtpClient())
            {
                client.Connect(Host, Port, true);

                client.Authenticate(_emailAddress, _emailPassword);

                client.Send(emailMessage);
                
                client.Disconnect(true);
            }
        }
    }
}
