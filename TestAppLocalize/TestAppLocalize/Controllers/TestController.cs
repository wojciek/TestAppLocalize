using System;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web.Mvc;
using TestAppLocalize.Models;

namespace TestAppLocalize.Controllers
{
  public class TestController : BaseController
  {
    public ActionResult Index(string language)
    {
      return View();
    }

    public ActionResult Test()
    {
      return RedirectToAction("Index");
    }

    [HttpGet]
    public ActionResult SummaryTest(TestFormModel model)
    {
      var modelToReturn = new TestSummaryViewModel() { Nickname = model.Nickname, Email = model.Email };
      return View(modelToReturn);


    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult SumbitTestForm(TestFormModel inputModel)
    {
      if (String.IsNullOrEmpty(inputModel.Nickname))
      {
        ModelState.AddModelError(nameof(inputModel.Nickname), "Nickname is required");
      }

      if (inputModel.Nickname.Length > 10)
      {
        ModelState.AddModelError(nameof(inputModel.Nickname), "Nickname is to long");
      }

      if (!String.IsNullOrEmpty(inputModel.Email))
      {
        string emailRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                                         @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                                            @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
        Regex re = new Regex(emailRegex);
        if (!re.IsMatch(inputModel.Email))
        {
          ModelState.AddModelError(nameof(inputModel.Email), "Email is not valid");
        }
      }
      else
      {
        ModelState.AddModelError(nameof(inputModel.Email), "Email is required");
      }

      if (ModelState.IsValid)
      {
        var outputModel = new TestSummaryViewModel() { Nickname = inputModel.Nickname, Email = inputModel.Email };
        return RedirectToAction("SummaryTest", outputModel);
        // return View("SummaryTest", outputModel);
      }
      else
      {
        return View("Index", inputModel);
      }

    }
  }
}
