using System.ComponentModel.DataAnnotations;

namespace TP_Product.ViewModels
{
    public class EditViewModel : CreateViewModel
    {
        public string ExistingImagePath { get; set; }
    }
}