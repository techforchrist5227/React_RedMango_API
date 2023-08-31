using Microsoft.AspNetCore.Identity;

namespace RedMango_API.Models
{
    public class ApplicationUser : IdentityUser
    {
        /// <summary>
        /// information regarding the User that will log into our app
        /// </summary>
        public string Name { get; set; }
    }
}
