using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AzsWebApi.Models
{
    [Table("Data")]
    public class Data
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = null!;

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int AmountOfFuel { get; set; }

        [Required]
        public int Station_ID { get; set; }
    }
}
