using Model.EntityFramework;
using System;
using System.Linq.Expressions;

namespace Model.DataAccessObject
{
    public class DataAccess
    {
        private static OnlineShopDbContext _db;

        public static OnlineShopDbContext Db
        {
            get
            {
                if (_db == null)
                {
                    _db = new OnlineShopDbContext();
                }
                return _db;
            }
            set { _db = value; }
        }
    }
}