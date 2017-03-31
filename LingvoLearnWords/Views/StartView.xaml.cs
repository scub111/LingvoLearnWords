using System.Windows;
using System.Windows.Controls;

namespace LingvoLearnWords
{
    /// <summary>
    /// Interaction logic for StartView.xaml
    /// </summary>
    public partial class StartView : ViewBase
    {
        public StartView()
        {
            InitializeComponent();
        }

        private void ViewBase_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            for (int i = 0; i < 3; i++)
            {
                ButtonEx buttonEx = new ButtonEx();
                buttonEx.Margin = new Thickness(0, i * 100, 0, 0);
                RootLayout.Children.Add(buttonEx);
            }
        }
    }
}
