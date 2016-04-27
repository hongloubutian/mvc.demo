using System.ComponentModel.DataAnnotations;
namespace MVC.Framework
{
    public class EmailAttribute : RegularExpressionAttribute
    {
        public EmailAttribute()
            : base(@"^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$")
        {
        }
    }
}