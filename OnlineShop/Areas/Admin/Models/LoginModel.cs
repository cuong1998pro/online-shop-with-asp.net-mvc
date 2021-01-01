using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineShop.Areas.Admin.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Tên đăng nhập rỗng")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Mật khẩu rỗng")]
        public string Pasword { get; set; }
        public bool RememberMe { get; set; }
    }
}