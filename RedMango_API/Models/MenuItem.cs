using System.ComponentModel.DataAnnotations;

namespace RedMango_API.Models
{/// <summary>
/// This is the blueprint for the menu items in this api
/// </summary>
    public class MenuItem
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public string SpecialTag{ get; set; }
        [Range(1, int.MaxValue)]//$1 t0 max value 
        public double Price { get; set; }
        [Required]
        public string Image { get; set; }//url for azure storage account
        public string Category { get; internal set; }
    }
}
