using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StyletIoC;
using 学比邻老师客户端.ViewModels.@base;

namespace 学比邻老师客户端.ViewModels
{
    public class MainViewModel : BaseWindowVM
    {
        public override string DisplayName => "乐比邻";

        protected override void OnViewLoaded()
        {
            base.OnViewLoaded();
            CurrentViewModel = ClassTableViewModel;
        }

        public BaseViewModel CurrentViewModel { get; set; }

        [Inject] private  UserProfileViewModel UserProfileViewModel { get; set; }

        [Inject] private ClassTableViewModel ClassTableViewModel { get; set; }



        public void OnClassTableBtn_Checked()
        {
            CurrentViewModel = ClassTableViewModel;

        }

        public void OnUserProfileBtn_Checked()
        {
            CurrentViewModel = UserProfileViewModel;

        }


    }
}
