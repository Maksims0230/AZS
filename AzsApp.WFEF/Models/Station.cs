using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspApp.WFEF.Models
{
    [Table("Station")]
    public class Station
    {
        public Station()
        {
            Data = new List<Data>();
        }

        [Key]
        [Required]
        public int Station_ID { get; set; }

        [Required]
        public string Address { get; set; } = null!;


        [ForeignKey(nameof(Station_ID))]
        public virtual ICollection<Data> Data { get; set; }
    }
}
