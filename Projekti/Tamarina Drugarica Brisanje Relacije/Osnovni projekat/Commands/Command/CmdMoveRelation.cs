using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.Events;

namespace Client.Command
{
    [Serializable]
    class CmdMoveRelation : ICommand
    {
        public string eventName;
        public int x;
        public int y;
        public bool selected;
        public bool deleted;
        public bool moved;
        public Point start;
        public Point end;
        public List<Event> eventList;
        public int movingHelperX;
        public int movingHelperY;

        int ICommand.movingHelperX => this.movingHelperX;

        int ICommand.movingHelperY => this.movingHelperY;

        public int startOldX;
        public int startOldY;
        public int endOldX;
        public int endOldY;
        public int startNewX;
        public int startNewY;
        public int endNewX;
        public int endNewY;

        public Guid username;
        public Guid ID_Command;
        public int prevCommand;
        public int undoCommand;
        public bool isUndo;
        public bool isRedo;
        public int[] hierarchyID;
        public bool isInverse;

        bool ICommand.isInverse { get => this.isInverse; set => this.isInverse = value; }

        int[] ICommand.hierarchyID { get => this.hierarchyID; set => this.hierarchyID = value; }

        bool ICommand.isUndo { get => this.isUndo; set => this.isUndo = value; }

        Guid ICommand.username { get => this.username; set => this.username = value; }

        Guid ICommand.ID_Command { get => this.ID_Command; set => this.ID_Command = value; }

        int ICommand.prevCommand { get => this.prevCommand; set => this.prevCommand = value; }

        bool ICommand.isRedo => this.isRedo;

        string ICommand.eventName => this.eventName;

        int ICommand.x => this.x;

        int ICommand.y => this.y;

        bool ICommand.selected => this.selected;

        bool ICommand.deleted => this.deleted;

        bool ICommand.moved => this.moved;

        Point ICommand.start => this.start;

        Point ICommand.end => this.end;

        List<Event> ICommand.eventList => this.eventList;

        public void execute(Event e1)
        {
            this.hierarchyID = new int[5];
            this.eventName = e1.eventName;
            this.start = e1.start;
            this.end = e1.end;
            this.selected = e1.selected;
            this.deleted = e1.deleted;
            this.moved = e1.moved;
            this.eventList = new List<Event>();
            this.username = e1.username;
            this.isRedo = false;
            this.isUndo = false;

            Form1.pnlCenter.Refresh();
            for (int i = 0; i < Form1.events.Count(); i++)
            {
                Form1.events[i].Paint(Form1.pnlCenter);
            }
        }

        public string log()
        {
            return "; move " + this.eventName + "; startNewX=" + this.eventList[0].x + "; startNewY=" + this.eventList[0].y
                + "; endNewX=" + this.eventList[1].x + "; endNewY=" + this.eventList[1].y;
        }

        public void unexecute(Event e1)
        {
            throw new NotImplementedException();
        }
    }
}
