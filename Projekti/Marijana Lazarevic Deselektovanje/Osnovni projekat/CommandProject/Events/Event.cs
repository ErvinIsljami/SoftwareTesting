using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Events
{
    [Serializable]
    public abstract class Event
    {
        public string eventName { get; set; }
        public Guid username { get; set; }
        public int x { get; set; }
        public int y { get; set; }
        public int movingHelperX { get; set; }
        public int movingHelperY { get; set; }
        public int[] hierarchyID { get; set; }
        public bool selected { get; set; }
        public bool deleted { get; set; }
        public bool moved { get; set; }
        public Point start { get; set; }
        public Point end { get; set; }
        public bool isUndo { get; set; }
        public List<Event> eventList { get; set; }
        public abstract void Paint(System.Windows.Forms.Panel pnlCenter);
        public abstract void Delete(List<Event> events);
        public abstract Point Center();
        public abstract bool isSelected();
        public abstract void Select(System.Windows.Forms.Panel pnlCenter);
        public abstract void Unselect(System.Windows.Forms.Panel pnlCenter);
    }
}
