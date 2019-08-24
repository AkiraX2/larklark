using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Anotar.NLog;
using CheetNET.Wpf;
using Common;
using FluentValidation;
using Stylet;
using StyletIoC;
using UI.Windows;
using 学比邻老师客户端.UI.Controls;
using 学比邻老师客户端.ViewModels.@base;

namespace 学比邻老师客户端.ViewModels
{
    public class ShellViewModel : BaseViewModel
    {
        [Inject] IWindowManager _WindowManager;

        [Inject] LoginViewModel _LoginViewModel;

        [Inject] LoginViewModel _LoginViewModel2;

        [Inject] MainViewModel _MainViewModel;





        public new string DisplayName
        {
            get => AppHelper.AppNameWithVersion;
        }


        public void OnBtnLogin()
        {
            this._WindowManager.ShowWindow(_LoginViewModel);
            //this._WindowManager.ShowWindow(_LoginViewModel2);
        }

        public void OnBtnRBCornerPopup()
        {
            this._WindowManager.ShowWindow(_LoginViewModel);
            //this._WindowManager.ShowWindow(_LoginViewModel2);
        }
        public void OnBtnMain()
        {
            this._WindowManager.ShowWindow(_MainViewModel);
            //this._WindowManager.ShowWindow(_LoginViewModel2);
        }

        public void OnBtnClassroom()
        {
            this._WindowManager.ShowWindow(_LoginViewModel);
            //this._WindowManager.ShowWindow(_LoginViewModel2);
        }

        public void OnBtnSettings()
        {
            this._WindowManager.ShowWindow(_LoginViewModel);
            //this._WindowManager.ShowWindow(_LoginViewModel2);
        }

        public bool IsLoading { get; set; } = false;

        public void OnBtnLoading()
        {
            IsLoading = true;
            Task.Delay(3000).ContinueWith((t) => { IsLoading = false; });
        }

        public void Login(object sender, EventArgs e)
        {
            var animBtn = sender as AnimatedButton;
            animBtn.IsLoading = true;
        }
    }


    public class ShellViewModelValidator : AbstractValidator<ShellViewModel>
    {
        public ShellViewModelValidator()
        {
            RuleFor(x => x.DisplayName).Equals("This is Sample.");
        }
    }
}


namespace 学比邻老师客户端.Views
{
    //public partial class ShellView : Window, IDragWindow
    //{
    //    public ShellView()
    //    {
    //        this.InitDragWindow();
    //    }

    //    public Window Window => this;


    //}
}