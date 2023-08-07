using Microsoft.AspNetCore.Mvc;
using MenuDyn.Models;
using MenuDyn.Helpers;
using Microsoft.AspNetCore.Mvc;


namespace MenuDyn.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class MenuController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Menu> Get(int userID)
        {
            using (var context = new DynamicMenuContext())
            {
                return context.Menus.ToList().Where(e => e.MenuId == userID);
            }
        }
    }

}
