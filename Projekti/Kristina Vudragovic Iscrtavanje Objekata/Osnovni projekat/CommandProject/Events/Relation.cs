using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.Events
{
    [Serializable]
    class Relation : Event
    {
        public Relation()
        {

        }
        public Relation(Point start, Point end)
        {
            this.eventName = "Relation";
            this.start = start;
            this.end = end;
            this.selected = false;
            this.hierarchyID = new int[5];
            this.eventList = new List<Event>();
        }

        public Relation(bool moved, Point start, Point end)
        {
            this.eventName = "Relation";
            this.start = start;
            this.end = end;
            this.moved = moved;
            this.eventList = new List<Event>();
            this.hierarchyID = new int[5];
        }

        public Relation (Point start, Point end, bool selected)
        {
            this.eventName = "Relation";
            this.start = start;
            this.end = end;
            this.selected = selected;
            this.eventList = new List<Event>();
            this.hierarchyID = new int[5];
        }

        public Relation(Point start, Point end, bool selected, bool deleted)
        {
            this.eventName = "Relation";
            this.start = start;
            this.end = end;
            this.selected = selected;
            this.deleted = deleted;
            this.eventList = new List<Event>();
            this.hierarchyID = new int[5];
        }

        public Relation(Point start, Point end, bool selected, bool deleted, bool moved, Guid username)
        {
            this.eventName = "Relation";
            this.start = start;
            this.end = end;
            this.selected = selected;
            this.deleted = deleted;
            this.eventList = new List<Event>();
            this.moved = moved;
            this.username = username;
            this.hierarchyID = new int[5];
        }

        public override Point Center()
        {
            throw new NotImplementedException();
        }

        public override void Paint(Panel pnlCenter)
        {
            Graphics g = pnlCenter.CreateGraphics();
            g.DrawLine(new Pen(Brushes.Black), this.start.X, this.start.Y, this.end.X, this.end.Y);
        }

        public override bool isSelected()
        {
            return this.selected;
        }

        public override void Select(Panel pnlCenter)
        {
            Graphics g = pnlCenter.CreateGraphics();
            g.DrawLine(new Pen(Brushes.Yellow), this.start.X, this.start.Y, this.end.X, this.end.Y);
        }

        public override void Unselect(Panel pnlCenter)
        {
            Graphics g = pnlCenter.CreateGraphics();
            g.DrawLine(new Pen(Brushes.Black), this.start.X, this.start.Y, this.end.X, this.end.Y);
        }

        public override void Delete(List<Event> events)
        {
            for (int i = events.Count() - 1; i >= 0; i--)
            {
                if (events[i].start == this.start && events[i].end == this.end)
                {
                    events.Remove(events[i]);
                }
            }
        }
    }
}
