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
    class CmdMoveEventTwo : ICommand
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

        public int oldX;
        public int oldY;
        public int newX;
        public int newY;

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
            this.x = e1.x;
            this.y = e1.y;
            this.selected = e1.selected;
            this.deleted = e1.deleted;
            this.moved = e1.moved;
            this.username = e1.username;
            this.movingHelperX = e1.movingHelperX;
            this.movingHelperY = e1.movingHelperY;
            this.isRedo = false;
            this.isUndo = false;

            int upperLeftX = e1.x;
            int upperLeftY = e1.y;

            int selectedX = Form1.selected[0].x;
            int selectedY = Form1.selected[0].y;

            newX = upperLeftX;
            newY = upperLeftY;

            oldX = selectedX;
            oldY = selectedY;

            for (int i = 0; i < Form1.events.Count(); i++)
            {
                if (Form1.selected[0] == Form1.events[i])
                {
                    Form1.events[i].x = upperLeftX;
                    Form1.events[i].y = upperLeftY;
                }
            }

            for (int i = 0; i < Form1.events.Count(); i++)
            {
                if (Form1.events[i].eventName == "Relation")
                {
                    if (Form1.events[i].eventList[0].x == selectedX && Form1.events[i].eventList[0].y == selectedY)
                    {
                        Point helper = Form1.events[i].eventList[1].Center();
                        Point start = Form1.getNearestPoint(Form1.selected[0], helper);
                        Point end = Form1.getNearestPoint(Form1.events[i].eventList[1], Form1.selected[0].Center());

                        Relation rel = new Relation(start, end);
                        rel.eventList.Add(Form1.events[i].eventList[1]);
                        if (Form1.selected[0].eventName == "Event One")
                        {
                            rel.eventList.Add(new Event_One(upperLeftX, upperLeftY));
                        }
                        else if (Form1.selected[0].eventName == "Event Two")
                        {
                            rel.eventList.Add(new Event_Two(upperLeftX, upperLeftY));
                        }

                        rel.hierarchyID = Form1.events[i].hierarchyID;
                        Form1.events.Remove(Form1.events[i]);
                        Form1.events.Add(rel);
                    }
                    else if (Form1.events[i].eventList[1].x == selectedX && Form1.events[i].eventList[1].y == selectedY)
                    {
                        Point helper = Form1.events[i].eventList[0].Center();
                        Point start = Form1.getNearestPoint(Form1.selected[0], helper);
                        Point end = Form1.getNearestPoint(Form1.events[i].eventList[0], Form1.selected[0].Center());

                        Relation rel = new Relation(start, end);
                        rel.eventList.Add(Form1.events[i].eventList[0]);
                        if (Form1.selected[0].eventName == "Event One")
                        {
                            rel.eventList.Add(new Event_One(upperLeftX, upperLeftY));
                        }
                        else if (Form1.selected[0].eventName == "Event Two")
                        {
                            rel.eventList.Add(new Event_Two(upperLeftX, upperLeftY));
                        }

                        rel.hierarchyID = Form1.events[i].hierarchyID;
                        Form1.events.Remove(Form1.events[i]);
                        Form1.events.Add(rel);
                    }
                }
            }

            Form1.pnlCenter.Refresh();
            for (int i = 0; i < Form1.events.Count(); i++)
            {
                Form1.events[i].moved = true;
                Form1.events[i].Paint(Form1.pnlCenter);
            }
        }

        public string log()
        {
            return "; move " + this.eventName + "; oldX=" + this.oldX + "; oldY=" + this.oldY
                + "; newX=" + this.newX + "; newY=" + this.newY;
        }

        public void unexecute(Event e1)
        {
            throw new NotImplementedException();
        }
    }
}
