using WAM_SocialMediaSite_02.Interface;
using WAM_SocialMediaSite_02.Models;

namespace WAM_SocialMediaSite_02.Data
{
    public class PostListDAL : IDataAccessLayer
    {
        private ApplicationDbContext db;

        public PostListDAL(ApplicationDbContext indb)
        {
            db = indb;
        }

        public void AddPost(PostClass post)
        {
            db.Add(post);
        }

        public void EditPost(PostClass post)
        {
            db.posts.Update(post);
            db.SaveChanges();
        }

        public IEnumerable<PostClass> FilterPosts(string tag)
        {
            if (tag == "")
            {
                return GetPosts();
            }

            IEnumerable<PostClass> lstPosts = GetPosts().Where
                (g => (!string.IsNullOrEmpty(g.Tag)) && g.Tag.ToLower().Contains(tag.ToLower())).ToList();
            return lstPosts;
        }

        public PostClass GetPostById(string? id)
        {
            //return null;
            return db.posts.Where(m => m.Id == id).FirstOrDefault();
        }

        public IEnumerable<PostClass> GetPosts()
        {
            return db.posts;
        }

        public void RemovePost(string? id)
        {
            PostClass post = GetPostById(id);
            db.posts.Remove(post);
            db.SaveChanges();
        }
    }
}
