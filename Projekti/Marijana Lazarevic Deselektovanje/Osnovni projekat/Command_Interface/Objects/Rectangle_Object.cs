using System;
using System.Collections.Generic;
using System.Drawing;

namespace Client.Objects
{
    [Serializable]
    public abstract class Rectangle_Object
    {
        public string Name { get; set; }
        public Guid Username { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int MovingHelperX { get; set; }
        public int MovingHelperY { get; set; }
        public Guid[] HierarchyID { get; set; }
        public bool Selected { get; set; }
        public bool Deleted { get; set; }
        public bool Moved { get; set; }
        public Point Start { get; set; }
        public Point End { get; set; }
        public bool IsUndo { get; set; }
        public bool IsRedo { get; set; }
        public List<Rectangle_Object> EventList { get; set; }
        public abstract void Paint(System.Windows.Forms.Panel pnlCenter);
        public abstract void Delete(List<Rectangle_Object> events);
        public abstract Point Center();
        public abstract bool IsSelected();
        public abstract void Select(System.Windows.Forms.Panel pnlCenter);
        public abstract void Unselect(System.Windows.Forms.Panel pnlCenter);
    }
}
