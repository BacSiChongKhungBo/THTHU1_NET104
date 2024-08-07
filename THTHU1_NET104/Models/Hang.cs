using System.ComponentModel.DataAnnotations;

namespace THTHU1_NET104.Models
{
    public class Hang
    {
        public Hang(string iD, string tenHang)
        {
            ID = iD;
            TenHang = tenHang;
        }

        [Key]
        public string ID { get; set; }
        public string TenHang { get; set; }
    }
}
