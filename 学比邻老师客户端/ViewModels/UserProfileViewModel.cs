using Stylet;
using StyletIoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 学比邻老师客户端.Services;
using 学比邻老师客户端.ViewModels.@base;

namespace 学比邻老师客户端.ViewModels
{
    public class UserProfileViewModel : BaseViewModel
    {
        public new string DisplayName => "我的";

        [Inject] UserService UserService;

        public UserProfile UserProfile { get; set; }


        private void DoLoad()
        {
            UserService.GetUserProfile("token").ContinueWith(res =>
           {
               var (code, data) = res.Result;

               if (code == 0)
               {
                   UserProfile = data;
               }
               else
               {
                   Execute.OnUIThread(() =>
                   {
 
                   });
               }
           });
        }

        protected override void OnViewLoaded()
        {
            base.OnViewLoaded();

            DoLoad();

        }

    }


    public class UserProfile: PropertyChangedBase
    {
        // 用户名
        public string Username { get; set; }

        // 邮箱
        public string Email { get; set; }
    }
}
