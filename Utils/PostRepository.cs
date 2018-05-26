using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using mvc.Controllers;
using mvc.Models;
using Newtonsoft.Json;

namespace mvc.Utils
{
    public static class PostRepository
    {
        private static Service service = Service.GetService();
        public static List<Post> Posts { get; set; }

        //public static List<Post> GetAll()
        public static void GetAll()
        {
            Posts = service.GetAll().Result;
        }
        
    }
}
