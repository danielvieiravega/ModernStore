﻿using FluentValidator;

namespace ModernStore.Domain.ValueObjects
{
    public class Email : Notifiable
    {
        protected Email() { }

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
