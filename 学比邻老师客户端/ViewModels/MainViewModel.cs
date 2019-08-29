using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StyletIoC;
using 学比邻老师客户端.ViewModels.@base;

namespace 学比邻老师客户端.ViewModels
{
    /// <summary>
    /// 主界面viewmodel类
    /// </summary>
    public class MainViewModel : BaseWindowVM
    {
        #region 私有字段
        /// <summary>
        /// 用户头像viewmodel对象
        /// </summary>
        [Inject] private UserProfileViewModel UserProfileViewModel { get; set; }

        /// <summary>
        /// 讲台viewmodel对象
        /// </summary>
        [Inject] private ClassTableViewModel ClassTableViewModel { get; set; }
        #endregion

        #region 公共属性
        /// <summary>
        /// 窗口标题
        /// </summary>
        public override string DisplayName => "乐比邻";

        /// <summary>
        /// 当前显示区域视图对象
        /// </summary>
        public BaseViewModel CurrentViewModel { get; set; }
        #endregion

        #region 公共方法
        /// <summary>
        /// 选择“讲台”视图时
        /// </summary>
        public void OnClassTableBtn_Checked()
        {
            CurrentViewModel = ClassTableViewModel;
        }

        /// <summary>
        /// 选择“我的”视图时
        /// </summary>
        public void OnUserProfileBtn_Checked()
        {
            CurrentViewModel = UserProfileViewModel;
        }

        /// <summary>
        /// view关联到viewmodel时，即初始状态
        /// </summary>
        protected override void OnViewLoaded()
        {
            base.OnViewLoaded();

            // 初始为“讲台”视图
            CurrentViewModel = ClassTableViewModel;
        }
        #endregion
    }
}
