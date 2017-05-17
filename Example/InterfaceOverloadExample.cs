using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Example
{
    [TestClass]
    public class InterfaceOverloadExample
    {
        [TestMethod]
        public void BaseClassShouldImplementTheMethod()
        {
            new BaseClass().TheMethod(1, false);
        } 

        [TestMethod]
        public void DerivedClassShouldBeABaseClass()
        {
            BaseClass example = new DerivedClass();
        }

        [TestMethod]
        public void DerivedClassShouldBeAnTheInterface()
        {
            ITheInterface example = new DerivedClass();
        }

        [TestMethod]
        public void TheInterfaceShouldImeplementTheMethod()
        {
            ITheInterface example = new DerivedClass();

            string stringVal = example.TheMethod(1, true);
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
    }
}
