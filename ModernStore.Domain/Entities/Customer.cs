using System;
using ModernStore.Domain.ValueObjects;
using ModernStore.Shared.Entities;

namespace ModernStore.Domain.Entities
{
    public class Customer : Entity
    {
        public Customer(
            Name name,
            Email email,
            User user,
            Document document)
        {
            Name = name;
            BirthDate = null;
            Email = email;
            User = user;
            Document = document;

            AddNotifications(name.Notifications);
            AddNotifications(email.Notifications);
            AddNotifications(document.Notifications);
        }

        protected Customer()
        {
            
        }
        
        public Name Name { get; private set; }
        public DateTime? BirthDate { get; private set; }
        public User User { get; private set; }
        public Email Email { get; private set; }
        public Document Document { get; private set; }

        public void Update(Name name, DateTime birthDate)
        {
            Name = name;
            BirthDate = birthDate;
        }
        
    }
}
