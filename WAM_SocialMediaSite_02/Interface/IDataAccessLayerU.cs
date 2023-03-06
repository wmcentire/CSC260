using WAM_SocialMediaSite_02.Models;

namespace WAM_SocialMediaSite_02.Interface
{
    public interface IDataAccessLayerU
    {
        IEnumerable<User> GetUsers();
        void AddUser(User user);
        void RemoveUser(string? id);
        User GetUserById(string? id);
        void EditUser(User user);
    }
}
