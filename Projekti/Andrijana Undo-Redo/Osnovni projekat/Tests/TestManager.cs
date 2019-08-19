using System;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Client;
using Undo_Redo;
using Command_Interface;
using Client.Command;
using System.Net.Sockets;
using System.Net;

namespace Tests
{
    [TestFixture]
    public class TestManager
    {

        [Test]
        public void TestGetCommandOk()
        {
            UndoRedoManager manager = new UndoRedoManager();

            CmdAddRectangleRed cmdAddRectangleRed = new CmdAddRectangleRed();

            Guid userId = Guid.NewGuid();
            cmdAddRectangleRed.username = userId;

            manager.SaveCommand(cmdAddRectangleRed, false, false);

            Assert.AreEqual(0, manager.GetCommand(userId));
        }
        [Test]
        public void TestGetCommandError()
        {
            UndoRedoManager manager = new UndoRedoManager();

            CmdAddRectangleRed cmdAddRectangleRed = new CmdAddRectangleRed();

            Guid userId = Guid.NewGuid();
            Guid userId2 = Guid.NewGuid();
            cmdAddRectangleRed.username = userId;

            manager.SaveCommand(cmdAddRectangleRed, false, false);

            Assert.AreEqual(-1, manager.GetCommand(userId2));
        }
        [Test]
        public void TestSetCommandElsePart()
        {

            UndoRedoManager manager = new UndoRedoManager();
            Guid userId = Guid.NewGuid();
            Guid userId2 = Guid.NewGuid();
            CmdAddRectangleRed cmdAddRectangleRed = new CmdAddRectangleRed();
            CmdAddRectangleBlue cmdAddRectangleBlue = new CmdAddRectangleBlue();
            cmdAddRectangleRed.username = userId2;
            cmdAddRectangleBlue.username = userId;

            manager.SetCommand(new UndoRedoWrapper(cmdAddRectangleBlue));
            manager.SetCommand(new UndoRedoWrapper(cmdAddRectangleBlue));
            manager.Counter = 2;

            UndoRedoWrapper command = new UndoRedoWrapper(cmdAddRectangleRed);
            manager.SetCommand(command);

            Assert.Contains(2, manager.LastCommand.Values);
        }
        [Test]
        public void TestSetCommandIfPart()
        {
            UndoRedoManager manager = new UndoRedoManager();
            Guid userId = Guid.NewGuid();
            Guid userId2 = Guid.NewGuid();
            CmdAddRectangleRed cmdAddRectangleRed = new CmdAddRectangleRed();
            CmdAddRectangleBlue cmdAddRectangleBlue = new CmdAddRectangleBlue();
            CmdAddRectangleBlue cmdAddRectangleBlue2 = new CmdAddRectangleBlue();
            cmdAddRectangleRed.username = userId;
            cmdAddRectangleBlue.username = userId;
            cmdAddRectangleBlue2.username = userId2;


            UndoRedoWrapper wrapperBlue = new UndoRedoWrapper(cmdAddRectangleBlue);
            UndoRedoWrapper wrapperBlue2 = new UndoRedoWrapper(cmdAddRectangleBlue);
            UndoRedoWrapper wrapperRed = new UndoRedoWrapper(cmdAddRectangleRed);

            manager.Commands[0] = wrapperBlue;
            manager.SetCommand(wrapperBlue);
            manager.Commands[1] = wrapperBlue2;
            manager.SetCommand(wrapperBlue2);
            manager.Commands[2] = wrapperRed;

            manager.Counter = 3;
            manager.SetCommand(wrapperRed);
            int position = manager.Counter - 1;
            Assert.AreEqual(manager.LastCommand[userId], position);

        }

        [Test]
        public void TestConflictAll()
        {
            UndoRedoManager manager = new UndoRedoManager();
            Guid userId = Guid.NewGuid();
            Guid userId2 = Guid.NewGuid();
            CmdAddRectangleRed cmdAddRectangleRed = new CmdAddRectangleRed();
            CmdAddRectangleBlue cmdAddRectangleBlue = new CmdAddRectangleBlue();
            CmdAddRectangleBlue cmdAddRectangleBlue2 = new CmdAddRectangleBlue();
            cmdAddRectangleRed.username = userId;
            cmdAddRectangleBlue.username = userId;
            cmdAddRectangleBlue2.username = userId2;

            UndoRedoWrapper wrapperBlue = new UndoRedoWrapper(cmdAddRectangleBlue);
            UndoRedoWrapper wrapperBlue2 = new UndoRedoWrapper(cmdAddRectangleBlue2);
            UndoRedoWrapper wrapperRed = new UndoRedoWrapper(cmdAddRectangleRed);

            manager.Commands[0] = wrapperBlue;
            manager.SetCommand(wrapperBlue);
            manager.Commands[1] = wrapperRed;
            manager.SetCommand(wrapperBlue2);
            manager.Commands[2] = wrapperBlue2;

            Assert.IsFalse(manager.ConflictAll(2));


        }

        [Test]
        public void TestInverseCommand()
        {
            UndoRedoManager manager = new UndoRedoManager();
            CmdAddRectangleRed cmdAddRectangleRed = new CmdAddRectangleRed();
            UndoRedoWrapper wrapperRed = new UndoRedoWrapper(cmdAddRectangleRed);

            UndoRedoWrapper ret = manager.Inverse(wrapperRed);

            Assert.IsTrue(ret.IsInverse);


        }
    }
}
