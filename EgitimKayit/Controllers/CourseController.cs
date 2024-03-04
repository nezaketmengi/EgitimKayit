using EgitimKayit.Models;
using Microsoft.AspNetCore.Mvc;

namespace EgitimKayit.Controllers
{
    public class CourseController : Controller
    {
        public IActionResult Index()
        {
            var model = Respository.Applications;
            return View(model);
        }
        public IActionResult Apply()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken] //sistemin hacklenmemesi için gelen verinin hangi tarayıcıdan geldiğini doğrulamak adına ekledik.
        public IActionResult Apply([FromForm]Candidate model) //üzerinde çalıştığımız verinin nereden geldiğini göstermek için [] içerisine from ile ekleme yapabiliriz.
        {

            if(Respository.Applications.Any(c => c.Email.Equals(model.Email)))
            {
                ModelState.AddModelError("", "There is already an application for you.");
            }
            if(ModelState.IsValid)
            {
                Respository.Add(model);
                return View("Feedback", model);
            }
            return View();
        }
    }
}