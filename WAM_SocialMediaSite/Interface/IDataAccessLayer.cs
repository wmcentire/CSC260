using WAM_SocialMediaSite_02.Models;
namespace WAM_SocialMediaSite_02.Interface
{
    public interface IDataAccessLayer
    {
        IEnumerable<PostClass> GetPosts();
        void AddPost(PostClass post);
        void RemovePost(string? id);
        PostClass GetPostById(string? id);
        void EditPost(PostClass post);
        IEnumerable<PostClass> FilterPosts(string tag);
    }
}
