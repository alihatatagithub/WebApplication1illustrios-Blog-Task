using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1illustrios_Blog_Task.Models;

namespace WebApplication1illustrios_Blog_Task.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        
     
        public ActionResult Index()
        {
            return View(db.Blogs.ToList());
        }

        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            Session["UserID"] = User.Identity.GetUserId();
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        //[Authorize]
        [HttpPost]
        
        public List<Post> Like(int id)
        {

            var userid = Session["UserID"].ToString();
            var user = db.Users.Find(userid);
            var PostId = id;
            var post = db.Posts.FirstOrDefault(a=>a.Id == PostId);
         
           
                post.Like = true;
                db.SaveChanges();
            
          

            return db.Posts.ToList();

        }

 
        public ActionResult LikeAction()
        {
            return View(db.Posts);
        }
        [HttpPost]
        public List<Post> DisLike(int id)
        {

            var userid = Session["UserID"].ToString();
            var user = db.Users.Find(userid);
            var PostId = id;
            var post = db.Posts.FirstOrDefault(a => a.Id == PostId);


            post.Like = false;
            db.SaveChanges();



            return db.Posts.ToList();

        }
        [Authorize]
   
        public ActionResult DisLikeAction()
        {


            return View(db.Posts);

        }

        public ActionResult ViewAction(int? id)
        {
            if (id==1)
            {
                return Content("You Are Liked This");
            }
            else if (id==2)
            {
                return Content("You Are Disliked This");

            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}