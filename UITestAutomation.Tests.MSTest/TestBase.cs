using System.Diagnostics;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UITestAutomation.Tests.MSTest
{
    [TestClass]
    public class TestBase
    {
        protected Process AppProcess;

        [TestInitialize]
        public void TestInitialize()
        {
            var startInfo = new ProcessStartInfo(@"..\..\UITestAutomation.WPF\bin\UITestAutomation.WPF.exe");
            AppProcess = Process.Start(startInfo);

            Thread.Sleep(3000);

        }

        [TestCleanup]
        public void TestCleanup()
        {
            AppProcess?.Kill();
        }
    }
}
