namespace Model.EntityFramework
{
    using Model.Content;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Feedback")]
    public partial class Feedback
    {
        public int ID { get; set; }

        [CustomMaxLength(50)]
        public string Name { get; set; }

        [CustomMaxLength(50)]
        public string Phone { get; set; }

        [CustomMaxLength(50)]
        public string Email { get; set; }

        [CustomMaxLength(50)]
        public string Address { get; set; }

        [CustomMaxLength(250)]
        public string Content { get; set; }

        public DateTime? CreatedDate { get; set; }

        public bool Status { get; set; }
    }
}