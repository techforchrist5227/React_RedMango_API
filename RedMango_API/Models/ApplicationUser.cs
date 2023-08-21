using Microsoft.AspNetCore.Identity;

namespace RedMango_API.Models
{
    public class ApplicationUser : IdentityUser
    {
        /// <summary>
        /// information regarding the User to be logged in
        /// </summary>
        public string Name { get; set; }
    }
}
