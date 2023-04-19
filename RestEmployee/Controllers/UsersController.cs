using DataAccess.Models;
using DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RestEmployee.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpPost]
        public User GetEmployeeByName(User user)
        {
            UserDataAccess access = new UserDataAccess();
            var us = access.Login(user);
            return us;
        }
    }
}
