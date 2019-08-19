using Client.Objects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command_Interface
{
    public interface ICommand
    {
        string EventName { get; }
        Guid Username { get; set; }
        Guid ID_Command { get; set; }
        int PrevCommand { get; set; }
        Guid[] HierarchyID { get; set; }
        int X { get; }
        int Y { get; }
        int MovingHelperX { get; }
        int MovingHelperY { get; }
        bool Selected { get; }
        bool Deleted { get; }
        bool Moved { get; }
        Point Start { get; }
        Point End { get; }
        List<Rectangle_Object> EventList { get; set; }
        bool IsUndo { get; set; }
        bool IsInverse { get; set; }
        bool IsRedo { get; set; }
        bool IsLargeRepair { get; }

        void Execute(Rectangle_Object e1);
        void Unexecute(Rectangle_Object e1);
        string Log();
    }
}
