using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEndv2.Data
{
    [Table("PerfumeDetail")]
    public class PerfumeDetail
    {

        [Key]
        public int id { get; set; }
        [MaxLength(100)]
        public string? name { get; set; }
        [Range(0, double.MaxValue)]
        public int pice { get; set; }
        [MaxLength(100)]
        public string? brand { get; set; }
        public string? description { get; set; }
        public string? notes { get; set; }
        public string? url { get; set; }
    }
}
