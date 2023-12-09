using System.ComponentModel.DataAnnotations;

namespace DrawingOnDemandAPI.VNPay.Models
{
    public class VNPayRequest
    {
        [Key]
        public string OrderId { get; set; } = null!;
        public decimal Price { get; set; }
        public int Method { get; set; }
        public string Lang { get; set; } = null!;
        public string ReturnUrl { get; set; } = null!;
        public string? PaymentUrl { get; set; }
    }
}
