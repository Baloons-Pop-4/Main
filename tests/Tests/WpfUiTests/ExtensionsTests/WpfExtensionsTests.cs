namespace Tests.WpfUiTests.ExtensionsTests
{
    using System;
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Markup;
    using BalloonsPop.GraphicUserInterface.Gadgets;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class WPfExtensionsTests
    {
        //// [TestMethod]
        //// [ExpectedException(typeof(NullReferenceException))]
        //// public void TestIf()
        //// {}

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void TestIfWrapInBorderThrowsWithNullCaller()
        {
            TextBlock nullCaller = null;

            nullCaller.WrapInBorder(new Border());
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void TestIfWrapInBorderThrowsWithNullBorder()
        {
            var block = new TextBlock();

            block.WrapInBorder(null);
        }

        [TestMethod]
        public void TestIfWrapInBorderCallerIsWrappedInProvidedBlock()
        {
            var block = new TextBlock();
            var wrapper = new Border();

            block.WrapInBorder(wrapper);

            Assert.AreEqual(block, wrapper.Child);
        }

        [TestMethod]
        public void TestIfWrapInBorderReturnsTheWrapperBorder()
        {
            var block = new TextBlock();
            var expected = new Border();

            var actual = block.WrapInBorder(expected);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void TestIfSetGridRowThrowsWithNullCaller()
        {
            TextBlock nullCaller = null;

            nullCaller.SetGridRow(0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestIfSetGridRowThrowsWithNegativeValue()
        {
            var block = new TextBlock();
            block.SetGridRow(-1);
        }

        [TestMethod]
        public void TestIfElementGridRowIsTheSameValueThatIsProvidedToSetGridRow()
        {
            var block = new TextBlock();
            block.SetGridRow(1);
            var expected = 1;
            var actual = Grid.GetRow(block);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestIfSetGridRowReturnsTheCaller()
        {
            var caller = new Button();
            var result = caller.SetGridRow(50);

            Assert.AreSame(caller, result);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void TestIfSetGridColThrowsWithNullCaller()
        {
            TextBlock nullCaller = null;

            nullCaller.SetGridCol(0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestIfSetGridColThrowsWithNegativeValue()
        {
            var block = new TextBlock();
            block.SetGridCol(-1);
        }

        [TestMethod]
        public void TestIfElementGridColIsTheSameValueThatIsProvidedToSetGridCol()
        {
            var block = new TextBlock();
            block.SetGridCol(1);
            var expected = 1;
            var actual = Grid.GetColumn(block);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestIfSetGridColReturnsTheCaller()
        {
            var caller = new Button();
            var result = caller.SetGridCol(50);

            Assert.AreSame(caller, result);
        }

        [TestMethod]
        public void TestIfSetSourceThrowsWithEmptyPath()
        {
            var img = new Image();
            var emptyPaths = new string[] { string.Empty, null, "     " };

            var argumentExceptionsC0unt = 0;

            foreach (var path in emptyPaths)
            {
                try
                {
                    img.SetSource(path);
                }
                catch (ArgumentException)
                {
                    argumentExceptionsC0unt++;
                }
            }

            Assert.AreEqual(argumentExceptionsC0unt, emptyPaths.Length);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void TestIfSetSourceThrowsWithNullCaller()
        {
            Image nullCaller = null;
            nullCaller.SetSource("somepathduzntrlymatter");
        }

        //// [TestMethod]
        //// public void TestIfSetSourceSetsPathCorrect() /* how the heck do i test dat shyt? */
        //// {
        ////     var image = new Image();
        ////     File.WriteAllText("dummyfile.png", "pokaji na tiya hora kak sa myatash");
        ////     image.SetSource("dummyfile.png");
        //// }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void TestIfAddAsChildToThrowsWithNullCaller()
        {
            var grid = new Grid();

            UIElement nullCaller = null;

            nullCaller.AddAsChildTo(grid);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void TestIfAddAsChildToThrowsWithNullParent()
        {
            Panel nullParent = null;

            UIElement someElement = new Button();

            someElement.AddAsChildTo(nullParent);
        }

        [TestMethod]
        public void TestIfAddAsChildAddsTheElementToTheTargetsChildren()
        {
            Panel parent = new Grid();
            UIElement child = new TextBlock();

            child.AddAsChildTo(parent);

            Assert.IsTrue(parent.Children.Contains(child));
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void TestIfCloneThrowsWithNullCaller()
        {
            UIElement nullCaller = null;
            nullCaller.Clone();
        }

        [TestMethod]
        public void TestIfClonedWpfControlWillBeEqualToItsPrototype()
        {
            var prototypes = new UIElement[] { new Button().AddAsChildTo(new Grid()), new TextBlock() { Text = "pesho" }, new Button(), new Image() { Height = 30 } };
            var clones = prototypes.Select(proto => proto.Clone()).ToArray();

            for (int i = 0, length = prototypes.Length; i < length; i++)
            {
                var protoAsString = XamlWriter.Save(prototypes[i]);
                var cloneAsString = XamlWriter.Save(clones[i]);

                Assert.AreEqual(protoAsString, cloneAsString);
            }
        }
    }
}
