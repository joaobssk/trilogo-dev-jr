using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mvc.Dao;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace mvc.Controllers
{
    public class PostDetailController : Controller
    {
        PostDAO dao = new PostDAO();

        public ActionResult Index(int postId)
        {
            var post = dao.GetPost(postId);
            return View(post);
        }
    }
}