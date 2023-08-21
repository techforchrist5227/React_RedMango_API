using System.ComponentModel.DataAnnotations;

namespace RedMango_API.Models.Dto
{//ID is not required when creating a new menu Item so creating a new class file dto is necessary
    public class MenuItemCreateDTO
    {

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public string SpecialTag { get; set; }
        [Range(1, int.MaxValue)]//$1 t0 max value 
        public double Price { get; set; }
        public IFormFile File { get; set; }//url for azure storage account
        public string Category { get; internal set; }
    }
}
