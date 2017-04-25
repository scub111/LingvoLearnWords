using DevExpress.Xpf.Core;
using System.Windows;
using System.Windows.Controls;

namespace LingvoLearnWords
{
    /// <summary>
    /// Interaction logic for CardView.xaml
    /// </summary>
    public partial class DictionaryView : UserControlEx
    {
        public DictionaryView()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            ((DictionaryViewModel)DataContext).Loaded += DictionaryView_Loaded;
            //DXSplashScreen.Close();
        }

        private void DictionaryView_Loaded(object sender, System.EventArgs e)
        {
            dataGridBase.ItemsSource = null;
            dataGridBase.ItemsSource = ((DictionaryViewModel)DataContext).Cards;
        }
    }
}
