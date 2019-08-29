using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Navigation;
using Anotar.NLog;
using CheetNET.Wpf;
using Common;
using FluentValidation;
using Stylet;
using StyletIoC;
using UI.Windows;
using 学比邻老师客户端.Services;
using 学比邻老师客户端.UI.Controls;
using 学比邻老师客户端.UI.Decorators;
using 学比邻老师客户端.ViewModels;
using 学比邻老师客户端.ViewModels.@base;

namespace 学比邻老师客户端.ViewModels
{
    /// <summary>
    /// 用户登录窗口的viewmodel类
    /// </summary>
    public class LoginViewModel : BaseWindowVM
    {
        #region 私有字段
        /// <summary>
        /// windowmanager接口对象
        /// </summary>
        [Inject] private IWindowManager WindowManager { get; set; }

        /// <summary>
        /// 密码输入框对象
        /// </summary>
        private WatermarkPasswordBox WatermarkPasswordBox { get; set; }

        /// <summary>
        /// 密码框是否已输入
        /// </summary>
        private bool HasPassword
        {
            get => WatermarkPasswordBox?.HasPassword ?? false;
        }

        /// <summary>
        /// 登录服务接口对象
        /// </summary>
        [Inject] private LoginService LoginService { get; set; }
        #endregion

        #region 公共属性
        /// <summary>
        /// 窗口标题
        /// </summary>
        public override string DisplayName => "登录乐比邻";

        /// <summary>
        /// 用户名
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// 是否正在登录
        /// </summary>
        public bool IsDoingLogin { get; set; } = false;

        /// <summary>
        /// 是否可登录
        /// </summary>
        public bool CanLogin
        {
            get => HasPassword && !string.IsNullOrWhiteSpace(Username);
        }

        /// <summary>
        /// 错误信息
        /// </summary>
        public string ErrorMessage { get; set; }
        #endregion

        #region 公共方法
        /// <summary>
        /// 构造方法
        /// </summary>
        public LoginViewModel()
        {
        }

        /// <summary>
        /// 密码输入框加载完成事件触发时
        /// </summary>
        /// <param name="sender">发起者</param>
        /// <param name="e">事件参数</param>
        public void PasswordBox_Loaded(object sender, EventArgs e)
        {
            WatermarkPasswordBox = sender as WatermarkPasswordBox;

            // 订阅密码改变事件
            if (WatermarkPasswordBox != null)
            {
                WatermarkPasswordBox.PasswordBox.PasswordChanged += LoginForm_Changed;
            }
        }

        /// <summary>
        /// 点击登录按钮时
        /// </summary>
        /// <param name="sender">发起者</param>
        /// <param name="e">事件参数</param>
        public void OnBtnLogin_Click(object sender, EventArgs e)
        {
            if (sender is AnimatedButton)
            {
                // 如果正在登录，返回
                if (IsDoingLogin == true)
                {
                    return;
                }

                // 重置相关参数
                ErrorMessage = null;
                IsDoingLogin = true;
                DoLogin();
            }
        }

        /// <summary>
        /// 账户文本框text改变时
        /// </summary>
        /// <param name="sender">发起者</param>
        /// <param name="e">事件参数</param>
        public void LoginForm_Changed(object sender, EventArgs e)
        {
            ErrorMessage = null;
            NotifyOfPropertyChange(() => this.CanLogin);
        }
        #endregion

        #region 内部方法
        /// <summary>
        /// 登录的具体步骤
        /// </summary>
        private void DoLogin()
        {
            var password = WatermarkPasswordBox?.PasswordBox?.Password;

            LoginService.DoLogin(Username, password).ContinueWith(res =>
            {
                var (code, msg) = res.Result;
                IsDoingLogin = false;

                if (code == 0)
                {
                    Execute.OnUIThread(() => { this.RequestClose(); });
                }
                else
                {
                    Execute.OnUIThread(() =>
                    {
                        this.ErrorMessage = $"{msg}({code})";
                    });
                }
            });
        }
        #endregion

        #region 内部类
        /// <summary>
        /// 本viewmodel的校验类
        /// </summary>
        public class LoginViewModelValidator : AbstractValidator<LoginViewModel>
        {
            public LoginViewModelValidator()
            {
                RuleFor(x => x.DisplayName).Equals("This is Sample.");
            }
        }
        #endregion
    }
}