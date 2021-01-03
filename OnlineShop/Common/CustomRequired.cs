using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineShop.Common
{
    public class CustomRequired : RequiredAttribute
    {
        public override string FormatErrorMessage(string whatever)
        {
            return !String.IsNullOrEmpty(ErrorMessage)
                ? ErrorMessage
                : $"{whatever} không được để trống.";
        }
    }
}