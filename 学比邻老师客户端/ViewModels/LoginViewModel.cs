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
    public class LoginViewModel : BaseWindowVM
    {
        public LoginViewModel()
        {
        }

        [Inject] private IWindowManager WindowManager { get; set; }

        public override string DisplayName => "登录乐比邻";

        private WatermarkPasswordBox WatermarkPasswordBox { get; set; }

        private bool HasPassword
        {
            get => WatermarkPasswordBox?.HasPassword ?? false;
        }


        public string Username { get; set; }


        public void LoginForm_Changed(object sender, EventArgs e)
        {
            ErrorMessage = null;
            NotifyOfPropertyChange(() => this.CanLogin);
        }

        public void PasswordBox_Loaded(object sender, EventArgs e)
        {
            WatermarkPasswordBox = sender as WatermarkPasswordBox;
            if (WatermarkPasswordBox != null) WatermarkPasswordBox.PasswordBox.PasswordChanged += LoginForm_Changed;
        }


        public bool CanLogin
        {
            get => HasPassword && !string.IsNullOrWhiteSpace(Username);
        }

        public bool IsDoingLogin { get; set; } = false;

        [Inject] private LoginService LoginService { get; set; }

        public void OnBtnLogin_Click(object sender, EventArgs e)
        {
            if (sender is AnimatedButton btnLogin)
            {
                if (IsDoingLogin)
                {
                    return;
                }
                ErrorMessage = null;
                IsDoingLogin = true; 
                DoLogin();
            }
        }

        public string ErrorMessage { get; set; }


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
    }


    public class LoginViewModelValidator : AbstractValidator<LoginViewModel>
    {
        public LoginViewModelValidator()
        {
            RuleFor(x => x.DisplayName).Equals("This is Sample.");
        }
    }
}

namespace 学比邻老师客户端.Views
{
    //public partial class LoginView : AbstractMixinWindow
    //{
    //    public override DoubleAnimation CloseAnimation { get; set; } = new DoubleAnimation
    //    {
    //        From = 1,
    //        To = 0,
    //        Duration = TimeSpan.FromSeconds(0.6),
    //        EasingFunction = new BackEase() { EasingMode = EasingMode.EaseInOut }
    //    };

    //    public override event EventHandler CloseAnimationCompleted;

    //    public override void Anim_Closing()
    //    {
    //        CloseAnimation.Completed += CloseAnimationCompleted;

    //        mScaleTransform.BeginAnimation(ScaleTransform.ScaleXProperty, CloseAnimation.Clone());
    //        mScaleTransform.BeginAnimation(ScaleTransform.ScaleYProperty, CloseAnimation.Clone());
    //        Window.BeginAnimation(Window.OpacityProperty, CloseAnimation);


    //    }

    //}
}