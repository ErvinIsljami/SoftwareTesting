using Server;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Undo_Redo;

namespace Tests
{
    public class FakeServer
    {
        private readonly static Hashtable ClientsList = new Hashtable();
        private readonly static Guid Server_guid1 = Guid.NewGuid();
        private readonly static Undo_Redo.UndoRedoManager Undo_Manager1 = new UndoRedoManager();
        public static Hashtable ClientsList_pub => ClientsList;
        public static Guid Server_guid => Server_guid1;
        public static UndoRedoManager Undo_Manager => Undo_Manager1;

        public FakeServer()
        {
            Thread fakeMainThread = new Thread(FakeMain);
            fakeMainThread.Start();
        }

        private void FakeMain()
        {
            TcpListener ServerSocket = new TcpListener(IPAddress.Parse("127.0.0.1"), 1000);
            TcpClient ClientSocket = default(TcpClient);

            ServerSocket.Start();
            Console.WriteLine("Server Started ...");
            while (true)
            {
                try
                {
                    ClientSocket = ServerSocket.AcceptTcpClient();
                    byte[] BytesFrom = new byte[10025];
                    string DataFromClient = null;

                    NetworkStream NetworkStream = ClientSocket.GetStream();
                    NetworkStream.Read(BytesFrom, 0, 2000);

                    DataFromClient = System.Text.Encoding.ASCII.GetString(BytesFrom);
                    DataFromClient = DataFromClient.Substring(0, DataFromClient.IndexOf("$"));

                    ClientsList.Add(DataFromClient, ClientSocket);
                    Guid GuidName = Guid.Parse(DataFromClient);

                    FakeHandleClient Client = new FakeHandleClient();
                    Client.StartClient(ClientSocket, DataFromClient, ClientsList);
                }
                catch
                {
                    ClientSocket.Close();
                    ServerSocket.Stop();

                }

            }
        }

        public static void Broadcast(byte[] Msg, string UName, bool Flag)
        {
            foreach (DictionaryEntry Item in ClientsList)
            {
                TcpClient BroadcastSocket;
                BroadcastSocket = (TcpClient)Item.Value;
                NetworkStream BroadcastStream = BroadcastSocket.GetStream();
                Byte[] BroadcastBytes = null;

                if (Flag)
                {
                    BroadcastBytes = Msg;
                    BroadcastStream.Write(BroadcastBytes, 0, BroadcastBytes.Length);
                    BroadcastStream.Flush();
                }
            }
        }
    }

    public class FakeHandleClient
    {
        private TcpClient ClientSocket;
        private string ClNo;
        private Command_Interface.ICommand Model;
        private UndoRedoWrapper ResultCommand;

        public void StartClient(TcpClient InClientSocket, string ClineNo, Hashtable CList)
        {
            this.ClientSocket = InClientSocket;
            this.ClNo = ClineNo;
            Hashtable ClientsList = CList;
            Thread CtThread = new Thread(DoCollaborative);
            CtThread.Start();
        }

        public void DoCollaborative()
        {
            int RequestCount = 0;
            byte[] BytesFrom = new byte[10025];

            while (true)
            {
                try
                {
                    RequestCount = RequestCount + 1;
                    NetworkStream NetworkStream = ClientSocket.GetStream();
                    NetworkStream.Read(BytesFrom, 0, 10025);
                    Console.WriteLine("Client - " + ClNo + " - has just done some action!");

                    BinaryFormatter Bf = new BinaryFormatter();
                    using (MemoryStream Ms = new MemoryStream(BytesFrom))
                    {
                        object Obj = Bf.Deserialize(Ms);
                        Model = (Command_Interface.ICommand)Obj;
                        UndoRedoWrapper manager_helper = new UndoRedoWrapper(Model);

                        int Position = 0;
                        if (Model.IsLargeRepair)
                        {
                            BinaryFormatter Bf2 = new BinaryFormatter();
                            using (MemoryStream Data = new MemoryStream())
                            {
                                Bf2.Serialize(Data, Program.Undo_Manager.Commands);

                                Program.Broadcast(Data.ToArray(), ClNo, true);
                            }
                            continue;
                        }
                        else if (Model.IsUndo)
                        {
                            Position = Program.Undo_Manager.GetCommand(Model.Username);
                            if (Program.Undo_Manager.ConflictAll(Position))
                            {
                                Console.WriteLine("There was some error acquired!");
                            }
                            else
                            {
                                ResultCommand = Program.Undo_Manager.Inverse(manager_helper);
                                ResultCommand = Program.Undo_Manager.SaveCommand(Model, Model.IsUndo, Model.IsRedo);
                            }
                        }
                        else
                        {
                            ResultCommand = Program.Undo_Manager.SaveCommand(Model, Model.IsUndo, Model.IsRedo);
                        }

                        using (MemoryStream data = new MemoryStream())
                        {
                            Bf.Serialize(data, ResultCommand);

                            Program.Broadcast(data.ToArray(), ClNo, true);
                        }
                    }
                }
                catch (Exception ex)
                {
                    ClientSocket.Close();
                    Console.WriteLine(ex.ToString());
                }
            }
        }
    }
}
