
namespace Atay.MVC4Samples.Web.Controllers
{
    using System.Web.Mvc;

    using Atay.MVC4Samples.Web.Models;

    public class CommentsController : Controller
    {
        private readonly IPageRepository pageRepository;
        private readonly ICommentRepository commentRepository;

        // If you are using Dependency Injection, you can delete the following constructor
        public CommentsController()
            : this(new PageRepository(), new CommentRepository())
        {
        }

        public CommentsController(IPageRepository pageRepository, ICommentRepository commentRepository)
        {
            this.pageRepository = pageRepository;
            this.commentRepository = commentRepository;
        }

        // GET: /Comments/
        public ViewResult Index()
        {
            return this.View(this.commentRepository.AllIncluding(comment => comment.Page));
        }

        // GET: /Comments/Details/5
        public ViewResult Details(int id)
        {
            return View(commentRepository.Find(id));
        }

        // GET: /Comments/Create
        public ActionResult Create()
        {
            ViewBag.PossiblePages = this.pageRepository.All;
            return View();
        }

        // POST: /Comments/Create
        [HttpPost]
        public ActionResult Create(Comment comment)
        {
            if (ModelState.IsValid)
            {
                this.commentRepository.InsertOrUpdate(comment);
                this.commentRepository.Save();

                return RedirectToAction("Index");
            }

            this.ViewBag.PossiblePages = this.pageRepository.All;
            return this.View();
        }

        // GET: /Comments/Edit/5
        public ActionResult Edit(int id)
        {
            this.ViewBag.PossiblePages = this.pageRepository.All;

            return this.View(this.commentRepository.Find(id));
        }

        // POST: /Comments/Edit/5
        [HttpPost]
        public ActionResult Edit(Comment comment)
        {
            if (ModelState.IsValid)
            {
                this.commentRepository.InsertOrUpdate(comment);
                this.commentRepository.Save();
                return RedirectToAction("Index");
            }

            this.ViewBag.PossiblePages = this.pageRepository.All;
            return this.View();
        }

        // GET: /Comments/Delete/5
        public ActionResult Delete(int id)
        {
            return this.View(this.commentRepository.Find(id));
        }

        // POST: /Comments/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            this.commentRepository.Delete(id);
            this.commentRepository.Save();

            return RedirectToAction("Index");
        }
    }
}

