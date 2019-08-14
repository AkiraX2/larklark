using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StyletIoC;
using 学比邻老师客户端.ViewModels.@base;

namespace 学比邻老师客户端.ViewModels
{
    public class ClassTableViewModel: BaseViewModel
    {
        public new string DisplayName => "讲台";


        [Inject] public TimeTableViewModel TimeTableViewModel { get; set; }
    }
}
