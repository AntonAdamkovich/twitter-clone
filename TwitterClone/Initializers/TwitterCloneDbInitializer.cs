using System;
using System.Collections.Generic;
using System.Linq;
using TwitterClone.Context;
using TwitterClone.Models.Database; 

namespace TwitterClone.Initializers
{
    public class TwitterCloneDbInitializer
    {
        public static void Initialize(TwitterCloneDbContext context)
        {
            if (context.Users.Any())
            {
                return;
            }

            var users = new List<User>
            {
                new User
                {
                    FirstName = "Marcus",
                    LastName = "Aurelius",
                    Username = "usernameq+1@email.com",
                    AuthId = "auth0|5fe23f1bb2ac50006f70d02e",
                    DateOfBirth = new DateTime(1986, 1, 12),
                    ProfileImageUri = new Uri(""),
                },
                new User
                {
                    FirstName = "John",
                    LastName = "Wick",
                    Username = "usernameaaq+2@email.com",
                    AuthId = "auth0|5fe24283128f9f00699b8d78",
                    DateOfBirth = new DateTime(1993, 7, 22),
                    ProfileImageUri = new Uri(""),
                }
            };

            context.Users.AddRange(users);
            context.SaveChanges();
        }
    }
}