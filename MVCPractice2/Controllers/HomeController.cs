using Microsoft.AspNetCore.Mvc;
using MVCPractice2.Model;

namespace MVCPractice2.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            MvcpracticeContext db = new MvcpracticeContext();
            var members = db.Members.ToList();
            return View(members);
        }
        [HttpGet]
        public IActionResult Create()
        {
            Member member = new Member();
            return View(member);
        }
        [HttpPost]
        public IActionResult Create(Member member)
        {
            MvcpracticeContext db = new MvcpracticeContext();
            db.Members.Add(member);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        public IActionResult Delete(int Id)
        {
            MvcpracticeContext db = new MvcpracticeContext();
            var member = db.Members.Find(Id);

            if (member != null)
            {
                db.Members.Remove(member);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int Id)
        {
            MvcpracticeContext db = new MvcpracticeContext();
            var member = db.Members.Find(Id);
            return View(member);
        }
        [HttpPost]
        public IActionResult Edit(Member member)
        {
            MvcpracticeContext db = new MvcpracticeContext();
            db.Members.Update(member);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
