using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.Objects
{
    [Serializable]
    public class Relation : Rectangle_Object
    {
        public Relation()
        {

        }
        public Relation(Point start, Point end)
        {
            this.Name = "Relation";
            this.Start = start;
            this.End = end;
            this.Selected = false;
            this.HierarchyID = new Guid[5];
            this.EventList = new List<Rectangle_Object>();
        }

        public Relation(bool moved, Point start, Point end)
        {
            this.Name = "Relation";
            this.Start = start;
            this.End = end;
            this.Moved = moved;
            this.EventList = new List<Rectangle_Object>();
            this.HierarchyID = new Guid[5];
        }

        public Relation (Point start, Point end, bool selected)
        {
            this.Name = "Relation";
            this.Start = start;
            this.End = end;
            this.Selected = selected;
            this.EventList = new List<Rectangle_Object>();
            this.HierarchyID = new Guid[5];
        }

        public Relation(Point start, Point end, bool selected, bool deleted)
        {
            this.Name = "Relation";
            this.Start = start;
            this.End = end;
            this.Selected = selected;
            this.Deleted = deleted;
            this.EventList = new List<Rectangle_Object>();
            this.HierarchyID = new Guid[5];
        }

        public Relation(Point start, Point end, bool selected, bool deleted, bool moved, Guid username, bool isUndo, bool isRedo) : this(start, end, selected, deleted)
        {
            this.Moved = moved;
            this.Username = username;
            this.IsRedo = isRedo;
            this.IsUndo = isUndo;
        }

        public override Point Center()
        {
            throw new NotImplementedException();
        }

        public override void Paint(Panel pnlCenter)
        {
            Graphics g = pnlCenter.CreateGraphics();
            g.DrawLine(new Pen(Brushes.Black), this.Start.X, this.Start.Y, this.End.X, this.End.Y);
        }

        public override bool IsSelected()
        {
            return this.Selected;
        }

        public override void Select(Panel pnlCenter)
        {
            Graphics g = pnlCenter.CreateGraphics();
            g.DrawLine(new Pen(Brushes.Yellow), this.Start.X, this.Start.Y, this.End.X, this.End.Y);
        }

        public override void Unselect(Panel pnlCenter)
        {
            Paint(pnlCenter);
        }

        public override void Delete(List<Rectangle_Object> events)
        {
            for (int i = events.Count - 1; i >= 0; i--)
            {
                if (events[i].Start == this.Start && events[i].End == this.End)
                {
                    events.Remove(events[i]);
                }
            }
        }
    }
}
