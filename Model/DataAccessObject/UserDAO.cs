using Model.EntityFramework;
using System.Linq;

namespace Model.DataAccessObject
{
    public class UserDAO
    {
        public int Insert(User user)
        {
            DataAccess.Db.Users.Add(user);

            return DataAccess.Db.SaveChanges();
        }

        public bool Login (string username, string password)
        {
            var result = DataAccess.Db.Users.Count(X => X.UserName == username && X.Password == password);
            return result > 0;
        }

        public User GetByUsername(string userName)
        {
            return DataAccess.Db.Users.SingleOrDefault(x => x.UserName == userName);
        }
    }
}