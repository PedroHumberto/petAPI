using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsersAPI.Models;

namespace UsersAPI.Services
{
    public class EmailService
    {
        private IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        internal void SendEmail(string?[] userEmail, string subject, int userId, string code)
        {
            Message message = new Message(userEmail, subject, userId, code);

            var emailMessage = CreateEmailBody(message);

            SendEmailMessage(emailMessage);

        }

        private void SendEmailMessage(MimeMessage emailMessage)
        {
            using (var client = new SmtpClient())
            {
                try
                {
                    client.ServerCertificateValidationCallback = (s, c, h, e) => true;
                    client.Connect(
                        _configuration.GetValue<string>("EmailSettings:SmtpServer"),
                        _configuration.GetValue<int>("EmailSettings:Port"), 
                        MailKit.Security.SecureSocketOptions.StartTls
                    );
    
                    client.Authenticate(_configuration.GetValue<string>("EmailSettings:From"),
                        _configuration.GetValue<string>("EmailSettings:Password"));
                    //TODO Auth mail
                    client.Send(emailMessage);
                }catch
                {
                    throw; 
                }
                finally
                {
                    client.Disconnect(true);
                    client.Dispose();
                }
            }
        }

        private MimeMessage CreateEmailBody(Message message)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress(message.Subject,
                _configuration.GetValue<string>("EmailSettings:From")));

            emailMessage.To.AddRange(message.MailBox);
            emailMessage.Subject = message.Subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Text)
            {
                Text = message.Content
            };

            return emailMessage;

        }
    }
}