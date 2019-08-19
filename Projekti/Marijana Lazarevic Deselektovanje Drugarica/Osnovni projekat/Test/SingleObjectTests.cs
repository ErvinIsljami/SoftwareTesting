using System;
using Client;
using Client.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Client.Command;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;

namespace Test
{
    [TestFixture]
    public class SingleObjectTests
    {
        [Test]
        public void SelectSingleObject()
        {
            TcpListener ServerSocket = new TcpListener(IPAddress.Parse("127.0.0.1"), 1000);
            ServerSocket.Start();

            PrivateObject canvas = new PrivateObject(typeof(Canvas));

            RectangleBlue blueObj = new RectangleBlue(50, 50, false);
          
            CmdAddRectangleBlue commandAddBlue = new CmdAddRectangleBlue();
            commandAddBlue.Execute(blueObj);
            Canvas.Objects.Add(blueObj);

            object[] paramsSelectClick = new object[] { null, null };
            canvas.Invoke("btnSelect_Click", paramsSelectClick);

            object[] paramsMouseClick = new object[] { null, new MouseEventArgs(MouseButtons.Left, 1, 60, 60, 0) };
            canvas.Invoke("pnlCenter_MouseClick", paramsMouseClick);

            NUnit.Framework.Assert.IsTrue(blueObj.Selected);
        }

        [Test]
        public void DeselectSingleObject()
        {
            TcpListener ServerSocket = new TcpListener(IPAddress.Parse("127.0.0.1"), 1000);
            ServerSocket.Start();

            PrivateObject canvas = new PrivateObject(typeof(Canvas));
            RectangleBlue blueObj = new RectangleBlue(50, 50, true);

            CmdAddRectangleBlue commandAddBlue = new CmdAddRectangleBlue();
            commandAddBlue.Execute(blueObj);
            Canvas.Objects.Add(blueObj);

            object[] paramsSelectClick = new object[] { null, null };
            canvas.Invoke("btnSelect_Click", paramsSelectClick);

            object[] paramsMouseClick = new object[] { null, new MouseEventArgs(MouseButtons.Left, 1, 420, 69, 0) };
            canvas.Invoke("pnlCenter_MouseClick", paramsMouseClick);

            NUnit.Framework.Assert.IsFalse(blueObj.Selected);
        }
    }
}
