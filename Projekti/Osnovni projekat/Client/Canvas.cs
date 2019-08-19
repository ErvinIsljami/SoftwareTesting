using Client.Command;
using Client.Objects;
using Client.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    [Serializable]
    public partial class Canvas : Form
    {
        private static readonly Guid Canvas_ID = new Guid("5C60F693-BEF5-E011-A485-80EE7300C695");

        private bool IsChecked_btnRectRed = false;
        private bool IsChecked_btnRectBlue = false;
        private bool IsChecked_btnSelect = true;

        private Command_Interface.ICommand Rect;
        private RectangleRed Rect_Red;
        private RectangleBlue Rect_Blue;
        private Relation Rel;
        private Objects.Label Lab;
        private Undo_Redo.UndoRedoManager Manager = new Undo_Redo.UndoRedoManager();
        private Undo_Redo.UndoRedoWrapper Command_manager;
        private Undo_Redo.UndoRedoWrapper Inverse_command;
        private Undo_Redo.UndoRedoWrapper Redo_command;
        private Undo_Redo.UndoRedoWrapper Undo_command;

        public static readonly List<Objects.Rectangle_Object> Selected = new List<Objects.Rectangle_Object>();
        public static readonly List<Objects.Rectangle_Object> Objects = new List<Objects.Rectangle_Object>();

        private delegate void DeleteRectangleRed(RectangleRed e1);
        private delegate void DeleteRectangleBlue(RectangleBlue e1);
        private delegate void MoveRectanglRed(RectangleRed e1);
        private delegate void MoveRectangleBlue(RectangleBlue e1);
        private delegate void DeleteRelation(Relation rel);
        private delegate void MoveRelation(Relation rel);
        private delegate void DeleteLabel(Objects.Label label);
        private delegate void DeleteRectangleRed_Inverse(RectangleRed e1);
        private delegate void DeleteRectangleBlue_Inverse(RectangleBlue e1);
        private delegate void DeleteRelation_Inverse(Relation rel);
        private delegate void DeleteLabel_Inverse(Objects.Label e1);
        private delegate void DrawRectangleRed_Inverse(RectangleRed e1);
        private delegate void DrawRectangleBlue_Inverse(RectangleBlue e1);
        private delegate void DrawRelation_Inverse(Relation e1);
        private delegate void DrawLabel_Inverse(Objects.Label e1);
        private int Counter = 0;

        private static TcpClient ClientSocket = new TcpClient();
        static NetworkStream ServerStream = default(NetworkStream);
        private NetworkStream ServerStream_priv = default(NetworkStream);
        private static Guid Username = Guid.NewGuid();

        public Canvas()
        {
            InitializeComponent();
            ClientSocket.Connect("127.0.0.1", 1000);
            ServerStream_priv = ClientSocket.GetStream();

            User user = new User(Username);
            Manager.Instance_id = Username;

            btnRedo.Enabled = false;

            byte[] outStream = Encoding.ASCII.GetBytes(user.Username1 + "$");

            ServerStream_priv.Write(outStream, 0, outStream.Length);
            ServerStream_priv.Flush();

            Thread ctThread = new Thread(GetContent);
            ctThread.Start();

        }


        private void GetContent()
        {
            while (true)
            {
                ServerStream_priv = ClientSocket.GetStream();
                byte[] inStream = new byte[10025];
                int n = 0;
                n = ServerStream_priv.Read(inStream, 0, 10025);

                if (n != 0)
                {
                    byte[] data = inStream;
                    BinaryFormatter bf = new BinaryFormatter();
                    using (MemoryStream ms = new MemoryStream(data))
                    {
                        object obj = bf.Deserialize(ms);
                        if (obj.GetType() == typeof(Undo_Redo.UndoRedoWrapper))
                        {
                            this.Undo_command = (Undo_Redo.UndoRedoWrapper)obj;

                            if (Undo_command.Command.Username != Username)
                            {
                                Undo_command = Manager.SaveCommand(Undo_command.Command, Undo_command.Command.IsUndo, Undo_command.Command.IsRedo);
                            }

                            if (Manager.Counter > 1)
                            {
                                if (Counter > 2)
                                {
                                    CmdLargeRepair cmdLargeRepair = new CmdLargeRepair();
                                    cmdLargeRepair.isLargeRepair = true;
                                    cmdLargeRepair.ID_Command = Guid.NewGuid();
                                    cmdLargeRepair.username = Username;

                                    BinaryFormatter bf1 = new BinaryFormatter();
                                    using (MemoryStream data1 = new MemoryStream())
                                    {
                                        bf1.Serialize(data1, cmdLargeRepair);
                                        ServerStream_priv.Write(data1.ToArray(), 0, data1.ToArray().Length);
                                        ServerStream_priv.Flush();
                                    }
                                }
                                else if (Manager.Commands[Manager.Counter - 1].ID_prevCommand != Undo_command.ID_prevCommand)
                                {
                                    Manager.Swap(Manager.Commands[Manager.Counter - 2], Manager.Commands[Manager.Counter - 1], Manager.Commands);
                                    Counter++;
                                }
                            }

                            this.Rect = Undo_command.Command;

                            if (Rect.EventName == "Rectangle Red")
                            {
                                this.Rect_Red = new RectangleRed(Rect.X, Rect.Y, Rect.Selected, Rect.Deleted, Rect.Moved, Rect.Username, Rect.MovingHelperX, Rect.MovingHelperY, Rect.IsUndo, Rect.IsRedo);
                                Rect_Red.HierarchyID = Rect.HierarchyID;
                                Rect_Red.EventList = Rect.EventList;
                                if (Rect_Red.IsUndo && Rect_Red.Deleted)
                                {
                                    DeleteRectangleRed_Invoker_Inverse(this.Rect_Red);
                                }
                                else if (Rect_Red.IsUndo)
                                {
                                    DrawRectangleRed_Invoker_Inverse(this.Rect_Red);
                                }
                                else if (Rect_Red.Moved)
                                {
                                    MoveRectangleRed_Invoker(this.Rect_Red);
                                }
                                else if (Rect_Red.Deleted)
                                {
                                    DeleteRectangleRed_Invoker(this.Rect_Red);
                                }
                                else if (Rect_Red.Selected)
                                {
                                    SelectRectangleRed(this.Rect_Red);
                                }
                                else
                                {
                                    DrawRectRed(this.Rect_Red);
                                }

                            }
                            else if (Rect.EventName == "Rectangle Blue")
                            {
                                this.Rect_Blue = new RectangleBlue(Rect.X, Rect.Y, Rect.Selected, Rect.Deleted, Rect.Moved, Rect.Username, Rect.MovingHelperX, Rect.MovingHelperY, Rect.IsUndo, Rect.IsRedo);

                                Rect_Blue.HierarchyID = Rect.HierarchyID;
                                Rect_Blue.EventList = Rect.EventList;
                                if (Rect_Blue.IsUndo && Rect_Blue.Deleted)
                                {
                                    DeleteRectangleBlue_Invoker_Inverse(this.Rect_Blue);
                                }
                                else if (Rect_Blue.IsUndo)
                                {
                                    DrawRectangleBlue_Invoker_Inverse(this.Rect_Blue);
                                }
                                else if (Rect_Blue.Moved)
                                {
                                    MoveRectangleBlue_Invoker(this.Rect_Blue);
                                }
                                else if (Rect_Blue.Deleted)
                                {
                                    DeleteRectangleBlue_Invoker(this.Rect_Blue);
                                }
                                else if (Rect_Blue.Selected)
                                {
                                    SelectRectangleBlue(this.Rect_Blue);
                                }
                                else
                                {
                                    DrawRectBlue(this.Rect_Blue);
                                }
                            }
                            else if (Rect.EventName == "Relation")
                            {
                                this.Rel = new Relation(Rect.Start, Rect.End, Rect.Selected, Rect.Deleted, Rect.Moved, Rect.Username, Rect.IsUndo, Rect.IsRedo);
                                Rel.EventList.Add(Rect.EventList[0]);
                                Rel.EventList.Add(Rect.EventList[1]);
                                Rel.HierarchyID = Rect.HierarchyID;
                                if (Rel.IsUndo && Rel.Deleted)
                                {
                                    DeleteRelation_Invoker_Inverse(Rel);
                                }
                                else if (Rel.IsUndo)
                                {
                                    DrawRelation_Invoker_Inverse(Rel);
                                }
                                else if (Rel.Deleted)
                                {
                                    DeleteRelation_Invoker(Rel);
                                }
                                else if (Rel.Moved)
                                {
                                    MoveRelation_Invoker(Rel);
                                }
                                else
                                {
                                    DrawRelation(Rel);
                                }
                            }
                            else if (Rect.EventName == "Label")
                            {
                                this.Lab = new Objects.Label(Rect.X, Rect.Y, Rect.Selected, Rect.Deleted, Rect.Moved, Rect.Username, Rect.MovingHelperX, Rect.MovingHelperY, Rect.IsUndo, Rect.IsRedo);

                                Lab.HierarchyID = Rect.HierarchyID;
                                Lab.EventList = Rect.EventList;

                                if (Lab.IsUndo && Lab.Deleted)
                                {
                                    DeleteLabel_Invoker_Inverse(this.Lab);
                                }
                                else if (Lab.IsUndo)
                                {
                                    DrawLabel_Invoker_Inverse(this.Lab);
                                }
                                else if (Lab.Deleted)
                                {
                                    DeleteLabel_Invoker(this.Lab);
                                }
                                else if (Lab.Selected)
                                {
                                    SelectLabelEvent(this.Lab);
                                }
                                else
                                {
                                    DrawLabel(this.Lab);
                                }

                            }
                        }
                        else
                        {
                            Console.WriteLine("This is large repair!");
                            Manager.Commands = (Undo_Redo.UndoRedoWrapper[])obj;
                        }
                    }
                }
                else
                {
                    break;
                }
            }
        }

        //COMMANDS------------------------------------------------------------------

        private void DrawRectRed(RectangleRed Rect)
        {
            CmdAddRectangleRed CmdAddRect = new CmdAddRectangleRed();
            CmdAddRect.Execute(Rect);
            CmdAddRect.hierarchyID = Rect.HierarchyID;
            Objects.Add(Rect);
        }

        private void DrawRectRed_Inverse(RectangleRed Rect)
        {
            CmdAddRectangleRed CmdAddRect = new CmdAddRectangleRed();
            CmdAddRect.Unexecute(Rect);
            CmdAddRect.hierarchyID = Rect.HierarchyID;
            Objects.Remove(Rect);
        }

        private void DrawRectangleRed_Invoker_Inverse(RectangleRed Rect)
        {
            DrawRectangleRed_Inverse DrawRect = new DrawRectangleRed_Inverse(DrawRectRed_Inverse);
            Invoke(DrawRect, Rect);
        }

        private void DrawRectBlue(RectangleBlue Rect)
        {
            CmdAddRectangleBlue CmdAddRect = new CmdAddRectangleBlue();
            CmdAddRect.Execute(Rect);
            CmdAddRect.hierarchyID = Rect.HierarchyID;
            Objects.Add(Rect);
        }

        private void DrawRectBlue_Inverse(RectangleBlue Rect)
        {
            CmdAddRectangleBlue CmdAddRect = new CmdAddRectangleBlue();
            CmdAddRect.Unexecute(Rect);
            CmdAddRect.hierarchyID = Rect.HierarchyID;
            Objects.Remove(Rect);
        }

        private void DrawRectangleBlue_Invoker_Inverse(RectangleBlue Rect)
        {
            DrawRectangleBlue_Inverse DrawRect = new DrawRectangleBlue_Inverse(DrawRectBlue_Inverse);
            Invoke(DrawRect, Rect);
        }

        private void DrawRelation(Relation Rel)
        {
            CmdAddRelation CmdAddRelation = new CmdAddRelation();
            CmdAddRelation.Execute(Rel);
            CmdAddRelation.hierarchyID = Rel.HierarchyID;
            Objects.Add(Rel);
        }

        private void DrawRel_Inverse(Relation Rel)
        {
            CmdAddRelation CmdAddRelation = new CmdAddRelation();
            CmdAddRelation.Unexecute(Rel);
            CmdAddRelation.hierarchyID = Rel.HierarchyID;
            Objects.Remove(Rel);
        }

        private void DrawRelation_Invoker_Inverse(Relation Rel)
        {
            DrawRelation_Inverse DrawRel = new DrawRelation_Inverse(DrawRel_Inverse);
            Invoke(DrawRel, Rel);
        }

        private void DrawLabel(Objects.Label Lab)
        {
            CmdAddLabel CmdAddLabel = new CmdAddLabel();
            CmdAddLabel.Execute(Lab);
            CmdAddLabel.hierarchyID = Lab.HierarchyID;
            Objects.Add(Lab);
        }

        private void DrawLab_Inverse(Objects.Label Lab)
        {
            CmdAddLabel CmdAddLabel = new CmdAddLabel();
            CmdAddLabel.Unexecute(Lab);
            CmdAddLabel.hierarchyID = Lab.HierarchyID;
            Objects.Remove(Lab);
        }

        private void DrawLabel_Invoker_Inverse(Objects.Label Lab)
        {
            DrawLabel_Inverse DrawLabel = new DrawLabel_Inverse(DrawLab_Inverse);
            Invoke(DrawLabel, Lab);
        }

        private void DeleteRectRed(RectangleRed Rect)
        {
            CmdDeleteRectangleRed CmdDeleteRectRed = new CmdDeleteRectangleRed();
            CmdDeleteRectRed.Execute(Rect);
            CmdDeleteRectRed.hierarchyID = Rect.HierarchyID;
        }

        private void DeleteRectangleRed_Invoker(RectangleRed Rect)
        {
            DeleteRectangleRed DeleteRect = new DeleteRectangleRed(DeleteRectRed);
            Invoke(DeleteRect, Rect);
        }

        private void DeleteRectRed_Inverse(RectangleRed Rect)
        {
            CmdDeleteRectangleRed CmdDeleteRect = new CmdDeleteRectangleRed();
            CmdDeleteRect.Unexecute(Rect);
            Objects.Add(Rect);
            CmdDeleteRect.hierarchyID = Rect.HierarchyID;
        }

        private void DeleteRectangleRed_Invoker_Inverse(RectangleRed Rect)
        {
            DeleteRectangleRed_Inverse DeleteRect = new DeleteRectangleRed_Inverse(DeleteRectRed_Inverse);
            Invoke(DeleteRect, Rect);
        }

        private void DeleteRectBlue_Inverse(RectangleBlue Rect)
        {
            CmdDeleteRectangleBlue CmdDeleteRect = new CmdDeleteRectangleBlue();
            CmdDeleteRect.Unexecute(Rect);
            Objects.Add(Rect);
            CmdDeleteRect.hierarchyID = Rect.HierarchyID;
        }

        private void DeleteRectangleBlue_Invoker_Inverse(RectangleBlue Rect)
        {
            DeleteRectangleBlue_Inverse DeleteRect = new DeleteRectangleBlue_Inverse(DeleteRectBlue_Inverse);
            Invoke(DeleteRect, Rect);
        }

        private void DeleteRel_Inverse(Relation Rel)
        {
            CmdDeleteRelation CmdDeleteRel = new CmdDeleteRelation();
            CmdDeleteRel.Unexecute(Rel);
            CmdDeleteRel.hierarchyID = Rel.HierarchyID;
        }

        private void DeleteRelation_Invoker_Inverse(Relation Rel)
        {
            DeleteRelation_Inverse DeleteRel = new DeleteRelation_Inverse(DeleteRel_Inverse);
            Invoke(DeleteRel, Rel);
        }

        private void DeleteRectBlue(RectangleBlue Rect)
        {
            CmdDeleteRectangleBlue CmdDeleteRect = new CmdDeleteRectangleBlue();
            CmdDeleteRect.Execute(Rect);
            CmdDeleteRect.hierarchyID = Rect.HierarchyID;
        }

        private void DeleteRectangleBlue_Invoker(RectangleBlue Rect)
        {
            DeleteRectangleBlue DeleteRect = new DeleteRectangleBlue(DeleteRectBlue);
            Invoke(DeleteRect, Rect);
        }

        private void DeleteRel(Relation Rel)
        {
            CmdDeleteRelation CmdDeleteRelation = new CmdDeleteRelation();
            CmdDeleteRelation.Execute(Rel);
            CmdDeleteRelation.hierarchyID = Rel.HierarchyID;
        }

        private void DeleteRelation_Invoker(Relation Rel)
        {
            DeleteRelation DeleteRelation = new DeleteRelation(DeleteRel);
            Invoke(DeleteRelation, Rel);
        }

        private void DeleteLab(Objects.Label Lab)
        {
            CmdDeleteLabel CmdDeleteLabel = new CmdDeleteLabel();
            CmdDeleteLabel.Execute(Lab);
            CmdDeleteLabel.hierarchyID = Lab.HierarchyID;
        }

        private void DeleteLabel_Invoker(Objects.Label Lab)
        {
            DeleteLabel DeleteObj = new DeleteLabel(DeleteLab);
            Invoke(DeleteObj, Lab);
        }

        private void DeleteLab_Inverse(Objects.Label Lab)
        {
            CmdDeleteLabel CmdDeleteLabel = new CmdDeleteLabel();
            CmdDeleteLabel.Unexecute(Lab);
            CmdDeleteLabel.hierarchyID = Lab.HierarchyID;
        }

        private void DeleteLabel_Invoker_Inverse(Objects.Label Lab)
        {
            DeleteLabel_Inverse DeleteObj = new DeleteLabel_Inverse(DeleteLab_Inverse);
            Invoke(DeleteObj, Lab);
        }

        private void MoveRectRed(RectangleRed Rect)
        {
            CmdMoveRectangleRed CmdMoveRect = new CmdMoveRectangleRed();
            CmdMoveRect.Execute(Rect);
            CmdMoveRect.hierarchyID = Rect.HierarchyID;
        }

        private void MoveRectangleRed_Invoker(RectangleRed Rect)
        {
            MoveRectanglRed MoveRect = new MoveRectanglRed(MoveRectRed);
            Invoke(MoveRect, Rect);
        }

        private void MoveRectBlue(RectangleBlue Rect)
        {
            CmdMoveRectangleBlue CmdMoveRect = new CmdMoveRectangleBlue();
            CmdMoveRect.Execute(Rect);
            CmdMoveRect.hierarchyID = Rect.HierarchyID;
        }

        private void MoveRectangleBlue_Invoker(RectangleBlue Rect)
        {
            MoveRectangleBlue MoveRect = new MoveRectangleBlue(MoveRectBlue);
            Invoke(MoveRect, Rect);
        }

        private void MoveRel(Relation Rel)
        {
            CmdMoveRelation CmdMoveRelation = new CmdMoveRelation();
            CmdMoveRelation.ID_Command = Guid.NewGuid();
            CmdMoveRelation.Execute(Rel);
            CmdMoveRelation.hierarchyID = Rel.HierarchyID;
        }

        private void MoveRelation_Invoker(Relation Rel)
        {
            MoveRelation MoveEvent = new MoveRelation(MoveRel);
            Invoke(MoveEvent, Rel);
        }

        private void SelectRectangleRed(RectangleRed Rect)
        {
            CmdSelectRectangleRed CmdSelectRect = new CmdSelectRectangleRed();
            CmdSelectRect.ID_Command = Guid.NewGuid();
            Rect.Username = Username;
            Rect.Selected = true;
            CmdSelectRect.Execute(Rect);
            Selected.Add(Rect);
        }

        private void SelectRectangleBlue(RectangleBlue Rect)
        {
            CmdSelectRectangleBlue CmdSelectRect = new CmdSelectRectangleBlue();
            CmdSelectRect.ID_Command = Guid.NewGuid();
            Rect.Username = Username;
            Rect.Selected = true;
            CmdSelectRect.Execute(Rect);
            Selected.Add(Rect);
        }

        private void SelectRelation(Relation Rel)
        {
            CmdSelectRelation cmdSelectRelation = new CmdSelectRelation();
            cmdSelectRelation.ID_Command = Guid.NewGuid();
            Rel.Username = Username;
            Rel.Selected = true;
            cmdSelectRelation.Execute(Rel);
            Selected.Add(Rel);
        }

        private void SelectLabelEvent(Objects.Label e1)
        {
            CmdSelectLabel CmdSelectLabel = new CmdSelectLabel();
            CmdSelectLabel.ID_Command = Guid.NewGuid();
            e1.Username = Username;
            e1.Selected = true;
            CmdSelectLabel.Execute(e1);
            Selected.Add(e1);
        }

        private bool CheckUnselection(int X, int Y, List<Rectangle_Object> Objects)
        {
            bool Result = false;
            for (int i = 0; i < Objects.Count; i++)
            {
                if (Objects[i].Name == "Relation")
                {
                    Point Start = GetNearestPoint(Objects[i].EventList[0], Objects[i].EventList[1].Center());
                    Point End = GetNearestPoint(Objects[i].EventList[1], Objects[i].EventList[0].Center());

                    if (CheckSelectionLine(X, Y, End.X, End.Y, Start.X, Start.Y))
                    {
                        Result = true;
                        break;
                    }
                }
                else if (Objects[i].Name == "Label")
                {
                    if (CheckSelection(X, Y, Objects[i].X, Objects[i].Y, Objects[i].X + 70, Objects[i].Y + 20))
                    {
                        Result = true;
                        break;
                    }
                }
                else
                {
                    if (CheckSelection(X, Y, Objects[i].X, Objects[i].Y, Objects[i].X + 150, Objects[i].Y + 70))
                    {
                        Result = true;
                        break;
                    }
                }
            }
            return Result;
        }


        private bool CheckSelection(int PointX, int PointY, int UpperLeftX, int UpperLeftY, int LowerRightX, int LowerRightY)
        {
            if ((PointX > UpperLeftX && PointX < LowerRightX) && (PointY < LowerRightY && PointY > UpperLeftY))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool CheckSelectionLine(int PointX, int PointY, int EndX, int EndY, int StartX, int StartY)
        {
            float dy = EndY - StartY;
            float dx = EndX - StartX;
            float Z = dy * PointX - dx * PointY + StartY * EndX - StartX * EndY;
            float N = dy * dy + dx * dx;
            float Dist = (float)(Math.Abs(Z) / Math.Sqrt(N));
            return Dist < 4 / 2f;
        }

        //----------------------------------------------------------------------------

        private void pnlCenter_MouseClick(object sender, MouseEventArgs e)
        {
            if (this.IsChecked_btnRectRed)
            {
                int x = e.Location.X;
                int y = e.Location.Y;
                Rect_Red = new RectangleRed(x, y);
                Rect_Red.Username = Username;
                Rect_Red.HierarchyID[0] = Canvas_ID;
                Rect_Red.HierarchyID[1] = Guid.NewGuid();

                CmdAddRectangleRed CmdAddRect = new CmdAddRectangleRed();
                CmdAddRect.username = Username;
                CmdAddRect.ID_Command = Guid.NewGuid();
                CmdAddRect.Execute(Rect_Red);
                CmdAddRect.hierarchyID = Rect_Red.HierarchyID;
                CmdAddRect.eventList = Rect_Red.EventList;

                Command_manager = Manager.SaveCommand(CmdAddRect, CmdAddRect.isUndo, CmdAddRect.isRedo);

                BinaryFormatter bf = new BinaryFormatter();
                using (MemoryStream data = new MemoryStream())
                {
                    bf.Serialize(data, CmdAddRect);
                    ServerStream_priv.Write(data.ToArray(), 0, data.ToArray().Length);
                    ServerStream_priv.Flush();
                }
            }
            else if (this.IsChecked_btnRectBlue)
            {
                int x = e.Location.X;
                int y = e.Location.Y;
                Rect_Blue = new RectangleBlue(x, y);

                CmdAddRectangleBlue CmdAddRect = new CmdAddRectangleBlue();
                Rect_Blue.Username = Username;
                Rect_Blue.HierarchyID[0] = Canvas_ID;
                Rect_Blue.HierarchyID[1] = Guid.NewGuid();
                CmdAddRect.ID_Command = Guid.NewGuid();
                CmdAddRect.eventList = Rect_Blue.EventList;
                CmdAddRect.Execute(Rect_Blue);
                CmdAddRect.hierarchyID = Rect_Blue.HierarchyID;

                Command_manager = Manager.SaveCommand(CmdAddRect, CmdAddRect.isUndo, CmdAddRect.isRedo);

                BinaryFormatter bf = new BinaryFormatter();
                using (MemoryStream data = new MemoryStream())
                {
                    bf.Serialize(data, CmdAddRect);
                    ServerStream_priv.Write(data.ToArray(), 0, data.ToArray().Length);
                    ServerStream_priv.Flush();
                }
            }
            else if (this.IsChecked_btnSelect)
            {
                int x = e.Location.X;
                int y = e.Location.Y;

                if (this.CheckUnselection(x, y, Objects))
                {
                    for (int i = Objects.Count - 1; i >= 0; i--)
                    {

                        if (Objects[i].Name == "Relation")
                        {
                            Point Start = GetNearestPoint(Objects[i].EventList[0], Objects[i].EventList[1].Center());
                            Point End = GetNearestPoint(Objects[i].EventList[1], Objects[i].EventList[0].Center());

                            bool helper = CheckSelectionLine(x, y, End.X, End.Y, Start.X, Start.Y);

                            if (helper)
                            {
                                SelectRelation((Relation)Objects[i]);
                                break;
                            }
                        }
                        else if (Objects[i].Name == "Label")
                        {
                            bool helper = this.CheckSelection(x, y, Objects[i].X, Objects[i].Y, Objects[i].X + 75, Objects[i].Y + 15);

                            if (helper)
                            {
                                SelectLabelEvent((Objects.Label)Objects[i]);
                                break;
                            }
                        }
                        else
                        {
                            bool helper = this.CheckSelection(x, y, Objects[i].X, Objects[i].Y, Objects[i].X + 150, Objects[i].Y + 70);

                            if (helper)
                            {
                                if (Objects[i].Name == "Rectangle Red")
                                {
                                    SelectRectangleRed((RectangleRed)Objects[i]);
                                    break;
                                }
                                else if (Objects[i].Name == "Rectangle Blue")
                                {
                                    SelectRectangleBlue((RectangleBlue)Objects[i]);
                                    break;
                                }
                            }
                        }

                    }
                }
                else
                {
                    for (int i = Objects.Count - 1; i >= 0; i--)
                    {
                        Objects[i].Unselect(pnlCenter);
                        Objects[i].Selected = false;
                        Selected.Clear();
                    }
                }
            }
        }

        private void btnEvent_One_Click(object sender, EventArgs e)
        {
            this.IsChecked_btnRectRed = true;
            this.IsChecked_btnRectBlue = false;
            this.IsChecked_btnSelect = false;

            for (int i = 0; i < Selected.Count; i++)
            {
                Selected[i].Unselect(pnlCenter);
            }
            Selected.Clear();
        }

        private void btnEvent_Two_Click(object sender, EventArgs e)
        {
            this.IsChecked_btnRectRed = false;
            this.IsChecked_btnRectBlue = true;
            this.IsChecked_btnSelect = false;

            for (int i = 0; i < Selected.Count; i++)
            {
                Selected[i].Unselect(pnlCenter);
            }
            Selected.Clear();
        }

        private void btnRelation_Click(object sender, EventArgs e)
        {
            this.IsChecked_btnRectRed = false;
            this.IsChecked_btnRectBlue = false;
            this.IsChecked_btnSelect = false;

            if (Selected.Count == 2)
            {
                Point Start = GetNearestPoint(Selected[1], Selected[0].Center());
                Point End = GetNearestPoint(Selected[0], Selected[1].Center());
                Rel = new Relation(Start, End);
                Rel.EventList.Add(Selected[0]);
                Rel.EventList.Add(Selected[1]);
                Rel.HierarchyID[0] = Canvas_ID;
                Rel.HierarchyID[1] = Guid.NewGuid();

                CmdAddRelation CmdAddRelation = new CmdAddRelation();
                Rel.Username = Username;
                CmdAddRelation.ID_Command = Guid.NewGuid();
                CmdAddRelation.Execute(Rel);
                CmdAddRelation.hierarchyID = Rel.HierarchyID;

                Command_manager = Manager.SaveCommand(CmdAddRelation, CmdAddRelation.isUndo, CmdAddRelation.isRedo);

                BinaryFormatter bf = new BinaryFormatter();
                using (MemoryStream data = new MemoryStream())
                {
                    bf.Serialize(data, CmdAddRelation);
                    ServerStream_priv.Write(data.ToArray(), 0, data.ToArray().Length);
                    ServerStream_priv.Flush();
                }
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            this.IsChecked_btnRectRed = false;
            this.IsChecked_btnRectBlue = false;
            this.IsChecked_btnSelect = true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            this.IsChecked_btnRectRed = false;
            this.IsChecked_btnRectBlue = false;
            this.IsChecked_btnSelect = false;

            if (Selected.Count == 1)
            {
                for (int i = 0; i < Objects.Count; i++)
                {
                    if (Selected[0] == Objects[i])
                    {
                        Objects[i].Moved = false;
                        Objects[i].Deleted = true;
                        if (Objects[i].Name == "Rectangle Red")
                        {
                            CmdDeleteRectangleRed CmdDeleteEventOne = new CmdDeleteRectangleRed();
                            Rect_Red = (RectangleRed)Objects[i];
                            Rect_Red.Username = Username;
                            CmdDeleteEventOne.ID_Command = Guid.NewGuid();
                            CmdDeleteEventOne.Execute(Rect_Red);
                            CmdDeleteEventOne.hierarchyID = Rect.HierarchyID;

                            Command_manager = Manager.SaveCommand(CmdDeleteEventOne, CmdDeleteEventOne.isUndo, CmdDeleteEventOne.isRedo);
                            BinaryFormatter bf = new BinaryFormatter();
                            using (MemoryStream data = new MemoryStream())
                            {
                                bf.Serialize(data, CmdDeleteEventOne);
                                ServerStream_priv.Write(data.ToArray(), 0, data.ToArray().Length);
                                ServerStream_priv.Flush();
                            }

                        }
                        else if (Objects[i].Name == "Rectangle Blue")
                        {
                            CmdDeleteRectangleBlue CmdDeleteEventTwo = new CmdDeleteRectangleBlue();
                            Rect_Blue = (RectangleBlue)Objects[i];
                            Rect_Blue.Username = Username;
                            CmdDeleteEventTwo.ID_Command = Guid.NewGuid();
                            CmdDeleteEventTwo.Execute(Rect_Blue);
                            CmdDeleteEventTwo.hierarchyID = Rect.HierarchyID;

                            Command_manager = Manager.SaveCommand(CmdDeleteEventTwo, CmdDeleteEventTwo.isUndo, CmdDeleteEventTwo.isRedo);
                            BinaryFormatter bf = new BinaryFormatter();
                            using (MemoryStream data = new MemoryStream())
                            {
                                bf.Serialize(data, CmdDeleteEventTwo);
                                ServerStream_priv.Write(data.ToArray(), 0, data.ToArray().Length);
                                ServerStream_priv.Flush();
                            }
                        }
                        else if (Objects[i].Name == "Relation")
                        {
                            CmdDeleteRelation CmdDeleteRelation = new CmdDeleteRelation();
                            Rel = (Relation)Objects[i];
                            Rel.Username = Username;
                            CmdDeleteRelation.ID_Command = Guid.NewGuid();
                            CmdDeleteRelation.Execute(Rel);
                            CmdDeleteRelation.hierarchyID = Rel.HierarchyID;

                            Command_manager = Manager.SaveCommand(CmdDeleteRelation, CmdDeleteRelation.isUndo, CmdDeleteRelation.isRedo);
                            BinaryFormatter bf = new BinaryFormatter();
                            using (MemoryStream data = new MemoryStream())
                            {
                                bf.Serialize(data, CmdDeleteRelation);
                                ServerStream_priv.Write(data.ToArray(), 0, data.ToArray().Length);
                                ServerStream_priv.Flush();
                            }
                        }
                        Selected.Clear();
                        break;
                    }
                }
            }
        }

        private void btnMove_Click(object sender, EventArgs e)
        {
            this.IsChecked_btnRectRed = false;
            this.IsChecked_btnRectBlue = false;
            this.IsChecked_btnSelect = false;

            if (Selected.Count == 1)
            {
                MovingForm form2 = new MovingForm();
                form2.Show();
                form2.SetX(Selected[0].X.ToString());
                form2.SetY(Selected[0].Y.ToString());
            }
        }

        public static void Moving(string x, string y)
        {
            if (Selected[0].Name == "Rectangle Red")
            {
                int HelperX = 0;
                int HelperY = 0;
                for (int i = Objects.Count - 1; i >= 0; i--)
                {
                    if (Objects[i].Selected)
                    {
                        HelperX = Objects[i].X;
                        HelperY = Objects[i].Y;
                    }
                }

                RectangleRed Rec = new RectangleRed(int.Parse(x), int.Parse(y), HelperX, HelperY);
                Rec.Moved = true;
                Rec.Username = Username;
                Rec.HierarchyID = Selected[0].HierarchyID;
                CmdMoveRectangleRed CmdMoveRec = new CmdMoveRectangleRed();
                CmdMoveRec.ID_Command = Guid.NewGuid();
                CmdMoveRec.Execute(Rec);
                CmdMoveRec.hierarchyID = Rec.HierarchyID;

                BinaryFormatter bf = new BinaryFormatter();
                using (MemoryStream data = new MemoryStream())
                {
                    bf.Serialize(data, CmdMoveRec);
                    ServerStream.Write(data.ToArray(), 0, data.ToArray().Length);
                    ServerStream.Flush();
                }
                Selected.Clear();
            }
            else if (Selected[0].Name == "Rectangle Blue")
            {
                int HelperX = 0;
                int HelperY = 0;
                for (int i = Objects.Count - 1; i >= 0; i--)
                {
                    if (Objects[i].Selected)
                    {
                        HelperX = Objects[i].X;
                        HelperY = Objects[i].Y;
                    }
                }

                RectangleBlue Rec = new RectangleBlue(int.Parse(x), int.Parse(y), HelperX, HelperY);
                Rec.Moved = true;
                Rec.Username = Username;
                CmdMoveRectangleBlue CmdMoveRec = new CmdMoveRectangleBlue();
                CmdMoveRec.ID_Command = Guid.NewGuid();
                CmdMoveRec.Execute(Rec);
                CmdMoveRec.hierarchyID = Rec.HierarchyID;

                BinaryFormatter bf = new BinaryFormatter();
                using (MemoryStream data = new MemoryStream())
                {
                    bf.Serialize(data, CmdMoveRec);
                    ServerStream.Write(data.ToArray(), 0, data.ToArray().Length);
                    ServerStream.Flush();
                }
                Selected.Clear();
            }
        }

        public static Point GetNearestPoint(Rectangle_Object Rect, Point Pt)
        {
            Point Result = new Point();
            if (Pt.X > Rect.X && Pt.X < Rect.X + 150 && Pt.Y > Rect.Y + 70)
            {
                Result.X = Pt.X;
                Result.Y = Rect.Y + 70;
                return Result;
            }
            else if (Pt.X > Rect.X + 150 && Pt.Y > Rect.Y && Pt.Y < Rect.Y + 70)
            {
                Result.X = Rect.X + 150;
                Result.Y = Pt.Y;
                return Result;
            }
            else if (Pt.X > Rect.X && Pt.X < Rect.X + 150 && Pt.Y < Rect.Y)
            {
                Result.X = Pt.X;
                Result.Y = Rect.Y;
                return Result;
            }
            else if (Pt.X < Rect.X && Pt.Y > Rect.Y && Pt.Y < Rect.Y + 70)
            {
                Result.X = Rect.X;
                Result.Y = Pt.Y;
                return Result;
            }
            else if (Pt.X < Rect.X && Pt.Y > Rect.Y + 70)
            {
                Result.X = Rect.X;
                Result.Y = Rect.Y + 70;
                return Result;
            }
            else if (Pt.X < Rect.X && Pt.Y < Rect.Y)
            {
                Result.X = Rect.X;
                Result.Y = Rect.Y;
                return Result;
            }
            else if (Pt.X > Rect.X && Pt.Y < Rect.Y)
            {
                Result.X = Rect.X + 150;
                Result.Y = Rect.Y;
                return Result;
            }
            else if (Pt.X > Rect.X && Pt.Y > Rect.Y)
            {
                Result.X = Rect.X + 150;
                Result.Y = Rect.Y + 70;
                return Result;
            }
            else
            {
                return Result;
            }
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            Command_Interface.ICommand CmdUndo;
            int Position = Manager.GetCommand(Username);

            if (Manager.Commands[Position].IsUndo)
            {
                Command_manager = Manager.Commands[Position];
                Command_manager = Manager.Commands[Command_manager.PrevCommand];

                Inverse_command = new Undo_Redo.UndoRedoWrapper(Command_manager.Command);

                CmdUndo = Inverse_command.Command;
            }
            else
            {
                Command_manager = Manager.Commands[Position];
                Inverse_command = new Undo_Redo.UndoRedoWrapper(Command_manager.Command);

                CmdUndo = Manager.GetCommandByPosition(Position);

            }

            if (Manager.ConflictAll(Position))
            {
                Console.WriteLine("There was some error acquired!");
            }
            else
            {
                CmdUndo.IsUndo = true;
                CmdUndo.ID_Command = Guid.NewGuid();
                CmdUndo.IsInverse = true;

                Inverse_command = Manager.Inverse(Command_manager);
                Inverse_command = Manager.SaveCommand(CmdUndo, CmdUndo.IsUndo, CmdUndo.IsRedo);

                btnRedo.Enabled = true;

                BinaryFormatter bf = new BinaryFormatter();
                using (MemoryStream data = new MemoryStream())
                {
                    bf.Serialize(data, CmdUndo);
                    ServerStream_priv.Write(data.ToArray(), 0, data.ToArray().Length);
                    ServerStream_priv.Flush();
                }
            }
        }

        private void btnRedo_Click(object sender, EventArgs e)
        {
            Command_Interface.ICommand cmdRedo;
            int position = Manager.GetCommand(Username);
            if (Manager.Commands[position].IsUndo)
            {
                Command_manager = Manager.Commands[position];
                Command_manager = Manager.Commands[Command_manager.UndoCommand];

                Redo_command = new Undo_Redo.UndoRedoWrapper(Command_manager.Command);

                cmdRedo = Redo_command.Command;

                if (Manager.ConflictAll(position))
                {
                    Console.WriteLine("There was some error acquired!");
                }
                else
                {
                    cmdRedo.IsUndo = false;
                    cmdRedo.IsRedo = true;
                    cmdRedo.ID_Command = Guid.NewGuid();

                    Redo_command = Manager.SaveCommand(cmdRedo, cmdRedo.IsUndo, cmdRedo.IsRedo);

                    Console.WriteLine(Manager.GetCommand(Username));

                    BinaryFormatter bf = new BinaryFormatter();
                    using (MemoryStream data = new MemoryStream())
                    {
                        bf.Serialize(data, cmdRedo);
                        ServerStream_priv.Write(data.ToArray(), 0, data.ToArray().Length);
                        ServerStream_priv.Flush();
                    }
                }

                btnRedo.Enabled = false;

            }
        }

        private void btnAddLabel_Click(object sender, EventArgs e)
        {
            Objects.Label Label_object = new Objects.Label();
            if (Selected.Count == 1)
            {
                CmdAddLabel CmdLabel = new CmdAddLabel();
                if (!Selected[0].EventList.Any())
                {
                    Label_object = new Objects.Label(Selected[0].X + 20, Selected[0].Y + 10);
                    Label_object.EventList.Add(Selected[0]);
                    Label_object.Username = Username;

                    for (int i = 0; i < 5; i++)
                    {
                        if (Label_object.EventList[0].HierarchyID[i] != new Guid("00000000-0000-0000-0000-000000000000"))
                        {
                            Label_object.HierarchyID[i] = Label_object.EventList[0].HierarchyID[i];
                        }
                        else
                        {
                            Label_object.HierarchyID[i] = Guid.NewGuid();
                        }
                    }
                }
                else if (Selected[0].EventList.Count == 1)
                {
                    Label_object = new Objects.Label(Selected[0].X + 20, Selected[0].Y + 30);
                    Label_object.EventList.Add(Selected[0]);
                    Label_object.Username = Username;

                    for (int i = 0; i < 5; i++)
                    {
                        if (Label_object.EventList[0].HierarchyID[i] != new Guid("00000000-0000-0000-0000-000000000000"))
                        {
                            Label_object.HierarchyID[i] = Label_object.EventList[0].HierarchyID[i];
                        }
                        else
                        {
                            Label_object.HierarchyID[i] = Guid.NewGuid();
                        }
                    }

                }
                else if (Selected[0].EventList.Count == 2)
                {
                    Label_object = new Objects.Label(Selected[0].X + 20, Selected[0].Y + 50);
                    Label_object.EventList.Add(Selected[0]);
                    Label_object.Username = Username;

                    for (int i = 0; i < 5; i++)
                    {
                        if (Label_object.EventList[0].HierarchyID[i] != new Guid("00000000-0000-0000-0000-000000000000"))
                        {
                            Label_object.HierarchyID[i] = Label_object.EventList[0].HierarchyID[i];
                        }
                        else
                        {
                            Label_object.HierarchyID[i] = Guid.NewGuid();
                        }
                    }
                }

                Selected[0].EventList.Add(Label_object);

                CmdLabel.username = Username;
                CmdLabel.ID_Command = Guid.NewGuid();
                CmdLabel.Execute(Label_object);
                CmdLabel.hierarchyID = Label_object.HierarchyID;

                Command_manager = Manager.SaveCommand(CmdLabel, CmdLabel.isUndo, CmdLabel.isRedo);

                BinaryFormatter bf = new BinaryFormatter();
                using (MemoryStream data = new MemoryStream())
                {
                    bf.Serialize(data, CmdLabel);
                    ServerStream_priv.Write(data.ToArray(), 0, data.ToArray().Length);
                    ServerStream_priv.Flush();
                }
            }
        }

        private void btnDeleteLabel_Click(object sender, EventArgs e)
        {
            this.IsChecked_btnRectRed = false;
            this.IsChecked_btnRectBlue = false;
            this.IsChecked_btnSelect = false;

            if (Selected.Count == 1)
            {
                for (int i = 0; i < Objects.Count; i++)
                {
                    if (Selected[0] == Objects[i])
                    {
                        Objects[i].Moved = false;
                        Objects[i].Deleted = true;
                        if (Objects[i].Name == "Label")
                        {
                            CmdDeleteLabel CmdDeleteLabel = new CmdDeleteLabel();
                            Objects.Label Help_object = (Objects.Label)Objects[i];
                            Help_object.Username = Username;
                            CmdDeleteLabel.ID_Command = Guid.NewGuid();
                            CmdDeleteLabel.Execute(Help_object);
                            CmdDeleteLabel.hierarchyID = Help_object.HierarchyID;

                            BinaryFormatter bf = new BinaryFormatter();
                            using (MemoryStream data = new MemoryStream())
                            {
                                bf.Serialize(data, CmdDeleteLabel);
                                ServerStream_priv.Write(data.ToArray(), 0, data.ToArray().Length);
                                ServerStream_priv.Flush();
                            }
                        }
                        Selected.Clear();
                        break;
                    }
                }
            }
        }

        private void Canvas_Load(object sender, EventArgs e)
        {
            //ClientSocket.Dispose();
        }
    }
}
