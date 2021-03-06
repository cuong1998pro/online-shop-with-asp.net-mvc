﻿using Model.EntityFramework;
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

        public bool ChangeStatus(int id)
        {
            var user = DataAccess.Db.Users.Find(id);
            user.Status = !user.Status;
            DataAccess.Db.SaveChanges();
            return user.Status;
        }

        public bool CheckUserName(string username)
        {
            return DataAccess.Db.Users.Count(x => x.UserName == username) > 0;
        }

        public bool CheckEmail(string email)
        {
            return DataAccess.Db.Users.Count(x => x.Email == email) > 0;
        }

        public int InsertForFacebook(User user)
        {
            var db = DataAccess.Db;
            var result = db.Users.SingleOrDefault(x => x.UserName == user.UserName);
            if (result == null)
            {
                db.Users.Add(user);
                db.SaveChanges();
                return user.ID;
            }
            return result.ID;
        }

        public List<string> GetListCredential(string username)
        {
            var db = DataAccess.Db;
            var user = GetByUsername(username);
            var data = (from a in db.Credentials
                        join b in db.UserGroups
                        on a.UserGroupID equals b.ID
                        join c in db.Roles
                        on a.RoleID equals c.ID
                        where user.GroupID == b.ID
                        select new { role = a.RoleID }).ToList();
            ;
            var result = data.Select(x => x.role).ToList();
            return result;
        }
    }
}