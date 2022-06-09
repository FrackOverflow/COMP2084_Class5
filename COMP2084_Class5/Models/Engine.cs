using System.ComponentModel.DataAnnotations;

namespace COMP2084_Class5.Models
{
    public class Engine
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public ICollection<Car>? Cars { get; set; }
    }
}
