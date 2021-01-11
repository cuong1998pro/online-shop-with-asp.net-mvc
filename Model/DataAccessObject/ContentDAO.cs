using Common;
using Model.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using X.PagedList;

namespace Model.DataAccessObject
{
    public class ContentDAO
    {
        public IEnumerable<Model.EntityFramework.Content> ListAllByPaging(string searchString, int page, int pageSize)
        {
            IQueryable<Model.EntityFramework.Content> model = DataAccess.Db.Contents;
            var contents = DataAccess.Db.Categories.Find(1).Contents;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.MetaTitle.Contains(searchString) || x.Name.Contains(searchString));
            }
            return model.OrderByDescending(x => x.CreatedDate).ToPagedList(page, pageSize);
        }

        public List<Model.EntityFramework.Content> ListAllByPaging(ref int totalRecord, int pageIndex = 1, int pageSize = 10)
        {
            var db = DataAccess.Db;
            var contents = db.Contents.OrderBy(x => x.CreatedDate);
            totalRecord = contents.Count();
            var model = contents.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            return model;
        }

        public List<Model.EntityFramework.Content> ListAllByPagingAndTag(string tagID, ref int totalRecord, int pageIndex = 1, int pageSize = 10)
        {
            var db = DataAccess.Db;
            var contents = (from a in db.Contents
                            join b in db.ContentTags
                            on a.ID equals b.ContentID
                            where b.TagID.Equals(tagID)
                            select new
                            {
                                Name = a.Name,
                                Image = a.Image,
                                MetaTitle = a.MetaTitle,
                                Description = a.Description,
                                Detail = a.Detail,
                                CreatdDate = a.CreatedDate,
                                CreatedBy = a.CreatedBy,
                                ID = a.ID
                            })
                            .ToList()
                            .Select(x => new Model.EntityFramework.Content()
                            {
                                MetaTitle = x.MetaTitle,
                                Name = x.Name,
                                Image = x.Image,
                                Description = x.Description,
                                Detail = x.Detail,
                                CreatedDate = x.CreatdDate,
                                CreatedBy = x.CreatedBy,
                                ID = x.ID
                            }).ToList();
            totalRecord = contents.Count();
            var model = contents.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            return model;
        }

        public IEnumerable<Model.EntityFramework.Content> ListAll()
        {
            return DataAccess.Db.Contents.Where(x => x.Status).ToList();
        }

        public Model.EntityFramework.Content GetByID(int id)
        {
            return DataAccess.Db.Contents.Find(id);
        }

        public int Update(Model.EntityFramework.Content model)
        {
            var db = DataAccess.Db;
            var old = db.Contents.Find(model.ID);

            if (string.IsNullOrEmpty(model.MetaTitle))
            {
                model.MetaTitle = StringHelper.ToUnsignString(model.Name);
            }

            model.ModifiedDate = DateTime.Now;
            model.ModifiedBy = HttpContext.Current.User.Identity.Name.ToString();
            db.Entry(old).CurrentValues.SetValues(model);
            DataAccess.Db.SaveChanges();

            this.RemoveAllContentTag(model.ID);

            //lay danh sach tag
            if (!string.IsNullOrEmpty(model.Tags))
            {
                string[] tags = model.Tags.Split(',');
                foreach (var tag in tags)
                {
                    var tagId = StringHelper.ToUnsignString(tag);
                    var existedTag = CheckTag(tagId);
                    if (!existedTag)
                    {
                        this.InsertTag(tagId, tag);
                    }
                    this.InsertContentTag((int)model.ID, tagId);
                }
            }

            return 1;
        }

        public void RemoveAllContentTag(long contentID)
        {
            DataAccess.Db.ContentTags.RemoveRange(DataAccess.Db.ContentTags.Where(x => x.ContentID == contentID));
            DataAccess.Db.SaveChanges();
        }

        public void Delete(int id)
        {
            var user = DataAccess.Db.Contents.Find(id);
            DataAccess.Db.Contents.Remove(user);
            DataAccess.Db.SaveChanges();
        }

        public int Create(Model.EntityFramework.Content content)
        {
            var db = DataAccess.Db;

            if (string.IsNullOrEmpty(content.MetaTitle))
            {
                content.MetaTitle = StringHelper.ToUnsignString(content.Name);
            }

            db.Contents.Add(content);
            db.SaveChanges();

            //lay danh sach tag
            if (!string.IsNullOrEmpty(content.Tags))
            {
                string[] tags = content.Tags.Split(',');
                foreach (var tag in tags)
                {
                    var tagId = StringHelper.ToUnsignString(tag);
                    var existedTag = CheckTag(tagId);
                    if (!existedTag)
                    {
                        this.InsertTag(tagId, tag);
                    }
                    this.InsertContentTag((int)content.ID, tagId);
                }
            }
            return (int)content.ID;
        }

        public bool CheckTag(string id)
        {
            return DataAccess.Db.Tags.Count(x => x.ID == id) > 0;
        }

        public void InsertContentTag(int contentID, string tagID)
        {
            var contentTag = new ContentTag() { ContentID = contentID, TagID = tagID };
            DataAccess.Db.ContentTags.Add(contentTag);
            DataAccess.Db.SaveChanges();
        }

        public void InsertTag(string id, string name)
        {
            var tag = new Tag() { ID = id, Name = name };
            DataAccess.Db.Tags.Add(tag);
            DataAccess.Db.SaveChanges();
        }

        public List<Tag> ListTag(int contentID)
        {
            var db = DataAccess.Db;
            var model = (from a in db.Tags
                         join b in db.ContentTags
                         on a.ID equals b.TagID
                         where b.ContentID == contentID
                         select new
                         {
                             ID = b.TagID,
                             Name = a.Name
                         }).ToList()
                         .Select(x => new Tag()
                         {
                             ID = x.ID,
                             Name = x.Name
                         });
            return model.ToList();
        }

        public Tag GetTagByID(string id)
        {
            return DataAccess.Db.Tags.Find(id);
        }
    }
}