using Model.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DataAccessObject
{
    public class ContactDAO
    {
        private OnlineShopDbContext db = new OnlineShopDbContext();

        public Contact GetActiveContact()
        {
            return db.Contacts.SingleOrDefault(x => x.Status);
        }

        public int Insert(Feedback newFeedBack)
        {
            db.Feedbacks.Add(newFeedBack);
            return db.SaveChanges();
        }
    }
}