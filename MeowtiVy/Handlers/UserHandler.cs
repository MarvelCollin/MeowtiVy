using System.Data.Entity.Infrastructure;
using System;
using MeowtiVy.Models;
using MeowtiVy.Repositories;
using System.Diagnostics;

namespace MeowtiVy.Handlers
{
    public class UserHandler
    {
        private readonly UserRepository _userRepository;

        public UserHandler(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User ValidateUser(string username, string password)
        {
            var user = _userRepository.GetUserByUsername(username);
            if (user != null && password == user.PasswordHash)
            {
                return user;
            }
            return null;
        }

        public void RegisterUser(string username, string password, string role)
        {
            var existingUser = _userRepository.GetUserByUsername(username);
            if (existingUser != null)
            {
                throw new Exception("Username already taken");
            }

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                throw new Exception("Username or password cannot be empty");
            }
            Debug.WriteLine("uh");

            User newUser = new User
            {
                Username = username,
                PasswordHash = password, 
                Role = role 
            };

            try
            {
                _userRepository.AddUser(newUser);
            }
            catch (DbUpdateException dbEx)
            {
                string errorMessage = "Database error: " + dbEx.Message;

                if (dbEx.InnerException != null)
                {
                    errorMessage += " AAAAAAA Inner Exception: " + dbEx.InnerException.Message;
                }

                throw new Exception(errorMessage);
            }
            catch (Exception ex)
            {
                string generalError = "General error: " + ex.Message;

                if (ex.InnerException != null)
                {
                    generalError += " Inner Exception: " + ex.InnerException.Message;
                }

                throw new Exception(generalError);
            }
        }

    }
}
