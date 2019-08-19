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
    ///Test should be run one by one becouse of the tcp connection
    [TestFixture]
    class MultipleObjectTest
    {
        [Test]
        public void SelectMultipleObjects()
        {
            TcpListener ServerSocket = new TcpListener(IPAddress.Parse("127.0.0.1"), 1000);
            ServerSocket.Start();

            PrivateObject canvas = new PrivateObject(typeof(Canvas));

            RectangleBlue blueObj = new RectangleBlue(50, 50, false);
            CmdAddRectangleBlue commandAddBlue = new CmdAddRectangleBlue();
            commandAddBlue.Execute(blueObj);
            Canvas.Objects.Add(blueObj);

            RectangleBlue blueObj2 = new RectangleBlue(250, 70, false);
            CmdAddRectangleBlue commandAddBlue2 = new CmdAddRectangleBlue();
            commandAddBlue2.Execute(blueObj2);
            Canvas.Objects.Add(blueObj2);

            RectangleRed redObj = new RectangleRed(450, 100, false);
            CmdAddRectangleRed commandAddRed = new CmdAddRectangleRed();
            commandAddRed.Execute(redObj);
            Canvas.Objects.Add(redObj);

            object[] paramsSelectClick = new object[] { null, null };
            canvas.Invoke("btnSelect_Click", paramsSelectClick);

            object[] paramsMouseClick = new object[] { null, new MouseEventArgs(MouseButtons.Left, 1, 60, 60, 0) };
            canvas.Invoke("pnlCenter_MouseClick", paramsMouseClick);

            object[] paramsMouseClick2 = new object[] { null, new MouseEventArgs(MouseButtons.Left, 1, 260, 90, 0) };
            canvas.Invoke("pnlCenter_MouseClick", paramsMouseClick2);

            object[] paramsMouseClick3 = new object[] { null, new MouseEventArgs(MouseButtons.Left, 1, 470, 150, 0) };
            canvas.Invoke("pnlCenter_MouseClick", paramsMouseClick3);

            NUnit.Framework.Assert.IsTrue(blueObj.Selected);
            NUnit.Framework.Assert.IsTrue(blueObj2.Selected);
            NUnit.Framework.Assert.IsTrue(redObj.Selected);
        }

        [Test]
        public void DeselectMultipleObjects()
        {
            TcpListener ServerSocket = new TcpListener(IPAddress.Parse("127.0.0.1"), 1000);
            ServerSocket.Start();
            PrivateObject canvas = new PrivateObject(typeof(Canvas));

            RectangleBlue blueObj = new RectangleBlue(50, 50, true);
            CmdAddRectangleBlue commandAddBlue = new CmdAddRectangleBlue();
            commandAddBlue.Execute(blueObj);
            Canvas.Objects.Add(blueObj);

            RectangleBlue blueObj2 = new RectangleBlue(250, 70, true);
            CmdAddRectangleBlue commandAddBlue2 = new CmdAddRectangleBlue();
            commandAddBlue2.Execute(blueObj2);
            Canvas.Objects.Add(blueObj2);

            RectangleRed redObj = new RectangleRed(450, 100, true);
            CmdAddRectangleRed commandAddRed = new CmdAddRectangleRed();
            commandAddRed.Execute(redObj);
            Canvas.Objects.Add(redObj);

            object[] paramsSelectClick = new object[] { null, null };
            canvas.Invoke("btnSelect_Click", paramsSelectClick);

            object[] paramsMouseClick3 = new object[] { null, new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0) };
            canvas.Invoke("pnlCenter_MouseClick", paramsMouseClick3);

            NUnit.Framework.Assert.IsFalse(blueObj.Selected);
            NUnit.Framework.Assert.IsFalse(blueObj2.Selected);
            NUnit.Framework.Assert.IsFalse(redObj.Selected);
        }

    }
}
