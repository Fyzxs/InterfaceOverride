using System;
using System.Configuration;
using System.Net.Mime;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Example
{
    [TestClass]
    public class InterfaceOverloadExample
    {

        #region Simple Example Of Interface Overload
        [TestMethod]
        public void BaseClassShouldImplementTheMethod()
        {
            string stringVal = new BaseClass().TheMethod(1, false);

            Assert.AreEqual("StringVal", stringVal);
        } 

        [TestMethod]
        public void DerivedClassShouldBeABaseClass()
        {
            BaseClass example = new DerivedClass();

            Assert.IsNotNull(example);
        }

        [TestMethod]
        public void DerivedClassShouldBeAnTheInterface()
        {
            ITheInterface example = new DerivedClass();

            Assert.IsNotNull(example);
        }

        [TestMethod]
        public void TheInterfaceShouldImeplementTheMethod()
        {
            ITheInterface example = new DerivedClass();

            string stringVal = example.TheMethod(1, true);

            Assert.AreEqual("StringVal", stringVal);
        }

        [TestMethod]
        public void BaseClassImplUsedThroughTheInterface()
        {
            ITheInterface example = new DerivedClass();

            string stringVal = example.TheMethod(1, true);

            Assert.AreEqual("StringVal", stringVal);
        }

        public interface ITheInterface {
            string TheMethod(int intVal, bool boolVal);
        }

        public class DerivedClass : BaseClass, ITheInterface { }

        public class BaseClass {
            public string TheMethod(int intVal, bool boolVal) => "StringVal";
        }

        #endregion

        #region UI-ish Example of Interface Overload

        [TestMethod]
        public void UiWidgetHasTextSetter()
        {
            BaseUiWidget widget = new BaseUiWidget {Text = "Setting String"};


            Assert.AreEqual("Setting String", widget.Text);
        }

        [TestMethod]
        public void UiWidgetHasTextGetter()
        {
            BaseUiWidget widget = new BaseUiWidget { Text = "Getting String" };

            string text = widget.Text;

            Assert.AreEqual("Getting String", text);
        }

        [TestMethod]
        public void WrappedUiWidgetShouldExtendSetTexte()
        {
            ISetText enc = new WrappedUiWidget();

            Assert.IsNotNull(enc);
        }

        [TestMethod]
        public void WrappedUiWidgetShouldExtenBaseUiWidget()
        {
            BaseUiWidget enc = new WrappedUiWidget();

            Assert.IsNotNull(enc);
        }

        [TestMethod]
        public void EncapsulatedDataShouldWriteToSetText()
        {
            EncapsulatedData data = new EncapsulatedData("It's Non-Mutable");
            WrappedUiWidget widget = new WrappedUiWidget();

            data.DisplayValue(widget);

            Assert.AreEqual("It's Non-Mutable", widget.Text);
        }

        public class WrappedUiWidget : BaseUiWidget, ISetText{}

        public class BaseUiWidget {//Like a TextBox
            public string Text { get;  set; }
        }

        public interface ISetText { string Text { set; } }

        public partial class EncapsulatedData
        {
            private readonly string _value;

            public EncapsulatedData(string value) => _value = value;
        }

        //This Partial has the methods to interact with UI Elements
        public partial class EncapsulatedData
        {
            public void DisplayValue(ISetText widget) => widget.Text = _value;
        }

        #endregion
    }
}
