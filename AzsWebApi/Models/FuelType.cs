using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AzsWebApi.Models
{
    [Table("FuelType")]
    public class FuelType
    {
        [Key]
        [Required]
        [StringLength(100)]
        public string FuelName { get; set; } = null!;
    }
}
