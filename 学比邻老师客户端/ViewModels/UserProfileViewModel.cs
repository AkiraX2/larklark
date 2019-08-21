using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 学比邻老师客户端.ViewModels.@base;

namespace 学比邻老师客户端.ViewModels
{
    public class UserProfileViewModel : BaseViewModel
    {
        public new string DisplayName => "我的";
       
        // 用户名
        public string Username { get; set; }

        // 邮箱
        public string Email { get; set; }


    }
}
