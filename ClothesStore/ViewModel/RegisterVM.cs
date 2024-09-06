using System.ComponentModel.DataAnnotations;

namespace ClothesStore.ViewModel
{
    public class RegisterVM
    {
        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Compare("Password")]
        [DataType(DataType.Password)]
        [Display(Name ="Confirm Password")]
        public string ConfirmPassword { get; set; }

        [Required]
        public string Address { get; set; }
        [Range(18,80)]
        public int Age { get; set; }
    }
}
