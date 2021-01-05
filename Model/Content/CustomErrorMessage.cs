using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Content
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

    public class CustomMaxLength : StringLengthAttribute
    {
        public CustomMaxLength(int maximumLength) : base(maximumLength)
        {
        }

        public override string FormatErrorMessage(string name)
        {
            //return base.FormatErrorMessage(name);
            return !String.IsNullOrEmpty(ErrorMessage)
               ? ErrorMessage
               : $"{name} phải là không được dài quá {MaximumLength} ký tự.";
        }
    }
}