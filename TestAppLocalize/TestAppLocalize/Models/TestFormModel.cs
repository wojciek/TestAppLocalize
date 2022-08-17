using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TestAppLocalize.Models
{
  public class TestFormModel
  {
    [Required(ErrorMessageResourceType = typeof(Resources.ResourcesTexts), ErrorMessageResourceName= "nicknameRequired")]
    [Display(Name = "nickname", ResourceType = typeof(Resources.ResourcesTexts))]
    [RegularExpression(@"^[a-zA-Z]+$", ErrorMessageResourceName = "useOnlyLetters", ErrorMessageResourceType = typeof(Resources.ResourcesTexts))]
    [MaxLength(30, ErrorMessageResourceName = "nicknameTooLong", ErrorMessageResourceType = typeof(Resources.ResourcesTexts))]
    public string Nickname { get; set; }

    [Required(ErrorMessage = "Email Address Id Required")]
    [Display(Name = "email", ResourceType = typeof(Resources.ResourcesTexts))]
    [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$",
    ErrorMessage = "Email Format is wrong")]
    public string Email { get; set; }

  }
}