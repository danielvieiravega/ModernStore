using System;
using ModernStore.Domain.Entities;

namespace ModernStore.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var user = new User("danielvieiravega", "Vega123");
            var customer = new Customer("a", "A", "a", user);
            customer.User.Activate();

            if (!customer.IsValid())
            {
                foreach (var notification in customer.Notifications)
                {
                    System.Console.WriteLine(notification.Message);
                }
            }
        }
    }
}
