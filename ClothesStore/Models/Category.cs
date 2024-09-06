using System.ComponentModel.DataAnnotations;

namespace ClothesStore.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public List<Product> products { get; set; }

    }
}
