using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace MVC.Framework
{
    public class MobileAttribute : RegularExpressionAttribute
    {
        public MobileAttribute()
            : base(@"^(13[0-9]|15[012356789]|17[0678]|18[0-9]|14[57])[0-9]{8}$")
        {
        }
    }
}
