using AspCoreAngular.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspCoreAngular.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : Controller
    {
        ApplicationContext db;
        public UserController(ApplicationContext context)
        {
            db = context;
            if (!db.Users.Any())
            {
                db.Users.Add(new User { Name = "Mike", Active = false });
                db.Users.Add(new User { Name = "William", Active = false });
                db.Users.Add(new User { Name = "James", Active = false });
                db.Users.Add(new User { Name = "Harper", Active = false });
                db.Users.Add(new User { Name = "Michael", Active = false });
                db.Users.Add(new User { Name = "Harry", Active = false });
                db.Users.Add(new User { Name = "Thomas", Active = false });
                db.Users.Add(new User { Name = "Oscar", Active = false });
                db.Users.Add(new User { Name = "George", Active = false });
                db.Users.Add(new User { Name = "Jacob", Active = false });
                db.SaveChanges();
            }
        }

        [HttpGet]
        public IEnumerable<User> Get()
        {
            return db.Users.ToList();
        }

        [HttpPut]
        public IActionResult Put(User user)
        {
            if (ModelState.IsValid)
            {
                db.Update(user);
                db.SaveChanges();
                return Ok(user);
            }
            return BadRequest(ModelState);
        }
    }
}
