using Microsoft.AspNetCore.Mvc;
using RandomPasswordGenerator.Models;
using System.Diagnostics;

namespace RandomPasswordGenerator.Controllers
{
    public class HomeController : Controller
    {
        private const string lowerCaseChars = "abcdefghijklmnopqrstuvwxyz";
        private const string upperCaseChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const string numericChars = "0123456789";
        private const string specialChars = "!@#$%^&*()_+";

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GeneratePassword(int passwordLength, bool includeLowerCase, bool includeUpperCase, bool includeNumeric, bool includeSpecialChars)
        {
            var passwordChars = "";
            if (includeLowerCase)
                passwordChars += lowerCaseChars;
            if (includeUpperCase)
                passwordChars += upperCaseChars;
            if (includeNumeric)
                passwordChars += numericChars;
            if (includeSpecialChars)
                passwordChars += specialChars;

            var password = "";
            var random = new Random();
            for (int i = 0; i < passwordLength; i++)
            {
                password += passwordChars[random.Next(0, passwordChars.Length)];
            }

            return Json(new { password });
        }
    }
}