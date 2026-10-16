using System.ComponentModel.DataAnnotations;

namespace TP_Product.ViewModels
{
    public class CreateRoleViewModel
    {
        [Required]
        [Display(Name = "Rôle")]
        public string RoleName { get; set; }
    }
}