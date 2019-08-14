using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using Stylet;
using 学比邻老师客户端.ViewModels.@base;

namespace 学比邻老师客户端.ViewModels
{
    public class TimeTableViewModel : BaseViewModel
    {
        public new string DisplayName => "课程表";

        public BindableCollection<DayCell> DayCells { get; set; } = new BindableCollection<DayCell>();
        public BindableCollection<DateCell> DateCells { get; set; } = new BindableCollection<DateCell>();

        public TimeTableViewModel()
        {
            DayCells.Add(new DayCell("上午", 0));
            DayCells.Add(new DayCell("下午", 1));
            DayCells.Add(new DayCell("晚上", 2));

            var today = DateTime.Today;

            var d = today - TimeSpan.FromDays(1);
            //if(d.DayOfWeek == )
            //d.DayOfWeek

            //DateCells.Add(new DateCell());
        }
    }


    public abstract class GridDataCell
    {
        public GridDataCell(int rowIndex, int columnIndex)
        {
            RowIndex = rowIndex;
            ColumnIndex = columnIndex;
        }

        public int RowIndex { get; set; } = 0;
        public int RowSpan { get; set; } = 1;
        public int ColumnIndex { get; set; } = 0;
        public int ColumnSpan { get; set; } = 1;
    }

    public class ClassCell : GridDataCell
    {
        public string ClassName { get; set; }


        public ClassCell(string className, int rowIndex = default, int columnIndex = default) : base(rowIndex, columnIndex)
        {
            ClassName = className;
        }
    }



    public class DateCell : GridDataCell
    {
        public DateCell(string weekday, string date, int rowIndex, int columnIndex) : base(rowIndex, columnIndex)
        {
            Weekday = weekday;
            Date = date;
        }

        public string Weekday { get; set; }
        public string Date { get; set; }

         
    }


    public class DayCell : GridDataCell
    {
        public DayCell(string name, int rowIndex = 0, int columnIndex = 0) : base(rowIndex, columnIndex)
        {
            Name = name;
        }

        public string Name { get; set; }
    }
}