using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StyletIoC;
using 学比邻老师客户端.ViewModels.@base;

namespace 学比邻老师客户端.ViewModels.ClassRoom
{
    public class ClassRoomMainViewModel : BaseWindowVM
    {
        public override string DisplayName => "课堂";

        [Inject] private ClassRoomHeaderViewModel ClassRoomHeaderViewModel { get; set; }

        [Inject] private ClassRoomToolbarViewModel ClassRoomToolbarViewModel { get; set; }
    }
}
