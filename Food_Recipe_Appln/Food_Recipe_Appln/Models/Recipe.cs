using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Food_Recipe_Appln.Models
{
    public class Recipe
    {
        [JsonIgnore]
        [Key]
        public int Recipe_id { get; set; }
        [Required]
        public string Recipe_Name { get; set; }
        [Required]
        public string Ingrdients { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
