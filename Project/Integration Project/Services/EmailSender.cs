using Microsoft.AspNetCore.Identity.UI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Integration_Project.Services {
    public class EmailSender : IEmailSender {
        public Task SendEmailAsync(string email, string subject, string htmlMessage) => throw new NotImplementedException();
    }
}
