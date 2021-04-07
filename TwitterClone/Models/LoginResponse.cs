using System;
using TwitterClone.Models.Database;

namespace TwitterClone.Models
{
    public class LoginResponse
    {
        public Guid Id { get; }

        public LoginResponse(User user)
        {
            Id = user.Id;
        }
    }
}