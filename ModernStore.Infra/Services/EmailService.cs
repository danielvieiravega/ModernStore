using System;
using ModernStore.Domain.Services;

namespace ModernStore.Infra.Services
{
    public class EmailService : IEmailService
    {
        public void Send(string name, string email, string subject, string body)
        {
            //System.Net. email -> enviar email
        }
    }
}
