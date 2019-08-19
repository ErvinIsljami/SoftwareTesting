﻿using Client.Events;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Command
{
    [Serializable]
    class CmdDeleteLabel : ICommand
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
        public int[] hierarchyID;

        int[] ICommand.hierarchyID { get => this.hierarchyID; set => this.hierarchyID = value; }

        int ICommand.movingHelperX => this.movingHelperX;

        int ICommand.movingHelperY => this.movingHelperY;

        public Guid username;
        public Guid ID_Command;
        public int prevCommand;
        public int undoCommand;
        public bool isUndo;
        public bool isRedo;
        public bool isInverse;

        bool ICommand.isInverse { get => this.isInverse; set => this.isInverse = value; }

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
            this.isRedo = false;
            this.isUndo = false;
            e1.Delete(Form1.events);

            Form1.pnlCenter.Refresh();
            for (int i = 0; i < Form1.events.Count(); i++)
            {
                Form1.events[i].Paint(Form1.pnlCenter);
            }
        }

        public string log()
        {
            return "; delete " + this.eventName + "; x=" + this.x + "; y=" + this.y;
        }

        public void unexecute(Event e1)
        {
            this.hierarchyID = new int[5];
            this.eventName = e1.eventName;
            this.username = e1.username;
            this.x = e1.x;
            this.y = e1.y;
            this.selected = e1.selected;
            this.deleted = e1.deleted;
            this.moved = e1.moved;
            this.isRedo = false;
            this.isUndo = true;
            e1.Paint(Form1.pnlCenter);
        }
    }
}
