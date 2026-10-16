using System.ComponentModel.DataAnnotations;

namespace TP_Product.ViewModels
{
    public class EditRoleViewModel
    {
        public EditRoleViewModel()
        {
            Users = new List<string>();
        }

        public string Id { get; set; }

        [Required(ErrorMessage = "Le nom du rôle est obligatoire")]
        [Display(Name = "Nom du rôle")]
        public string RoleName { get; set; }

        public List<string> Users { get; set; }
    }
}