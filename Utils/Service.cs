using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using mvc.Models;
using Newtonsoft.Json;

namespace mvc.Utils
{
    public class Service
    {
        private static Service instance;
        public static Service GetService()
        {
            if (instance == null)
            {
                return instance = new Service();
            }
            else
            {
                return instance;
            }
        }


        public async Task<List<Post>> GetAll()
        {
            using (var _client = new HttpClient())
            {
                _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var json = await _client.GetStringAsync("https://jsonplaceholder.typicode.com/posts/");
                var posts = JsonConvert.DeserializeObject<List<Post>>(json);
               
                return posts;
            }
        }

    }
}
