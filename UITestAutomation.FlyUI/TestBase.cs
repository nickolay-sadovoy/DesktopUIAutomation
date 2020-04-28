using FlaUI.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UITestAutomation.FlyUI
{
    [TestClass]
    public class TestBase
    {
        protected Application WPFApp;

        [TestInitialize]
        public void TestInitialize()
        {
            WPFApp = Application.Launch(@"..\..\UITestAutomation.WPF\bin\UITestAutomation.WPF.exe");
        }

        [TestCleanup]
        public void TestCleanup()
        {
            WPFApp.Close();
        }
    }
}
