using Model.EntityFramework;
using System.Collections.Generic;
using System.Linq;
using PagedList;

namespace Model.DataAccessObject
{
    public class UserDAO
    {
        public int Insert(User user)
        {
            DataAccess.Db.Users.Add(user);

            return DataAccess.Db.SaveChanges();
        }

        public object Login(string username, string password)
        {
            var user = DataAccess.Db.Users.SingleOrDefault(X => X.UserName == username);
            if (user == null)
            {
                return "Tài khoản không tồn tại.";
            }
            else if (user.Status == false)
            {
                return "Tài khoản bị khoá.";
            }
            else if (user.Password != password)
            {
                return "Mật khẩu không đúng.";
            }
            else
            {
                return true;
            }
        }

        public User GetByUsername(string userName)
        {
            return DataAccess.Db.Users.SingleOrDefault(x => x.UserName == userName);
        }

        public IEnumerable<User> ListAllByPaging(int page, int pageSize)
        {
            return DataAccess.Db.Users.OrderByDescending(x => x.CreatedDate).ToPagedList(page, pageSize);
        }

        public IEnumerable<User> ListAll()
        {
            return DataAccess.Db.Users.ToList();
        }
    }
}