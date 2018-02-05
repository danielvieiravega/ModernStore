using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidator;
using ModernStore.Domain.Entities;

namespace ModernStore.Domain.ValueObjects
{
    public class Email : Notifiable
    {
        public Email(string address)
        {
            Address = address;

            //Validações
            new ValidationContract<Email>(this)
                .IsEmail(x => x.Address, "emaik obrigatorio");
        }

        public string Address { get; private set; }
    }
}
