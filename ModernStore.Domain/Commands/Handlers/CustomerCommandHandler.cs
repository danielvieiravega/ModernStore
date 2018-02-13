using FluentValidator;
using ModernStore.Domain.Commands.Inputs;
using ModernStore.Domain.Commands.Results;
using ModernStore.Domain.Entities;
using ModernStore.Domain.Repositories;
using ModernStore.Domain.Resources;
using ModernStore.Domain.Services;
using ModernStore.Domain.ValueObjects;
using ModernStore.Shared.Commands;

namespace ModernStore.Domain.Commands.Handlers
{
    public class CustomerCommandHandler : Notifiable, ICommandHandler<UpdateCustomerCommand>, ICommandHandler<RegisterCustomerCommand>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IEmailService _emailService;

        public CustomerCommandHandler(ICustomerRepository customerRepository, IEmailService emailService)
        {
            _customerRepository = customerRepository;
            _emailService = emailService;
        }

        public ICommandResult Handle(UpdateCustomerCommand command)
        {
            //Passo 1. Recuperar o cliente
            var customer = _customerRepository.Get(command.Id);

            //Passo 2. Caso o cliente não existe
            if (customer == null)
            {
                AddNotification("Customer", "Cliente não encontrado.");
                return null;
            }

            //Passo 3. Atualizar a entidade
            var name = new Name(command.FirstName, command.LastName);
            customer.Update(name, command.BirthDate);

            //Passo 4. Adiciona as notificações
            AddNotifications(customer.Notifications);

            //Passo 5. Persistir no banco
            if (IsValid())
                _customerRepository.Update(customer);

            return null;
        }

        public ICommandResult Handle(RegisterCustomerCommand command)
        {
            //Passo 1. Verificar se o CPF já existe
            if (_customerRepository.DocumentExists(command.Document))
            {
                AddNotification("Document", "Este CPF já está em uso.");
                return null;
            }

            //Passo 2. Gerar o novo cliente
            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document);
            var email = new Email(command.Email);
            var user = new User(command.Username, command.Password, command.ConfirmPassword);
            var customer = new Customer(name, email, user, document);

            //Passo 3. Adicionar as notificações
            AddNotifications(name.Notifications);
            AddNotifications(document.Notifications);
            AddNotifications(email.Notifications);
            AddNotifications(user.Notifications);
            AddNotifications(customer.Notifications);

            //Passo 4. Inserir no banco
            if (IsValid())
                _customerRepository.Save(customer);

            //Passo 5. Enviar email de boas vindas
            _emailService.Send(
                customer.Name.ToString(), 
                customer.Email.Address, 
                string.Format(EmailTemplates.WelcomeEmailTitle, customer.Name),
                string.Format(EmailTemplates.WelcomeEmailBody, customer.Name));

            //Passo 6. Retornar algo
            return new RegisterCustomerCommandResult
            {
                Id = customer.Id,
                Name = customer.Name.ToString()
            };
        }
    }
}
