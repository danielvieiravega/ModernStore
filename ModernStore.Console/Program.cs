﻿using System;
using ModernStore.Domain.Entities;
using ModernStore.Domain.ValueObjects;

namespace ModernStore.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var name = new Name("Daniel", "Vega");
            var email = new Email("vega@daniel.com");
            var user = new User("danielvieiravega", "Vega123");
            var document = new Document("02039746030");
            var customer = new Customer(name, email, user, document);
            var mouse = new Product("mouse", 299, "mouse.jpg", 5);
            var mousepad = new Product("mousepad", 99, "mousepad.jpg", 7);
            var teclado = new Product("teclado", 599, "teclado.jpg", 9);

            var order = new Order(customer, 8, 10);
            order.AddItem(new OrderItem(mouse, 2));
            order.AddItem(new OrderItem(mousepad, 3));
            order.AddItem(new OrderItem(teclado, 1));

            System.Console.WriteLine($"nro pedido: {order.Number}");
            System.Console.WriteLine($"data: {order.CreateDate :yy-MM-dd}");
            System.Console.WriteLine($"desconto: {order.Discount}");
            System.Console.WriteLine($"taxa de entrega: {order.DeliveryFee}");
            System.Console.WriteLine($"sub total: {order.SubTotal()}");
            System.Console.WriteLine($"total: {order.Total()}");
            System.Console.WriteLine($"cliente: {order.Customer.ToString()}");
        }
    }
}
