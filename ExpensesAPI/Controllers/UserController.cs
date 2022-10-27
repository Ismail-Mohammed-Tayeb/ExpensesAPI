using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ExpensesAPI.Managers;
using ExpensesAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExpensesAPI.Controllers
{
    public class UserController : Controller
    {
        [Route("user/getusers")]
        [HttpGet]
        public IEnumerable<User> GetUsers()
        {
            return UserManager.GetUsers();
        }

        [Route("user/getuserbyid")]
        [HttpGet]
        public User GetUser([FromQuery] int id)
        {
            return UserManager.GetUserByID(id);
        }


        [Route("user/insertuser")]
        [HttpPost]
        public long InsertUser([FromBody] User user)
        {
            Debug.WriteLine($"Got User With Password: {user.Password}");
            return UserManager.InsertUser(user);
        }


        [Route("user/updateuser")]
        [HttpPost]
        public long UpdateUser([FromBody] User user)
        {
            return UserManager.UpdataUser(user);

        }


    }
}

