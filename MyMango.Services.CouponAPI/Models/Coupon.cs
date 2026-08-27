using System.ComponentModel.DataAnnotations;

namespace MyMango.Services.CouponAPI.Models
{
    public class Coupon
    {

        [Key]
        public int CouponId { get; set; }
        [Required]
        public string CouponCode { get; set; }
        [Required]
        public double DiscountAmount { get; set; }
        public int MinAmount { get; set; }
    }
}
