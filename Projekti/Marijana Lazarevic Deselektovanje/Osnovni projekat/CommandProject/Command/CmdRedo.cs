using Client.Events;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Command
{
    [Serializable]
    class CmdRedo : ICommand
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

        bool ICommand.isRedo => this.isRedo;

        bool ICommand.isUndo { get => this.isUndo; set => this.isUndo = value; }

        Guid ICommand.username { get => this.username; set => this.username = value; }

        Guid ICommand.ID_Command { get => this.ID_Command; set => this.ID_Command = value; }

        int ICommand.prevCommand { get => this.prevCommand; set => this.prevCommand = value; }

        string ICommand.eventName => this.eventName;

        int ICommand.x => this.x;

        int ICommand.y => this.y;

        bool ICommand.selected => this.selected;

        bool ICommand.deleted => this.deleted;

        bool ICommand.moved => this.moved;

        Point ICommand.start => this.start;

        Point ICommand.end => this.end;

        List<Event> ICommand.eventList => this.eventList;

        int ICommand.movingHelperX => this.movingHelperX;

        int ICommand.movingHelperY => this.movingHelperY;

        public void execute(Event e1)
        {
            this.hierarchyID = new int[5];
            this.username = e1.username;
        }

        public string log()
        {
            throw new NotImplementedException();
        }

        public void unexecute(Event e1)
        {
            throw new NotImplementedException();
        }
    }
}
