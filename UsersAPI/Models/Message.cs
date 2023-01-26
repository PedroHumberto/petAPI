using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UsersAPI.Models
{
    public class Message
    {
        public List<?> UserEmail { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }

        public Message(IEnumerable<string> userEmail, string subject, int userId, string code ){

            userEmail = userEmail;
            Subject = subject;
            Content = $"http://localhost:6000/active?UserId={userId}&CodeActivation={code}";

        }
       
    }
}