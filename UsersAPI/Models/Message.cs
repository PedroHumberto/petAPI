using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UsersAPI.Models
{
    public class Message
    {
        public List<MailboxAddress> MailBox { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }

        public Message(IEnumerable<string> mailBox, string subject, int userId, string code ){


            MailBox = new List<MailboxAddress>();
            MailBox.AddRange(mailBox.Select(mb => new MailboxAddress(subject, mb)));
            Subject = subject;
            Content = $"http://localhost:6000/active?UserId={userId}&ActivationCode={code}";

        }
       
    }
}