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
    public class Label : Rectangle_Object
    {
        public Label()
        {
        }

        public Label(int x, int y)
        {
            this.Name = "Label";
            this.X = x;
            this.Y = y;
            this.Selected = false;
            this.EventList = new List<Rectangle_Object>();
            this.HierarchyID = new Guid[5];
        }

        public Label(int x, int y, int movingHelperX, int movingHelperY)
        {
            this.Name = "Label";
            this.X = x;
            this.Y = y;
            this.MovingHelperX = movingHelperX;
            this.MovingHelperY = movingHelperY;
            this.Selected = false;
            this.EventList = new List<Rectangle_Object>();
            this.HierarchyID = new Guid[5];
        }

        public Label(int x, int y, bool selected)
        {
            this.Name = "Label";
            this.X = x;
            this.Y = y;
            this.Selected = selected;
            this.EventList = new List<Rectangle_Object>();
            this.HierarchyID = new Guid[5];
        }

        public Label(bool moved, int x, int y)
        {
            this.Name = "Label";
            this.X = x;
            this.Y = y;
            this.Moved = moved;
            this.EventList = new List<Rectangle_Object>();
            this.HierarchyID = new Guid[5];
        }

        public Label(int x, int y, bool selected, bool deleted)
        {
            this.Name = "Label";
            this.X = x;
            this.Y = y;
            this.Selected = selected;
            this.Deleted = deleted;
            this.EventList = new List<Rectangle_Object>();
            this.HierarchyID = new Guid[5];
        }

        public Label(int x, int y, bool selected, bool deleted, bool moved, Guid username, int movingHelperX, int movingHelperY, bool isUndo, bool isRedo) : this(x, y, selected, deleted)
        {
            this.Moved = moved;
            this.Username = username;
            this.MovingHelperX = movingHelperX;
            this.MovingHelperY = movingHelperY;
            this.IsUndo = isUndo;
            this.IsRedo = isRedo;
        }

        public override Point Center()
        {
            return new Point((this.X + this.X + 150) / 2, (this.Y + this.Y + 70) / 2);
        }

        public override void Delete(List<Rectangle_Object> events)
        {

            for (int i = events.Count - 1; i >= 0; i--)
            {
                if (events[i].X == this.X && events[i].Y == this.Y && events[i].Name == this.Name)
                {
                    events.Remove(events[i]);
                }
            }
        }

        public override bool IsSelected()
        {
            return this.Selected;
        }

        public override void Paint(Panel pnlCenter)
        {
            Graphics g = pnlCenter.CreateGraphics();
            g.FillRectangle(new SolidBrush(Color.LightBlue),
            new Rectangle(new Point(X, Y), new
                Size(70, 15)));
        }

        public override void Select(Panel pnlCenter)
        {
            Graphics g = pnlCenter.CreateGraphics();
            g.FillRectangle(new SolidBrush(Color.LightSalmon),
            new Rectangle(new Point(X, Y), new
                Size(70, 15)));
        }

        public override void Unselect(Panel pnlCenter)
        {
            Paint(pnlCenter);
        }
    }
}
