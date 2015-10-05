namespace BalloonsPop.GraphicUserInterface
{
    using System;
    using System.Windows;

    /// <summary>
    /// Interaction logic for PromptWindow.xaml
    /// </summary>
    public partial class PromptWindow : Window
    {
        private string userName;

        public PromptWindow()
        {
            this.InitializeComponent();
        }

        public string UserName
        {
            get
            {
                return this.userName;
            }
        }

        private void Close(object sender, RoutedEventArgs e)
        {
            this.userName = this.UsernameTextBox.Text;
            this.Close();
        }
    }
}
