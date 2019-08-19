using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.Objects;

namespace Client.Command
{
    class CmdSelectLabel : Command_Interface.ICommand
    {
        public string eventName;
        public int x;
        public int y;
        public bool selected;
        public bool deleted;
        public bool moved;
        public Point start = new Point();
        public Point end = new Point();
        public List<Objects.Rectangle_Object> eventList;
        public int movingHelperX = 0;
        public int movingHelperY = 0;

        public Guid username;
        public Guid ID_Command;
        public int prevCommand = -1;
        public int undoCommand = -1;
        public bool isUndo = false;
        public bool isRedo = false;
        public Guid[] hierarchyID;
        public bool isInverse = false;
        public bool isLargeRepair = false;

        bool Command_Interface.ICommand.IsLargeRepair => this.isLargeRepair;

        bool Command_Interface.ICommand.IsInverse { get; set; }

        Guid[] Command_Interface.ICommand.HierarchyID { get => this.hierarchyID; set => this.hierarchyID = value; }

        bool Command_Interface.ICommand.IsRedo { get; set; }

        bool Command_Interface.ICommand.IsUndo { get; set; }

        Guid Command_Interface.ICommand.Username { get => this.username; set => this.username = value; }

        Guid Command_Interface.ICommand.ID_Command { get; set; }

        int Command_Interface.ICommand.PrevCommand { get; set; }

        int Command_Interface.ICommand.MovingHelperX => this.movingHelperX;

        int Command_Interface.ICommand.MovingHelperY => this.movingHelperY;

        string Command_Interface.ICommand.EventName => this.eventName;

        int Command_Interface.ICommand.X => this.x;

        int Command_Interface.ICommand.Y => this.y;

        bool Command_Interface.ICommand.Selected => this.selected;

        bool Command_Interface.ICommand.Deleted => this.deleted;

        bool Command_Interface.ICommand.Moved => this.moved;

        Point Command_Interface.ICommand.Start => this.start;

        Point Command_Interface.ICommand.End => this.end;

        List<Objects.Rectangle_Object> Command_Interface.ICommand.EventList { get => eventList; set => eventList = value; }

        public void Execute(Objects.Rectangle_Object e1)
        {
            this.hierarchyID = new Guid[5];
            this.eventName = e1.Name;
            this.x = e1.X;
            this.y = e1.Y;
            this.selected = e1.Selected;
            this.deleted = e1.Deleted;
            this.moved = e1.Moved;
            this.username = e1.Username;
            e1.Select(Canvas.pnlCenter);
        }

        public string Log()
        {
            throw new NotImplementedException();
        }

        public void Unexecute(Objects.Rectangle_Object e1)
        {
            throw new NotImplementedException();
        }
    }
}
