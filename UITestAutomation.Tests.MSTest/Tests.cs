using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows.Automation;

namespace UITestAutomation.Tests.MSTest
{
    [TestClass]
    public class Tests : TestBase
    {
        [TestMethod]
        public void InitialOpening()
        {
        }

        [TestMethod]
        public void Check_ResultTextBlock_changed_on_button_click()
        {
            var Window = AutomationElement.RootElement.FindFirst
                (TreeScope.Children, new PropertyCondition(AutomationElement.ProcessIdProperty, AppProcess.Id));

            var TextBlock = Window.FindFirst
               (TreeScope.Descendants, new PropertyCondition(AutomationElement.AutomationIdProperty, "ResultTextBlock_AutomationId"));

            Assert.IsTrue(TextBlock.Current.Name.Equals(string.Empty));

            var Button = Window.FindFirst
                (TreeScope.Descendants, new PropertyCondition(AutomationElement.AutomationIdProperty, "ClickButton_AutomationId"));
            var ButtonPattern = Button.GetCurrentPattern(InvokePattern.Pattern) as InvokePattern;

            ButtonPattern.Invoke();

            Assert.IsFalse(TextBlock.Current.Name.Equals(string.Empty));
        }

        [TestMethod]
        public void Can_EditTexBox()
        {
            var Window = AutomationElement.RootElement.FindFirst
                (TreeScope.Children, new PropertyCondition(AutomationElement.ProcessIdProperty, AppProcess.Id));

            var TextBox = Window.FindFirst
               (TreeScope.Descendants, new PropertyCondition(AutomationElement.AutomationIdProperty, "ResultTextBox_AutomationId"));

            var TextboxValuePattern = TextBox.GetCurrentPattern(ValuePattern.Pattern) as ValuePattern;

            Assert.IsTrue(TextboxValuePattern.Current.Value.Equals(string.Empty));

            var insertedValue = "Test value 1";
            TextboxValuePattern.SetValue(insertedValue);

            Assert.IsTrue(TextboxValuePattern.Current.Value.Equals(insertedValue));

        }
    }
}
