namespace Model.EntityFramework
{
    using Model.Content;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProductCategory")]
    public partial class ProductCategory
    {
        public long ID { get; set; }

        [CustomMaxLength(250)]
        public string Name { get; set; }

        [CustomMaxLength(250)]
        public string MetaTitle { get; set; }

        public long? ParentID { get; set; }

        public int? DisplayOrder { get; set; }

        [CustomMaxLength(250)]
        public string SeoTitle { get; set; }

        public DateTime? CreatedDate { get; set; }

        [CustomMaxLength(50)]
        public string CreatedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [CustomMaxLength(50)]
        public string ModifiedBy { get; set; }

        [CustomMaxLength(250)]
        public string MetaKeywords { get; set; }

        [CustomMaxLength(250)]
        public string MetaDescription { get; set; }

        public bool Status { get; set; }

        public bool ShowOnHome { get; set; }
    }
}