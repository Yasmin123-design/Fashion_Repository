using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ClothesStore.Models
{
    public class Order
    {
        public int Id { get; set; }
        public List<OrderDetail>? orderDetails { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(10)]
        [DisplayName("First Name")]
        public string Fname { get; set; }
        [MinLength(3)]
        [MaxLength(10)]
        [DisplayName("Last Name")]
        public string Lname { get; set; }
        [Required]
        public string Address { get; set; }

        public string City { get; set; }
        public DateTime OrderedPlaced { get; set; }
    }

}
