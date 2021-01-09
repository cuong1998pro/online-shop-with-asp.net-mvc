using Model.Content;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Models
{
    public class RegisterModel
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "Tên đăng nhập")]
        [CustomRequired]
        public string UserName { get; set; }

        [Display(Name = "Mật khẩu")]
        [CustomRequired]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "Độ dài mật khẩu ít nhất 6 ký tự")]
        [Compare("Password", ErrorMessage = "Xác nhận không đúng")]
        public string Password { get; set; }

        [Display(Name = "Xác nhận")]
        public string Confirm { get; set; }

        [Display(Name = "Họ tên")]
        [CustomRequired]
        public string Name { get; set; }

        [Display(Name = "Địa chỉ")]
        public string Address { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Điện thoại")]
        [CustomRequired]
        public string Phone { get; set; }

        public string CaptchaCode { get; set; }
    }
}