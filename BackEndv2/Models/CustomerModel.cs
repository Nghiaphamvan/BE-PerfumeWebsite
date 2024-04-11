using System.ComponentModel.DataAnnotations;

namespace BackEndv2.Models
{
    public class CustomerModel
    {
        public int customerID { get; set; }
        [MaxLength(100)]
        public string? firstName { get; set; }
        [MaxLength(100)]
        public string? lastName { get; set; }
        [MaxLength(100)]
        public string? email { get; set; }
        public string? address { get; set; }
        [MaxLength(100)]
        public string? phoneNumber { get; set; }
    }
}
