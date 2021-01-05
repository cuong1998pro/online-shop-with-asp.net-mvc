namespace Model.EntityFramework
{
    using Model.Content;
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Content")]
    public partial class Content
    {
        public long ID { get; set; }

        [CustomMaxLength(250)]
        public string Name { get; set; }

        [CustomMaxLength(250)]
        public string MetaTitle { get; set; }

        [CustomMaxLength(500)]
        public string Description { get; set; }

        [CustomMaxLength(250)]
        public string Image { get; set; }

        public long? CategoryID { get; set; }

        [Column(TypeName = "ntext")]
        public string Detail { get; set; }

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

        public DateTime? TopHot { get; set; }

        public int? ViewCount { get; set; }

        [CustomMaxLength(500)]
        public string Tags { get; set; }
    }
}