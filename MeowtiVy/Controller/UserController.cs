using System;
using System.Web.UI;
using MeowtiVy.Database;
using MeowtiVy.Handlers;
using MeowtiVy.Repositories;

namespace MeowtiVy.Controllers
{
    public partial class UserController : System.Web.UI.Page
    {
        private readonly UserHandler _userHandler;

        public UserController()
        {
            var userRepository = new UserRepository(new DatabaseContext());
            _userHandler = new UserHandler(userRepository);
        }

        public bool ValidateUser(string username, string password)
        {
            var user = _userHandler.ValidateUser(username, password);
            return user != null;
        }

        public void RegisterUser(string username, string password)
        {
            _userHandler.RegisterUser(username, password, "User");
        }
    }
}
