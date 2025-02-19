using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Food_Recipe_Appln.Models
{
    public class Login
    {
        [JsonIgnore]
        [Key]
        public int Id { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string PassWord { get; set; }
        [Required]
        public string UserType { get; set; }
    }
}
