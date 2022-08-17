using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TestAppLocalize.Models
{
  public class TestFormModel
  {
    [Required(ErrorMessage = "Nickname is required")]
    [Display(Name = "nickname", ResourceType = typeof(Resources.ResourcesTexts))]
    [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
    [MaxLength(30, ErrorMessage = "{0} cannot be greater than {1}")]
    public string Nickname { get; set; }

    [Required(ErrorMessage = "Email Address Id Required")]
    [Display(Name = "email", ResourceType = typeof(Resources.ResourcesTexts))]
    [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$",
    ErrorMessage = "Email Format is wrong")]
    public string Email { get; set; }

  }
}