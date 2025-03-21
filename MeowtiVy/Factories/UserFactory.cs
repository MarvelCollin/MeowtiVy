using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MeowtiVy.Models;

namespace MeowtiVy.Factories
{
    public class UserFactory
    {
        public static User CreateUser(string username, string passwordHash, string role)
        {
            return new User
            {
                Username = username,
                PasswordHash = passwordHash,
                Role = role
            };
        }
    }
}