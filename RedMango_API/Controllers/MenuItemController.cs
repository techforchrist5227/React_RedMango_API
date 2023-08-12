using Microsoft.AspNetCore.Mvc;
using RedMango_API.Data;

namespace RedMango_API.Controllers
{
    [Route("api/MenuItem")]
    [ApiController]
    public class MenuItemController : ControllerBase
    {
        private readonly ApplicationDBContext _db; 
        // "_db" is the var for the db

        public MenuItemController(ApplicationDBContext db)
        {//used dependency injection to access the DBContext
            _db = db;

        }
        //get method to get all menu items
        [HttpGet]

        public async Task<IActionResult> GetMenuItems()
        {
            return Ok(_db.MenuItems);
        }
    }
}
