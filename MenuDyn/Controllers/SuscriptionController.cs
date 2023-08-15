using MenuDyn.Models;
using MenuDyn.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace MenuDyn.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class SuscriptionController : ControllerBase
    {

        [HttpGet]
        public IEnumerable<Suscription> Get()
        {
            using (var context = new DynamicMenuContext())
            {
                return context.Suscriptions.ToList();
            }
        }

        [HttpGet]
        [Route("byId")]
        public IEnumerable<Suscription> Get(int susID)
        {
            using (var context = new DynamicMenuContext())
            {
                return context.Suscriptions.ToList().Where(e => e.SuscriptionId == susID);
            }
        }

        [HttpGet]
        [Route("isActiveByUser")]
        public IEnumerable<Suscription> Get(UserMenu user)
        {
            using (var context = new DynamicMenuContext())
            {
                return context.Suscriptions.ToList().Where(e => e.UserMenus == user);
            }
        }
    }
}


