using System;
using System.Collections.Generic;
using ModernStore.Domain.Commands;
using ModernStore.Domain.Commands.Handlers;
using ModernStore.Domain.Commands.Inputs;
using ModernStore.Domain.Entities;
using ModernStore.Domain.Repositories;
using ModernStore.Domain.ValueObjects;

namespace ModernStore.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var command = new RegisterOrderCommand
            {
                Customer = Guid.NewGuid(),
                DeliveryFee = 9,
                Discount = 30,
                Items =  new List<RegisterOrderItemCommand>
                {
                    new RegisterOrderItemCommand
                    {
                        Product = Guid.NewGuid(),
                        Quantity = 3
                    }
                }
            };

            GenerateOrder(new FakeCustomerRepository(), 
                new FakeProductRepository(), 
                new FakeOrderRepository(), 
                command);

            System.Console.ReadKey();
        }

        private static void GenerateOrder(
            ICustomerRepository customerRepository,
            IProductRepository productRepository,
            IOrderRepository orderRepository,
            RegisterOrderCommand command)
        {
            var handler = new OrderCommandHandler(
                customerRepository,
                productRepository,
                orderRepository);
            
            handler.Handle(command);

            if(handler.IsValid())
                System.Console.WriteLine("Pedido cadastrado com sucesso!");
        }
    }

    public class FakeCustomerRepository : ICustomerRepository
    {
        public Customer Get(Guid id)
        {
            return null;
        }

        public Customer GetByUserId(Guid id)
        {
           return new Customer(
               new Name("Daniel", "Vega"),
               new Email("daniel@vega.com"),
               new User("danielvieiravega", "123qwe!@#"),
               new Document("42302169808"));
        }
    }

    public class FakeProductRepository : IProductRepository
    {
        public Product Get(Guid id)
        {
            return new Product("Mouse", 299, "", 10);
        }
    }

    public class FakeOrderRepository : IOrderRepository
    {
        public void Save(Order order)
        {
            //
        }
    }
}
