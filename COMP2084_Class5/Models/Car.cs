using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace COMP2084_Class5.Models
{
    public class Car
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(100), MinLength(2)]
        public string Model { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage = "Make cannot be longer than 100 chars"), MinLength(2, ErrorMessage = "Make cannot be shorter than 2 chars")]
        public string Make { get; set; }
        [Required]
        [Range(1900, 2999)]
        public int Year { get; set; }
        [NotMapped]
        public string CompositeName
        {
            get { return $"{Model} - {Year}"; }
        }
        [ForeignKey("Engine")]
        public int? EngineId { get; set; }
        public Engine? Engine { get; set; }
    }
}
