using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Command_Interface;

namespace Undo_Redo
{
    [Serializable]
    public class UndoRedoWrapper
    {

        public UndoRedoWrapper (Command_Interface.ICommand command)
        {
            this.Command = command;
            this.ID_Command = command.ID_Command;
            this.Username = command.Username;
            this.ID_prevCommand = command.ID_Command;
            this.IsRedo = false;
            this.IsUndo = false;
            this.IsInverse = false;
        }

        public Guid ID_Command { get; set; }
        public Guid Username { get; set; }
        public ICommand Command { get; set; }
        public int PrevCommand { get; set; }
        public int UndoCommand { get; set; }
        public int RedoCommand { get; set; }
        public bool IsUndo { get; set; }
        public bool IsRedo { get; set; }
        public bool IsInverse { get; set; }
        public Guid ID_prevCommand { get; set; }
    }
}
