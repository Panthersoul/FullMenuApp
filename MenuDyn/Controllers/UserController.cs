using MenuDyn.Models;
using MenuDyn.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;


namespace MenuDyn.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {

        [HttpGet]
        public IEnumerable<UserMenu> Get()
        {
                using (var context = new DynamicMenuContext())
                {
                    return context.UserMenus.ToList();
                }
           }


        [HttpGet]
        [Route("byId")]
        public UserMenu GetById(int id)
        {
            using (var context = new DynamicMenuContext())
            {
                return context.UserMenus.Single(e => e.UsrId == id);
            }

        }

        [HttpPost]
        [Route("add")]
        public void AddUser(UserMenu user)
        {

         using (var context = new DynamicMenuContext())
            {
                context.UserMenus.Add(user);
                context.SaveChanges();
            }
        }

        [HttpPut]
        [Route("Update")]
        public void Update(UserMenu user)
        {

            using (var context = new DynamicMenuContext())
            {
                context.UserMenus.Update(user);
                context.SaveChanges();
            }
        }

    }
}