using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.Objects;

namespace Client.Command
{
    [Serializable]
    class CmdMoveRectangleBlue : Command_Interface.ICommand
    {
        public string eventName;
        public int x;
        public int y;
        public bool selected;
        public bool deleted;
        public bool moved;
        public int movingHelperX;
        public int movingHelperY;
        public Point start = new Point();
        public Point end = new Point();
        public List<Objects.Rectangle_Object> eventList;

        public int oldX;
        public int oldY;
        public int newX;
        public int newY;

        string Command_Interface.ICommand.EventName => this.eventName;

        public Guid username;
        public Guid ID_Command;
        public int prevCommand = -1;
        public int undoCommand = -1;
        public bool isUndo;
        public bool isRedo;
        public Guid[] hierarchyID;
        public bool isInverse = false;
        public bool isLargeRepair = false;

        bool Command_Interface.ICommand.IsLargeRepair => this.isLargeRepair;

        bool Command_Interface.ICommand.IsInverse { get; set; }

        Guid[] Command_Interface.ICommand.HierarchyID { get => this.hierarchyID; set => this.hierarchyID = value; }

        bool Command_Interface.ICommand.IsUndo { get; set; }

        Guid Command_Interface.ICommand.Username { get => this.username; set => this.username = value; }

        Guid Command_Interface.ICommand.ID_Command { get; set; }

        int Command_Interface.ICommand.PrevCommand { get; set; }

        bool Command_Interface.ICommand.IsRedo { get; set; }

        int Command_Interface.ICommand.X => this.x;

        int Command_Interface.ICommand.Y => this.y;

        bool Command_Interface.ICommand.Selected => this.selected;

        bool Command_Interface.ICommand.Deleted => this.deleted;

        bool Command_Interface.ICommand.Moved => this.moved;

        Point Command_Interface.ICommand.Start => this.start;

        Point Command_Interface.ICommand.End => this.end;

        List<Objects.Rectangle_Object> Command_Interface.ICommand.EventList { get => eventList; set => eventList = value; }

        int Command_Interface.ICommand.MovingHelperX => this.movingHelperX;

        int Command_Interface.ICommand.MovingHelperY => this.movingHelperY;

        public static readonly Guid canvas = new Guid("5C60F693-BEF5-E011-A485-80EE7300C695");

        public void Execute(Objects.Rectangle_Object e1)
        {
            this.hierarchyID = new Guid[5];
            this.eventName = e1.Name;
            this.x = e1.X;
            this.y = e1.Y;
            this.selected = e1.Selected;
            this.deleted = e1.Deleted;
            this.moved = e1.Moved;
            this.username = e1.Username;
            this.movingHelperX = e1.MovingHelperX;
            this.movingHelperY = e1.MovingHelperY;
            this.isRedo = false;
            this.isUndo = false;
            this.eventList = e1.EventList;
            this.hierarchyID = e1.HierarchyID;

            int upperLeftX = e1.X;
            int upperLeftY = e1.Y;

            int selectedX = e1.MovingHelperX;
            int selectedY = e1.MovingHelperY;

            newX = upperLeftX;
            newY = upperLeftY;

            oldX = selectedX;
            oldY = selectedY;

            for (int i = 0; i < Canvas.Objects.Count; i++)
            {
                if (e1.MovingHelperX == Canvas.Objects[i].X && e1.MovingHelperY == Canvas.Objects[i].Y)
                {
                    Canvas.Objects[i].X = upperLeftX;
                    Canvas.Objects[i].Y = upperLeftY;
                    Canvas.Objects[i].HierarchyID = e1.HierarchyID;

                    if (Canvas.Objects[i].EventList.Count == 1)
                    {
                        Canvas.Objects[i].EventList[0].Delete(Canvas.Objects);
                        Label labelEvent = new Label(upperLeftX + 20, upperLeftY + 10);
                        labelEvent.EventList.Add(e1);
                        labelEvent.Username = username;
                        labelEvent.HierarchyID[0] = canvas;
                        labelEvent.HierarchyID[1] = labelEvent.EventList[0].HierarchyID[1];
                        labelEvent.HierarchyID[2] = Guid.NewGuid();
                        Canvas.Objects[i].EventList.Add(labelEvent);
                        Canvas.Objects.Add(labelEvent);
                    }
                    else if (Canvas.Objects[i].EventList.Count == 2)
                    {
                        Canvas.Objects[i].EventList[0].Delete(Canvas.Objects);
                        Label labelEvent = new Label(upperLeftX + 20, upperLeftY + 10);
                        labelEvent.EventList.Add(e1);
                        labelEvent.Username = username;
                        labelEvent.HierarchyID[0] = canvas;
                        labelEvent.HierarchyID[1] = labelEvent.EventList[0].HierarchyID[1];
                        labelEvent.HierarchyID[2] = Guid.NewGuid();
                        Canvas.Objects[i].EventList.Add(labelEvent);
                        Canvas.Objects.Add(labelEvent);

                        Canvas.Objects[i].EventList[1].Delete(Canvas.Objects);
                        Label labelEvent1 = new Label(upperLeftX + 20, upperLeftY + 30);
                        labelEvent1.EventList.Add(e1);
                        labelEvent1.Username = username;
                        labelEvent1.HierarchyID[0] = canvas;
                        labelEvent1.HierarchyID[1] = labelEvent.EventList[0].HierarchyID[1];
                        labelEvent1.HierarchyID[2] = Guid.NewGuid();
                        Canvas.Objects[i].EventList.Add(labelEvent);
                        Canvas.Objects.Add(labelEvent1);
                    }
                    else if (e1.EventList.Count == 3)
                    {
                        Canvas.Objects[i].EventList[0].Delete(Canvas.Objects);
                        Label labelEvent = new Label(upperLeftX + 20, upperLeftY + 10);
                        labelEvent.EventList.Add(e1);
                        labelEvent.Username = username;
                        labelEvent.HierarchyID[0] = canvas;
                        labelEvent.HierarchyID[1] = labelEvent.EventList[0].HierarchyID[1];
                        labelEvent.HierarchyID[2] = Guid.NewGuid();
                        Canvas.Objects[i].EventList.Add(labelEvent);
                        Canvas.Objects.Add(labelEvent);

                        Canvas.Objects[i].EventList[1].Delete(Canvas.Objects);
                        Label labelEvent1 = new Label(upperLeftX + 20, upperLeftY + 30);
                        labelEvent1.EventList.Add(e1);
                        labelEvent1.Username = username;
                        labelEvent1.HierarchyID[0] = canvas;
                        labelEvent1.HierarchyID[1] = labelEvent1.EventList[0].HierarchyID[1];
                        labelEvent1.HierarchyID[2] = Guid.NewGuid();
                        Canvas.Objects[i].EventList.Add(labelEvent1);
                        Canvas.Objects.Add(labelEvent1);

                        Canvas.Objects[i].EventList[2].Delete(Canvas.Objects);
                        Label labelEvent2 = new Label(upperLeftX + 20, upperLeftY + 50);
                        labelEvent2.EventList.Add(e1);
                        labelEvent2.Username = username;
                        labelEvent2.HierarchyID[0] = canvas;
                        labelEvent2.HierarchyID[1] = labelEvent2.EventList[0].HierarchyID[1];
                        labelEvent2.HierarchyID[2] = Guid.NewGuid();
                        Canvas.Objects[i].EventList.Add(labelEvent2);
                        Canvas.Objects.Add(labelEvent2);
                    }
                }
            }

            for (int i = 0; i < Canvas.Objects.Count; i++)
            {
                if (Canvas.Objects[i].Name == "Relation")
                {
                    if (Canvas.Objects[i].EventList[0].X == selectedX && Canvas.Objects[i].EventList[0].Y == selectedY)
                    {
                        Point helper = Canvas.Objects[i].EventList[1].Center();
                        Point start_pt = Canvas.GetNearestPoint(Canvas.Selected[0], helper);
                        Point end_pt = Canvas.GetNearestPoint(Canvas.Objects[i].EventList[1], Canvas.Selected[0].Center());

                        Relation rel = new Relation(start_pt, end_pt);
                        rel.EventList.Add(Canvas.Objects[i].EventList[1]);
                        if (Canvas.Selected[0].Name == "Rectangle Red")
                        {
                            rel.EventList.Add(new RectangleRed(upperLeftX, upperLeftY));
                        }
                        else if (Canvas.Selected[0].Name == "Rectangle Blue")
                        {
                            rel.EventList.Add(new RectangleBlue(upperLeftX, upperLeftY));
                        }

                        rel.HierarchyID = Canvas.Objects[i].HierarchyID;
                        Canvas.Objects.Remove(Canvas.Objects[i]);
                        Canvas.Objects.Add(rel);
                    }
                    else if (Canvas.Objects[i].EventList[1].X == selectedX && Canvas.Objects[i].EventList[1].Y == selectedY)
                    {
                        Point helper = Canvas.Objects[i].EventList[0].Center();
                        Point start_pt = Canvas.GetNearestPoint(Canvas.Selected[0], helper);
                        Point end_pt = Canvas.GetNearestPoint(Canvas.Objects[i].EventList[0], Canvas.Selected[0].Center());

                        Relation rel = new Relation(start_pt, end_pt);
                        rel.EventList.Add(Canvas.Objects[i].EventList[0]);
                        if (Canvas.Selected[0].Name == "Rectangle Red")
                        {
                            rel.EventList.Add(new RectangleRed(upperLeftX, upperLeftY));
                        }
                        else if (Canvas.Selected[0].Name == "Rectangle Blue")
                        {
                            rel.EventList.Add(new RectangleBlue(upperLeftX, upperLeftY));
                        }
                        rel.HierarchyID = Canvas.Objects[i].HierarchyID;
                        Canvas.Objects.Remove(Canvas.Objects[i]);
                        Canvas.Objects.Add(rel);
                    }
                }
            }

            Canvas.pnlCenter.Refresh();
            for (int i = 0; i < Canvas.Objects.Count; i++)
            {
                Canvas.Objects[i].Moved = true;
                Canvas.Objects[i].Paint(Canvas.pnlCenter);
            }
        }

        public string Log()
        {
            return "; Move " + this.eventName + "; oldX=" + this.oldX + "; oldY=" + this.oldY
                + "; newX=" + this.newX + "; newY=" + this.newY;
        }

        public void Unexecute(Objects.Rectangle_Object e1)
        {
            throw new NotImplementedException();
        }
    }
}
