using IdentityTable.MailModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityTable.Repos
{
    public interface IMailService
    {
        Task SendEmailAsync(MailRequest mailRequest);
    }
}
