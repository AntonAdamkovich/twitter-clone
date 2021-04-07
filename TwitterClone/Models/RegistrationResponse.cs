using System;
using TwitterClone.Models.Database;

namespace TwitterClone.Models
{
    public class RegistrationResponse
    {
        public Guid Id { get; }

        public RegistrationResponse(User user)
        {
            Id = user.Id;
        }
    }
}