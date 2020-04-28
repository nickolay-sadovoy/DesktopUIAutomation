using System.Windows;

namespace UITestAutomation.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var text = "Text from button";
            this.ResultTextBlock.Text = text;
            this.ResultTextBox.Text = text;
        }
    }
}
