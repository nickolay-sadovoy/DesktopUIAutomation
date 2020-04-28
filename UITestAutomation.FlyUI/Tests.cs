using System;
using System.Threading;
using FlaUI.Core.AutomationElements;
using FlaUI.UIA3;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UITestAutomation.FlyUI
{
    [TestClass]
    public class Tests : TestBase
    {
        [TestMethod]
        public void Check_ResultTextBlock_changed_on_button_click()
        {
            using (var automation = new UIA3Automation())
            {
                var window = WPFApp.GetMainWindow(automation);

                var TextBlock = window.FindFirstDescendant(element => element.ByAutomationId("ResultTextBlock_AutomationId"))?.AsLabel();

                Assert.IsTrue(TextBlock.Text.Equals(string.Empty));

                var Button = window.FindFirstDescendant(element => element.ByAutomationId("ClickButton_AutomationId"))?.AsButton();
                Button.Invoke();

                Thread.Sleep(300);

                Assert.IsFalse(TextBlock.Text.Equals(string.Empty));
            }
        }

        [TestMethod]
        public void Can_EditTexBox()
        {
            using (var automation = new UIA3Automation())
            {
                var window = WPFApp.GetMainWindow(automation);

                var insertedValue = "Test value 1";

                var TextBox = window.FindFirstDescendant(element => element.ByAutomationId("ResultTextBox_AutomationId"))?.AsTextBox();

                Assert.IsTrue(TextBox.Text.Equals(string.Empty));

                TextBox.Text = insertedValue;

                Assert.IsTrue(TextBox.Text.Equals(insertedValue));
            }

        }
    }
}
