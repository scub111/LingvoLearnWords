using System.Windows;

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

        private void ViewBase_Loaded(object sender, RoutedEventArgs e)
        {
            for (var i = 0; i < 3; i++)
            {
                var buttonEx = new ButtonEx();
                buttonEx.Margin = new Thickness(0, i * 100, 0, 0);
                RootLayout.Children.Add(buttonEx);
            }
        }
    }
}
