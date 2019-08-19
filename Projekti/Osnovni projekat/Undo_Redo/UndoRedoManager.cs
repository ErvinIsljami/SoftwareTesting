using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Undo_Redo
{
    [Serializable]
    public class UndoRedoManager : IUndoRedoManager
    {
        Guid IUndoRedoManager.Instance_id { get; set; }
        int IUndoRedoManager.Counter { get; set; }
        int IUndoRedoManager.UndoCounter { get; set; }
        Dictionary<Guid, int> IUndoRedoManager.LastCommand { get; set; }
        UndoRedoWrapper[] IUndoRedoManager.Commands { get; set; }

        public UndoRedoWrapper[] Commands { get; set; }
        public Dictionary<Guid, int> LastCommand { get; set; }
        public int Counter { get; set; }
        public int UndoCounter { get; set; }
        public Guid Instance_id { get; set; }

        public UndoRedoManager()
        {
            Commands = new UndoRedoWrapper[500];
            LastCommand = new Dictionary<Guid, int>();
            Counter = 0;
            UndoCounter = 0;
        }

        public int GetCommand (Guid username)
        {
            if (LastCommand.ContainsKey(username))
            {
                return LastCommand[username];
            } else
            {
                return -1;
            }
        }

        public Command_Interface.ICommand GetCommandByPosition (int position)
        {
            return Commands[position].Command;
        }

        public void SetCommand (UndoRedoWrapper command)
        {
            if (LastCommand.ContainsKey(command.Command.Username))
            {
                int position = 0;

                for (int i = Counter; i >= 0; i--)
                {
                    if (command == Commands[i])
                    {
                        position = i;
                    }
                }

                LastCommand[command.Command.Username] = position;
            }
            else
            {
                LastCommand.Add(command.Command.Username, Counter); 
            }
        }

        public UndoRedoWrapper SaveCommand (Command_Interface.ICommand command, bool isUndo, bool isRedo)
        {
            UndoRedoWrapper tempCommand = new UndoRedoWrapper(command);
            if (GetCommand(command.Username) != -1)
            {
                tempCommand.PrevCommand = GetCommand(command.Username);
                if (isUndo)
                {
                    tempCommand.IsUndo = true;
                    if (Commands[tempCommand.PrevCommand].IsUndo)
                    {
                        if (Counter == 0)
                        {
                            tempCommand.ID_prevCommand = tempCommand.ID_Command;
                        }
                        else
                        {
                            tempCommand.ID_prevCommand = Commands[Counter - 1].ID_Command;
                        }
                        tempCommand.UndoCommand = Commands[tempCommand.PrevCommand].PrevCommand;
                        tempCommand.PrevCommand = Commands[tempCommand.UndoCommand].PrevCommand;
                        tempCommand.Command.HierarchyID = Commands[tempCommand.UndoCommand].Command.HierarchyID;
                        tempCommand.Command.EventList = Commands[tempCommand.UndoCommand].Command.EventList;

                        Commands[Counter] = tempCommand;
                        Counter++;
                        UndoCounter--;
                        tempCommand.Username = command.Username;
                        SetCommand(tempCommand);

                        return tempCommand;
                    }
                    else
                    {
                        if (Counter == 0)
                        {
                            tempCommand.ID_prevCommand = tempCommand.ID_Command;
                        }
                        else
                        {
                            tempCommand.ID_prevCommand = Commands[Counter - 1].ID_Command;
                        }
                        tempCommand.UndoCommand = tempCommand.PrevCommand;
                        tempCommand.PrevCommand = Commands[tempCommand.PrevCommand].PrevCommand;
                        tempCommand.Command.HierarchyID = Commands[tempCommand.UndoCommand].Command.HierarchyID;
                        tempCommand.Command.EventList = Commands[tempCommand.UndoCommand].Command.EventList;

                        Commands[Counter] = tempCommand;
                        Counter++;
                        UndoCounter--;
                        tempCommand.Username = command.Username;
                        SetCommand(tempCommand);

                        return tempCommand;
                    }
                }
                else if (isRedo)
                {
                    tempCommand.IsRedo = true;
                    if (Counter == 0)
                    {
                        tempCommand.ID_prevCommand = tempCommand.ID_Command;
                    }
                    else
                    {
                        tempCommand.ID_prevCommand = Commands[Counter - 1].ID_Command;
                    }
                    tempCommand.IsRedo = true;
                    Commands[tempCommand.PrevCommand].RedoCommand = Counter;
                    tempCommand.Command.HierarchyID = Commands[tempCommand.PrevCommand].Command.HierarchyID;
                    tempCommand.Command.EventList = Commands[tempCommand.PrevCommand].Command.EventList;
                    tempCommand.PrevCommand = Commands[tempCommand.PrevCommand].PrevCommand;

                    Commands[Counter] = tempCommand;
                    Counter++;
                    UndoCounter++;
                    tempCommand.Username = command.Username;
                    SetCommand(tempCommand);

                    return tempCommand;
                }
                else 
                {
                    if (Commands[tempCommand.PrevCommand].IsUndo || Commands[tempCommand.PrevCommand].IsRedo)
                    {
                        tempCommand.PrevCommand = Commands[tempCommand.PrevCommand].PrevCommand;
                        if (Counter == 0)
                        {
                            tempCommand.ID_prevCommand = tempCommand.ID_Command;
                        }
                        else
                        {
                            tempCommand.ID_prevCommand = Commands[Counter - 1].ID_Command;
                        }
                        Commands[Counter] = tempCommand;
                        command.PrevCommand = tempCommand.PrevCommand;
                        Counter++;
                        UndoCounter++;
                        tempCommand.Username = command.Username;
                        SetCommand(tempCommand);
                        return tempCommand;
                    }
                    else
                    {
                        if (Counter == 0)
                        {
                            tempCommand.ID_prevCommand = tempCommand.ID_Command;
                        }
                        else
                        {
                            tempCommand.ID_prevCommand = Commands[Counter - 1].ID_Command;
                        }
                        Commands[Counter] = tempCommand;
                        command.PrevCommand = tempCommand.PrevCommand;
                        Counter++;
                        UndoCounter++;
                        tempCommand.Username = command.Username;
                        SetCommand(tempCommand);
                        return tempCommand;
                    }
                }
            }
            else
            {
                if (Counter == 0)
                {
                    tempCommand.ID_prevCommand = tempCommand.ID_Command;
                } else
                {
                    tempCommand.ID_prevCommand = Commands[Counter - 1].ID_Command;
                }
                tempCommand.PrevCommand = Counter;
                tempCommand.Command.HierarchyID = command.HierarchyID;
                command.PrevCommand = tempCommand.PrevCommand;
                Commands[Counter] = tempCommand;
                tempCommand.Username = command.Username;
                SetCommand(tempCommand);
                Counter++;
                UndoCounter++;
                return tempCommand;
            }
            
        }

        public bool CheckingUndo(UndoRedoWrapper command1, UndoRedoWrapper command2)
        {
            bool result = false;
            for (int i = Counter - 1; i >= 0; i--)
            {
                if (Commands[Commands[i].UndoCommand].ID_Command == command2.ID_Command)
                {
                    result = true;
                }
            }
            return result;
        }

        public bool ConflictAll(int position)
        {
            bool result = false;
            UndoRedoWrapper[] tempCommands_array = new UndoRedoWrapper[Commands.Length];

            for (int i = 0; i < Counter; i++)
            {
                tempCommands_array[i] = Commands[i];
            }
            for (int i = position; i < Counter - 1; i++)
            {
                if (CheckingUndo(tempCommands_array[i], tempCommands_array[i+1]))
                {
                    result = false;
                } else
                {
                    if (Conflict(tempCommands_array[i], tempCommands_array[i + 1]))
                    {
                        result = true;
                        break;
                    }
                    else
                    {
                        result = false;
                        Swap(tempCommands_array[i], tempCommands_array[i + 1], tempCommands_array);
                    }
                }
            }
            return result;
        }

        public void Swap (UndoRedoWrapper command1, UndoRedoWrapper command2, UndoRedoWrapper[] commands_array)
        {
            int helper1 = 0;
            int helper2 = 0;
            for (int i = 0; i < Counter; i++)
            {
                if (Commands[i] == command1)
                {
                    helper1 = i;
                } else if (Commands[i] == command2)
                {
                    helper2 = i;
                }
            }
            commands_array[helper1] = command2;
            commands_array[helper2] = command1;
        }

        public UndoRedoWrapper Inverse (UndoRedoWrapper command)
        {
            UndoRedoWrapper helperCommand = command;
            helperCommand.IsInverse = true;
            return helperCommand;
        }

        public bool Conflict (UndoRedoWrapper command1, UndoRedoWrapper command2)
        {
            int command1_level = 0;
            int command2_level = 0;

            for (int i = 0; i < 5; i++)
            {
                if (command1.Command.HierarchyID[i] == new Guid("00000000-0000-0000-0000-000000000000"))
                {
                    command1_level = i;
                    break;
                }
            }

            for (int i = 0; i < 5; i++)
            {
                if (command2.Command.HierarchyID[i] == new Guid("00000000-0000-0000-0000-000000000000"))
                {
                    command2_level = i;
                    break;
                }
            }

            bool result = false;

            for (int i = 0; i < Math.Max(command2_level, command1_level); i++)
            {
                if (command1.Command.HierarchyID[i] == command2.Command.HierarchyID[i] || i > Math.Min(command1_level-1, command2_level-1))
                {
                    result = true;
                } else
                {
                    result = false;
                    break;
                }
            }

            return result;
        }
    }
}
