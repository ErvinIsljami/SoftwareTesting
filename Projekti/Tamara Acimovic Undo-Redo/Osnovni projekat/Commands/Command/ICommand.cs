using Client.Events;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Command
{
    public interface ICommand
    {
        string eventName { get; }
        Guid username { get; set; }
        Guid ID_Command { get; set; }
        int prevCommand { get; set; }
        int[] hierarchyID { get; set; }
        int x { get; }
        int y { get; }
        int movingHelperX { get; }
        int movingHelperY { get; }
        bool selected { get; }
        bool deleted { get; }
        bool moved { get; }
        Point start { get; }
        Point end { get; }
        List<Event> eventList { get; }
        bool isUndo { get; set; }
        bool isInverse { get; set; }
        bool isRedo { get; }

        void execute(Event e1);
        void unexecute(Event e1);
        string log();
    }
}
