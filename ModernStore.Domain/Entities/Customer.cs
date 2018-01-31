using System;
using FluentValidator;
using ModernStore.Shared.Entities;

namespace ModernStore.Domain.Entities
{
    public class Customer : Entity
    {
        public Customer(
            string firstName,
            string lastName,
            string email,
            User user)
        {
            FirstName = firstName;
            LastName = lastName;
            BirthDate = null;
            Email = email;
            User = user;

            //Validações
            new ValidationContract<Customer>(this)
                .IsRequired(x => x.FirstName, "Nome é obrigatório")
                .HasMaxLenght(x => firstName, 60)
                .HasMinLenght(x => firstName, 3)
                .IsRequired(x => x.LastName, "last name é obrigatório")
                .HasMaxLenght(x => lastName, 60)
                .HasMinLenght(x => lastName, 3)
                .IsEmail(x => x.Email, "emaik obrigatorio");
        }
        
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public DateTime? BirthDate { get; private set; }
        public User User { get; private set; }
        public string Email { get; private set; }

        public void Update(string name, string lastName, DateTime birthDate)
        {
            FirstName = name;
            LastName = lastName;
            BirthDate = birthDate;
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
