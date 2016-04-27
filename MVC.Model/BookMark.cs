using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MVC.Model
{
    [Table("BookMark")]
    public class BookMark
    {
        [Key]
        public Guid BookMarkId { get; set; }

        [Required]
        [DisplayName("书名")]
        public string BookName { get; set; }

        [Required]
        [DisplayName("编号")]
        public string BookNo { get; set; }

        [DisplayName("价格")]
        public string BookPrice { get; set; }

        [DisplayName("入库时间")]
        public string BookInsertTime { get; set; }

        [DisplayName("数量")]
        public string BookNum { get; set; }
    }
}
