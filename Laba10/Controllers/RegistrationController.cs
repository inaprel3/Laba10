using Microsoft.AspNetCore.Mvc;
using Laba10.Models;

namespace Laba10.Controllers
{
    public class RegistrationController : Controller
    {
        private static List<RegistrationForm> _registrations = new List<RegistrationForm>();

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(RegistrationForm model)
        {
            if (ModelState.IsValid)
            {
                _registrations.Add(model);
                int lastIndex = _registrations.Count - 1;
                return RedirectToAction("Confirmation", new { id = lastIndex });
            }

            return View(model);
        }

        public IActionResult Confirmation(int id)
        {
            var model = _registrations[id];
            return View(model);
        }
    }
}