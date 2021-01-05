namespace Model.EntityFramework
{
    using Model.Content;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Category")]
    public partial class Category
    {
        public long ID { get; set; }

        [CustomMaxLength(250)]
        [Display(Name = "Tên danh mục")]
        public string Name { get; set; }

        [CustomMaxLength(250)]
        [Display(Name = "Tiêu đề")]
        public string MetaTitle { get; set; }

        [Display(Name = "Danh mục cha")]
        public long? ParentID { get; set; }

        [Display(Name = "Thứ tự hiển thị")]
        public int? DisplayOrder { get; set; }

        [CustomMaxLength(250)]
        [Display(Name = "Tiêu đề SEO")]
        public string SeoTitle { get; set; }

        [Display(Name = "Ngày tạo")]
        public DateTime? CreatedDate { get; set; }

        [CustomMaxLength(50)]
        [Display(Name = "Người tạo")]
        public string CreatedBy { get; set; }

        [Display(Name = "Ngày cập nhật")]
        public DateTime? ModifiedDate { get; set; }

        [CustomMaxLength(50)]
        [Display(Name = "Người cập nhật")]
        public string ModifiedBy { get; set; }

        [CustomMaxLength(250)]
        [Display(Name = "Từ khoá")]
        public string MetaKeywords { get; set; }

        [CustomMaxLength(250)]
        [Display(Name = "Mô tả chung")]
        public string MetaDescription { get; set; }

        [Display(Name = "Trạng thái")]
        public bool Status { get; set; }

        [Display(Name = "Hiển thị trên trang chủ")]
        public bool ShowOnHome { get; set; }
    }
}