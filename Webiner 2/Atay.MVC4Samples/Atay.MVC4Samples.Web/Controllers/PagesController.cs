
namespace Atay.MVC4Samples.Web.Controllers
{
    using System.Web.Mvc;

    using Atay.MVC4Samples.Web.Models;

    public class PagesController : Controller
    {
        private readonly IPageRepository pageRepository;

        // If you are using Dependency Injection, you can delete the following constructor
        public PagesController()
            : this(new PageRepository())
        {
        }

        public PagesController(IPageRepository pageRepository)
        {
            this.pageRepository = pageRepository;
        }

        // GET: /Pages/
        public ViewResult Index()
        {
            return this.View(this.pageRepository.AllIncluding(page => page.Comments));
        }

        // GET: /Pages/Details/5
        public ViewResult Details(int id)
        {
            return this.View(this.pageRepository.Find(id));
        }

        // GET: /Pages/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Pages/Create
        [HttpPost]
        public ActionResult Create(Page page)
        {
            if (ModelState.IsValid)
            {
                this.pageRepository.InsertOrUpdate(page);
                this.pageRepository.Save();
                return RedirectToAction("Index");
            }

            return this.View();
        }

        // GET: /Pages/Edit/5
        public ActionResult Edit(int id)
        {
            return this.View(this.pageRepository.Find(id));
        }

        // POST: /Pages/Edit/5
        [HttpPost]
        public ActionResult Edit(Page page)
        {
            if (ModelState.IsValid)
            {
                this.pageRepository.InsertOrUpdate(page);
                this.pageRepository.Save();
                return RedirectToAction("Index");
            }

            return this.View();
        }

        // GET: /Pages/Delete/5
        public ActionResult Delete(int id)
        {
            return this.View(this.pageRepository.Find(id));
        }

        // POST: /Pages/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            this.pageRepository.Delete(id);
            this.pageRepository.Save();

            return RedirectToAction("Index");
        }
    }
}

