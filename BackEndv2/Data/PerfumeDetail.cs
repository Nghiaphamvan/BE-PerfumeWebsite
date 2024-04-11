using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

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
        public int price { get; set; }
        [MaxLength(100)]
        public string? brand { get; set; }
        public string? description { get; set; }
        public string? notes { get; set; }
        public string? url { get; set; }
        public int volume { get; set; }

        public ICollection<Campaign>? Campaign { get; set; }
        public ICollection<OrderDetail>? OrderDetail { get; set; }
        
    }

    [Table("Categories")]
    public class Categories
    {
        [Key]
        public int categoriID { get; set; }
        [MaxLength(100)]
        public string? name { get; set; }
        public string? type { get; set; }
    }

    [Table("Order")]
    public class Order
    {
        [Key]
        public int orderID { get; set; }
        public int customerId { get; set; }
        public DateTime orderDate { get; set; }
        [Range(0, double.MaxValue)]
        public int totalAmount { get; set; }
        public ICollection<OrderDetail>? OrderDetails { get; set; }
        [ForeignKey("customerId")]
        public Customer? customer { get; set; }
    }

    [Table("OrderDetail")]
    public class OrderDetail
    {
        [Key]
        public int orderDetailID { get; set; }
        public int orderID { get; set; }
        public int id { get; set; }
        [Range(0, double.MaxValue)]
        public int quantity { get; set; }
        [Range(0, double.MaxValue)]
        public int pricePerUnit { get; set; }
        [ForeignKey("orderID")]
        public Order? Order { get; set; }
        [ForeignKey("id")]
        public PerfumeDetail? ids { get; set; }
    }

    [Table("Customer")]
    public class Customer
    {
        [Key]
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
        public ICollection<PaymentMethod>? paymentMethods { get; set; }
        public ICollection<ShippingAddress>? ShippingAddresss { get; set; }
        public ICollection<Order>? Orders { get; set; }

    }


    [Table("paymentMethod")]
    public class PaymentMethod
    {
        [Key]
        public int paymentMethodID { get; set;}
        public int customerID { get; set;}
        public int cardNumber { get; set;}
        public string? expirationdate { get; set;}

        [ForeignKey("customerID")]
        public Customer? customer { get; set; }
    }

    [Table("ShippingAddresses")]
    public class ShippingAddress
    {
        [Key]
        public int shippingAddressID { get; set; }
        public int customerID { get; set; }
        [MaxLength(100)]
        public string? address { get; set; }
        [MaxLength(100)]
        public string? state { get; set; }
        [MaxLength(100)]
        public string? city { get; set;}

        [ForeignKey("customerID")]
        public Customer? customer { get; set; }
    }

    [Table("Campaign")]
    public class Campaign
    {
        [Key]
        public int CampaignID { get; set; }
        public string? nameCampaign { get; set; }
        public int id { get; set; }
        [ForeignKey("id")]
        public PerfumeDetail? PerfumeDetails { get; set; }
    }

    [Table("Sale")]
    public class Sale
    {
        [Key]
        public int saleID { get; set; }
        public int id { get; set; }
        public int per { get; set; }

        [ForeignKey("id")]
        public PerfumeDetail? PerfumeDetails { get; set; }
    }


    [Table("Cart")]
    public class Cart
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CartID { get; set; }
        public int PerfumeDetailID { get; set; }
        public int CustomerID { get; set; }
        [Range(0, int.MaxValue)]
        public int Quantity { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
