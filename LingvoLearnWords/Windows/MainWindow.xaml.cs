using System.Reflection;
using System.Windows;
using System.Windows.Input;

namespace LingvoLearnWords
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Title += $" {Assembly.GetExecutingAssembly().GetName().Version.ToString()}";
        }

        private void navPane_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                DragMove();
        }
    }
}
