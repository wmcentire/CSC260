using WAM_SocialMediaSite_02.Interface;
using WAM_SocialMediaSite_02.Models;

namespace WAM_SocialMediaSite_02.Data
{
    public class UserListDAL : IDataAccessLayerU
    {
        private ApplicationDbContext db;

        public UserListDAL(ApplicationDbContext indb)
        {
            db = indb;
        }
        public void AddUser(User user)
        {
            db.users.Add(user);
        }

        public void EditUser(User user)
        {
            db.users.Update(user);
            db.SaveChanges();
        }

        public User GetUserById(string? id)
        {
            return db.users.Where(m => m.Id == id).FirstOrDefault();
        }

        public IEnumerable<User> GetUsers()
        {
            return db.users.ToList();
        }

        public void RemoveUser(string? id)
        {
            User user = GetUserById(id);
            db.users.Remove(user);
            db.SaveChanges();
        }
        public IEnumerable<User> SearchForUsers(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                return db.users;
            }

            return db.users.Where(c => c.Name.ToLower().Contains(key.ToLower()));
        }
    }
}
