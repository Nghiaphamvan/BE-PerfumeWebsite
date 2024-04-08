using System.ComponentModel.DataAnnotations;

namespace BackEndv2.Models
{
    public class PerfumeDetailModel
    {
        public int id { get; set; }
        [MaxLength(100)]
        public string? name { get; set; }
        [Range(0, double.MaxValue)]
        public int price { get; set; }
        [MaxLength(100)]
        public string? brand { get; set; }
        public string? description { get; set; }
        public string? notes { get; set; }
        public string? url { get; set; }
        public int volume { get; set; }
    }
}
