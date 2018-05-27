using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using mvc.Dao;
using mvc.Models;
using mvc.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace mvc.Controllers
{
    [Produces("application/json")]
    [Route("api/Post")]
    public class PostController : Controller
    {
        private PostDAO dao;

        public PostController()
        {
             dao = new PostDAO();
        }

        //GET: api/Post
        [HttpGet]
        public IEnumerable<Post> Get()
        {
            //var posts = await service.GetAll();
            return dao.GetAll();
        }

        // GET: api/Post/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            try
            {
                var post = dao.GetPost(id);
                return Ok(post);

            }
            catch (KeyNotFoundException e)
            {
                return NotFound($"O Post {id} não foi encontrado!");
            }
        }
        
        // POST: api/Post
        [HttpPost]
        public IActionResult Post([FromBody]Post post)
        {
            dao.Add(post);
            return Ok();
        }
        
        // PUT: api/Post/5
        [HttpPut]
        public IActionResult Put([FromBody]Post post)
        {
            if (dao.Update(post))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (dao.Delete(id))
            {
                return Ok($"Post {id} deletado!");
            }
            else
            {
                return BadRequest($"Não foi possível deletar o post {id}!");
            }
        }
    }
}
