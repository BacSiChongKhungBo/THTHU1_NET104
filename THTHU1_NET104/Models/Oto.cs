using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace THTHU1_NET104.Models
{
    public class Oto
    {
        [Key]
        public string ID { get; set; }
        public string Ten { get; set; }
        [ForeignKey("Hang")]
        public string IDHang { get; set; }
        public double Gia { get; set; }
        public Hang Hang { get; set; }
    }
}
