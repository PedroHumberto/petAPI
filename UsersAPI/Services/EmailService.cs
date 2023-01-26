using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsersAPI.Models;

namespace UsersAPI.Services
{
    public class EmailService
    {

        internal void SendEmail(string?[] userEmail, string subject, int userId, string code)
        {
            Message mensagem = new Message(userEmail, subject, userId, code);

        }
    }
}