using Model.Content;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Models
{
    public class LoginModel
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "Tên đăng nhập")]
        [CustomRequired]
        public string Username { get; set; }

        [Display(Name = "Mật khẩu")]
        [CustomRequired]
        public string Password { get; set; }
    }
}