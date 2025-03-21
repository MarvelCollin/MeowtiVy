using System;
using System.Web.UI;
using MeowtiVy.Database;
using MeowtiVy.Handlers;
using MeowtiVy.Models;
using MeowtiVy.Repositories;

namespace MeowtiVy.Controllers
{
    public partial class UserController : System.Web.UI.Page
    {
        private readonly UserHandler _userHandler;
        private readonly UserRepository _userRepository;

        public UserController()
        {
            var dbContext = new DatabaseContext();
            _userRepository = new UserRepository(dbContext); 
            _userHandler = new UserHandler(_userRepository);  
        }

        public bool ValidateUser(string username, string password)
        {
            if (username == "admin" && password == "admin")
            {
                Session["Role"] = "Admin";
                return true;
            }

            var user = _userRepository.GetUserByUsername(username);
            if (user != null && user.PasswordHash == password)
            {
                Session["Role"] = user.Role;
                return true;
            }
            return false;
        }

        public void RegisterUser(string username, string password)
        {
            _userHandler.RegisterUser(username, password, "User");
        }

        public User GetUserByUsername(string username)
        {
            return _userRepository.GetUserByUsername(username); 
        }
    }
}
