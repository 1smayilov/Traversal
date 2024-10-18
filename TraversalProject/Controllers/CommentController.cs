using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace TraversalProject.Controllers
{
    public class CommentController : Controller
    {
        CommentManager commentManager = new CommentManager(new EfCommentDal());
        

        public PartialViewResult AddComment(int id)
        {
            ViewBag.destId = id; // İd dəyəri URL dən gəlir
            return PartialView();
        }

        [HttpPost]
        public IActionResult AddComment(Comment comment)
        {
            comment.CommentDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            comment.CommentState = true;
            comment.CommentUser = "dsfds";
            commentManager.Add(comment);
            return RedirectToAction("Index","Destination"); // Destination un içindəki Index ə yönləndirsin
        }

    }
}
