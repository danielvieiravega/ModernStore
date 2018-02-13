using System;
using ModernStore.Shared.Commands;

namespace ModernStore.Domain.Commands.Results
{
    public class RegisterCustomerCommandResult : ICommandResult
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
