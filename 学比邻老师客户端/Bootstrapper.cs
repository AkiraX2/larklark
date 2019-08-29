using System;
using System.Net.Http;
using System.Reflection;
using System.Windows;
using System.Windows.Threading;
using Anotar.NLog;
using Stylet;
using Stylet.Logging;
using StyletIoC;
using Common;
using FluentValidation;
using 学比邻老师客户端.ViewModels;
using System.Diagnostics;
using 学比邻老师客户端.ViewModels.@base;

namespace 学比邻老师客户端
{
    public class Bootstrapper : Bootstrapper<LoginViewModel>
    { 





        protected override void ConfigureIoC(IStyletIoCBuilder builder)
        {
            // Configure the IoC container in here
            builder.Bind(typeof(IModelValidator<>)).To(typeof(FluentModelValidator<>));
            builder.Bind(typeof(IValidator<>)).ToAllImplementations();
            builder.Bind<IViewModelsFactory>().ToAbstractFactory();
            builder.Bind<LoginViewModel>().ToSelf().InSingletonScope();
        }

        protected override void Configure()
        {
            // Perform any other configuration before the application starts
            LogManager.LoggerFactory = name => new MyStyletLogger(name); 
            LogManager.Enabled = true;
        }


        protected override void OnUnhandledException(DispatcherUnhandledExceptionEventArgs e)
        {

            base.OnUnhandledException(e);

            var message = e.Exception.Message;
            if (e.Exception is TargetInvocationException)
                message = e.Exception.InnerException.Message;

            LogTo.ErrorException(message, e.Exception);
            
            this.Container?.Get<IWindowManager>()?.ShowMessageBox($"{message}", caption: "Unhandled Exception", icon: MessageBoxImage.Error);
            e.Handled = true;
        }


        protected override void OnStart()
        {

            LogTo.Info("正在启动.");


            base.OnStart();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            LogTo.Info("正在退出.");
            base.OnExit(e);
        }


        [STAThread]
        public override void Start(string[] args)
        {
            //ConsoleManager.Initialize();
            ConsoleManagerEx.Toggle();
            base.Start(args);
        }
    }

}
