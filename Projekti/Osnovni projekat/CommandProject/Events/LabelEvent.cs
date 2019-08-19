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
    public class LabelEvent : Event
    {
        public LabelEvent()
        {
        }

        public LabelEvent(int x, int y)
        {
            this.eventName = "Label";
            this.x = x;
            this.y = y;
            this.selected = selected;
            this.eventList = new List<Event>();
            this.hierarchyID = new int[5];
        }

        public LabelEvent(int x, int y, int movingHelperX, int movingHelperY)
        {
            this.eventName = "Label";
            this.x = x;
            this.y = y;
            this.movingHelperX = movingHelperX;
            this.movingHelperY = movingHelperY;
            this.selected = selected;
            this.eventList = new List<Event>();
            this.hierarchyID = new int[5];
        }

        public LabelEvent(int x, int y, bool selected)
        {
            this.eventName = "Label";
            this.x = x;
            this.y = y;
            this.selected = selected;
            this.eventList = new List<Event>();
            this.hierarchyID = new int[5];
        }

        public LabelEvent(bool moved, int x, int y)
        {
            this.eventName = "Label";
            this.x = x;
            this.y = y;
            this.moved = moved;
            this.eventList = new List<Event>();
            this.hierarchyID = new int[5];
        }

        public LabelEvent(int x, int y, bool selected, bool deleted)
        {
            this.eventName = "Label";
            this.x = x;
            this.y = y;
            this.selected = selected;
            this.deleted = deleted;
            this.eventList = new List<Event>();
            this.hierarchyID = new int[5];
        }

        public LabelEvent(int x, int y, bool selected, bool deleted, bool moved, Guid username, int movingHelperX, int movingHelperY)
        {
            this.eventName = "Label";
            this.x = x;
            this.y = y;
            this.selected = selected;
            this.deleted = deleted;
            this.moved = moved;
            this.username = username;
            this.movingHelperX = movingHelperX;
            this.movingHelperY = movingHelperY;
            this.eventList = new List<Event>();
            this.hierarchyID = new int[5];
        }

        public override Point Center()
        {
            return new Point((this.x + this.x + 150) / 2, (this.y + this.y + 70) / 2);
        }

        public override void Delete(List<Event> events)
        {

            for (int i = events.Count() - 1; i >= 0; i--)
            {
                if (events[i].x == this.x && events[i].y == this.y && events[i].eventName == this.eventName)
                {
                    events.Remove(events[i]);
                }
            }
        }

        public override bool isSelected()
        {
            return this.selected;
        }

        public override void Paint(Panel pnlCenter)
        {
            Graphics g = pnlCenter.CreateGraphics();
            g.FillRectangle(new SolidBrush(Color.LightBlue),
            new Rectangle(new Point(x, y), new
                Size(70, 15)));
        }

        public override void Select(Panel pnlCenter)
        {
            Graphics g = pnlCenter.CreateGraphics();
            g.FillRectangle(new SolidBrush(Color.LightSalmon),
            new Rectangle(new Point(x, y), new
                Size(70, 15)));
        }

        public override void Unselect(Panel pnlCenter)
        {
            Graphics g = pnlCenter.CreateGraphics();
            g.FillRectangle(new SolidBrush(Color.LightBlue),
            new Rectangle(new Point(x, y), new
                Size(70, 15)));
        }
    }
}
