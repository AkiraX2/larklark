using System.Windows.Input;
using Anotar.NLog;
using CheetNET.Wpf;
using Common;
using Stylet;

namespace 学比邻老师客户端.ViewModels.@base
{
    public abstract class BaseViewModel : Screen
    {

#if DEBUG
        protected Cheet Cheat { get; set; }


        public void OnKeyDown(object sender, KeyEventArgs e)
        { 
            Cheat.OnKeyDown(sender, e); 
        }
         
        public BaseViewModel()
        {
 
            Cheat = new Cheet();
            Cheat.Map(@"↑ ↓ ← →", () =>
            {

                ConsoleManagerEx.Toggle();
                LogTo.Info("Cheet!");
            });

        }
#endif

    }
}
