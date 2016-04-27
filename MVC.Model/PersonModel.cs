using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MVC.Framework;

namespace MVC.Model
{
    [Table("PersonInfo")]
    public class PersonModel
    {
        [Key]
        [DisplayName("用户唯一ID")]
        public Guid PersonModelId { get; set; }

        [Required]
        [DisplayName("用户名")]
        [StringLength(255, ErrorMessage = "用户名为必填项")]
        public string UserName { get; set; }

        [Required]
        [StringLength(16)]
        [DisplayName("用户密码")]
        public string UserPwd { get; set; }

        [Email]
        [Required]
        [DisplayName("用户邮箱")]
        public string UserEMail { get; set; }

        [Mobile]
        [Required]
        [StringLength(11, ErrorMessage = "手机号码长度错误")]
        [DisplayName("手机号码")]
        public string MobilePhone { get; set; }

        [DisplayName("添加时间")]
        public DateTime InserTime { get; set; }

        [DisplayName("是否非物理删除")]
        public bool IsRemove { get; set; }
    }
}