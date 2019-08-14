using System.Windows;

namespace 学比邻老师客户端.ViewModels.@base
{
    public abstract class BaseWindowVM : BaseViewModel
    {
        public WindowState WindowState { get; set; }

        public new abstract string DisplayName { get; }


        public void OnWCBtnMinimize() => WindowState = WindowState.Minimized;

        public void OnWCBtnMaximize() => WindowState = WindowState.Maximized;


        public void OnWCBtnClose() => RequestClose();
    }
}