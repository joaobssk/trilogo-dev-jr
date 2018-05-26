using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using mvc.Models;
using mvc.Utils;
using Newtonsoft.Json;

namespace mvc.Controllers
{
    public class PostsController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Posts = PostRepository.Posts.FindAll(p => p.UserId == 1);
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
