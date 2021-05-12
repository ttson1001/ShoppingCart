using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingCart.Entities
{
    [Table("Carts")]
    public class Cart
    {
        [Key]
        public int CartId { get; set; }
        public int UserId { get; set; }
        public DateTime? CreateDate { get; }
    }
}
