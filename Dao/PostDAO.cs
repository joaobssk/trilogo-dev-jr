using System.Collections.Generic;
using System.Linq;
using mvc.Models;
using mvc.Utils;

namespace mvc.Dao
{
    public class PostDAO
    {
        
        List<Post> _posts = new List<Post>();

        public PostDAO()
        {
            _posts = PostRepository.Posts;
        }

        public void Add(Post post)
        {
            _posts.Add(post);
        }

        public IEnumerable<Post> GetAll()
        {
            return _posts;
        }

        public Post GetPost(int id)
        {
            return _posts.FirstOrDefault(p => p.Id == id);
        }

        public bool Delete(int id)
        {
            var post = GetPost(id);
            return _posts.Remove(post);
        }

        public bool Update(Post post)
        {
            var postFromList = this.GetPost(post.Id);
            var index = _posts.IndexOf(postFromList);

            if (index == -1 )
            {
                return false;
            }
            _posts[index] = post;
            return true;

        }


    }
}