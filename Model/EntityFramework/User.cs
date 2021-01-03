namespace Model.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using Model.Content;

    [Table("User")]
    public partial class User
    {
        public int ID { get; set; }

        [CustomRequired]
        [CustomMaxLength(50)]
        [Display(Name = "Tên tài khoản")]
        public string UserName { get; set; }

        [StringLength(32)]
        [CustomRequired]
        [Display(Name = "Mật khẩu")]
        public string Password { get; set; }

        [StringLength(50)]
        [Display(Name = "Họ tên")]
        public string Name { get; set; }

        [StringLength(50)]
        [Display(Name = "Địa chỉ")]
        public string Address { get; set; }

        [StringLength(50)]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [StringLength(50)]
        [Display(Name = "Số điện thoại")]
        public string Phone { get; set; }

        [Display(Name = "Ngày tạo")]
        public DateTime? CreatedDate { get; set; }

        [StringLength(50)]
        [Display(Name = "Người tạo")]
        public string CreatedBy { get; set; }

        [Display(Name = "Ngày sửa")]
        public DateTime? ModifiedDate { get; set; }

        [StringLength(50)]
        [Display(Name = "Người sửa")]
        public string ModifiedBy { get; set; }

        [Display(Name = "Trạng thái")]
        public bool Status { get; set; }
    }
}