using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeaShop.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string password, string email, string subject, string message);
    }
}
