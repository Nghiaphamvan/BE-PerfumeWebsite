using System.ComponentModel.DataAnnotations;

namespace BackEndv2.Models
{
    public class PerfumeDetailModel
    {
        public int id { get; set; }

        [MaxLength(100)]
        public string? name { get; set; }

        public string? description { get; set; }

        [MaxLength(100)]
        public string? type { get; set; }

        [MaxLength(100)]
        public string? state { get; set; }

        [Range(0, double.MaxValue)]
        public int price { get; set; }

        [Range(0, 10000)]
        public int quantity { get; set; }

        [MaxLength(100)]
        public string? origin { get; set; }
    }
}
