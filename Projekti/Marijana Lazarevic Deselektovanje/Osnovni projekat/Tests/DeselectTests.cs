using System;
using Client;
using Client.Command;
using Client.Objects;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class DeselectTests
    {
        [Test]
        public void TestOneObjectSelect()
        {
            Canvas canvas = new Canvas(true);
            Guid rectObjId = Guid.NewGuid();
            Rectangle_Object rectObj = new RectangleBlue(0, 0, false, false, false, rectObjId, 0, 0, false, false);
            CmdAddRectangleRed cmdAddRect = new CmdAddRectangleRed();
            cmdAddRect.Execute(rectObj);
            Canvas.Objects.Add(rectObj);

            canvas.IsChecked_btnSelectProp = true;
            canvas.IsChecked_btnRectRedProp = false;
            canvas.IsChecked_btnRectBlueProp = false;

            canvas.pnlCenter_MouseClickWrapper(10, 10, 1, 0);

            Assert.IsTrue(rectObj.Selected);
            
        }

        [Test]
        public void TestTwoObjectsSelect()
        {
            Canvas canvas = new Canvas(true);
            Guid rectObjId = Guid.NewGuid();
            Rectangle_Object rectObjRed = new RectangleRed(0, 0, false, false, false, rectObjId, 0, 0, false, false);
            Rectangle_Object rectObjBlue = new RectangleBlue(50, 20, false, false, false, rectObjId, 0, 0, false, false);
            CmdAddRectangleRed cmdAddRectRed = new CmdAddRectangleRed();
            CmdAddRectangleBlue cmdAddRectBlue = new CmdAddRectangleBlue();
            cmdAddRectRed.Execute(rectObjRed);
            Canvas.Objects.Add(rectObjRed);
            cmdAddRectBlue.Execute(rectObjBlue);
            Canvas.Objects.Add(rectObjBlue);

            canvas.IsChecked_btnSelectProp = true;
            canvas.IsChecked_btnRectRedProp = false;
            canvas.IsChecked_btnRectBlueProp = false;

            canvas.pnlCenter_MouseClickWrapper(55, 25, 1, 0);

            Assert.IsTrue(rectObjBlue.Selected);
            Assert.IsFalse(rectObjRed.Selected);

            canvas.pnlCenter_MouseClickWrapper(10, 10, 1, 0);

            Assert.IsTrue(rectObjRed.Selected);

        }

        [Test]
        public void TestUnselectOneObject()
        {
            Canvas canvas = new Canvas(true);
            Guid rectObjId = Guid.NewGuid();
            Rectangle_Object rectObj = new RectangleBlue(0, 0, true, false, false, rectObjId, 0, 0, false, false);
            CmdAddRectangleRed cmdAddRect = new CmdAddRectangleRed();
            cmdAddRect.Execute(rectObj);
            Canvas.Objects.Add(rectObj);

            canvas.IsChecked_btnSelectProp = true;
            canvas.IsChecked_btnRectRedProp = false;
            canvas.IsChecked_btnRectBlueProp = false;

            canvas.pnlCenter_MouseClickWrapper(200, 10, 1, 0);

            Assert.IsFalse(rectObj.Selected);

        }

        [Test]
        public void TestUnselectTwoObjects()
        {
            Canvas canvas = new Canvas(true);
            Guid rectObjId = Guid.NewGuid();
            Rectangle_Object rectObjRed = new RectangleRed(0, 0, true, false, false, rectObjId, 0, 0, false, false);
            Rectangle_Object rectObjBlue = new RectangleBlue(200, 20, true, false, false, rectObjId, 0, 0, false, false);
            CmdAddRectangleRed cmdAddRectRed = new CmdAddRectangleRed();
            CmdAddRectangleBlue cmdAddRectBlue = new CmdAddRectangleBlue();
            cmdAddRectRed.Execute(rectObjRed);
            Canvas.Objects.Add(rectObjRed);
            cmdAddRectBlue.Execute(rectObjBlue);
            Canvas.Objects.Add(rectObjBlue);

            canvas.IsChecked_btnSelectProp = true;
            canvas.IsChecked_btnRectRedProp = false;
            canvas.IsChecked_btnRectBlueProp = false;

            canvas.pnlCenter_MouseClickWrapper(100, 300, 1, 0);

            Assert.IsFalse(rectObjBlue.Selected);
            Assert.IsFalse(rectObjRed.Selected);
        }
    }
}
