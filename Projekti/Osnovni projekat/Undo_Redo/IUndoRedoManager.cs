using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Undo_Redo
{ 
    interface IUndoRedoManager
    {
        Guid Instance_id { get; set; }
        int Counter { get; set; }
        int UndoCounter { get; set; }
        Dictionary<Guid, int> LastCommand { get; set; }
        UndoRedoWrapper[] Commands { get; set; }

    }
}
