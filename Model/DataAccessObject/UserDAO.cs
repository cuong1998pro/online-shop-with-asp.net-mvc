using Model.EntityFramework;
using X.PagedList;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model.Content;

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

        public IEnumerable<User> ListAllByPaging(string searchString, int page, int pageSize)
        {
            IQueryable<User> model = DataAccess.Db.Users;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.UserName.Contains(searchString) || x.Name.Contains(searchString));
            }
            return model.OrderByDescending(x => x.CreatedDate).ToPagedList(page, pageSize);
        }

        public IEnumerable<User> ListAll()
        {
            return DataAccess.Db.Users.ToList();
        }

        public bool Update(User entity)
        {
            try
            {
                var user = DataAccess.Db.Users.Find(entity.ID);
                var createdDate = user.CreatedDate.ToString();
                var createdBy = user.CreatedBy.ToString();

                DataAccess.Db.Entry(user).CurrentValues.SetValues(entity);
                user.CreatedDate = DateTime.Parse(createdDate);
                user.CreatedBy = createdBy;
                user.ModifiedDate = DateTime.Now;
                user.ModifiedBy = HttpContext.Current.User.Identity.Name.ToString();
                return DataAccess.Db.SaveChanges() > 0;
            }
            catch
            {
                return false;
            }
        }

        public User ViewDetail(int id)
        {
            return DataAccess.Db.Users.Find(id);
        }

        public bool Delete(int id)
        {
            var user = DataAccess.Db.Users.Find(id);
            DataAccess.Db.Users.Remove(user);
            return DataAccess.Db.SaveChanges() > 0;
        }
    }
}