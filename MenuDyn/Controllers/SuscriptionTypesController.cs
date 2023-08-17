using MenuDyn.Models;
using Microsoft.AspNetCore.Mvc;



namespace MenuDyn.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SuscriptionTypes : ControllerBase
    {
        [HttpGet]
        public IEnumerable<SuscriptionsType> Get()
        {
            using (var context = new DynamicMenuContext())
            {
                
                return context.SuscriptionsType.ToList(); 
            }
        }

        [HttpPost]
        [Route("add")]
        public void addSusType(SuscriptionsType type)
        {
            using (var context = new DynamicMenuContext())
            {
                context.SuscriptionsType.Add(type);
                context.SaveChanges();
            }
        }        
    }
}
