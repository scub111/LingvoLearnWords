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
            this.DataContext = new NavigationViewModel();
        }

        XMLDictionary xmlDictionary;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Title += $" {Assembly.GetExecutingAssembly().GetName().Version.ToString()}";

            //xmlDictionary = new XMLDictionary(@"C:\Users\Admin\AppData\Local\ABBYY\Lingvo\16.0\Dic\TutorDict\Common2016EnRu.xml");
            xmlDictionary = new XMLDictionary(@"C:\Users\KarnaushenkoSV\AppData\Local\ABBYY\Lingvo\16.0\Dic\TutorDict\Common2016EnRu.xml");
            //xmlDictionary = new XMLDictionary(@"Common2016EnRu.xml");
            //xmlDictionary.LoadFromXML();

            ///DictionaryViewCall();
            /*
            Collection<Card> cardDeleting = new Collection<Card>();

            for (int i = 1; i < xmlDictionary.Dictionary.Cards.Count; i++)
                cardDeleting.Add(xmlDictionary.Dictionary.Cards[i]);

            foreach (var cardRemove in cardDeleting)
                xmlDictionary.Dictionary.Cards.Remove(cardRemove);
                */

            //xmlDictionary.SaveToXML();
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            DictionaryViewModel dictionaryViewModel = new DictionaryViewModel(xmlDictionary);
            DictionaryView cardView = new DictionaryView();
            cardView.DataContext = dictionaryViewModel;
            //BaseFrame.Navigate(cardView);

            //BaseFrame.Navigate(new DictionaryView(xmlDictionary));
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            //if (BaseFrame.CanGoBack)
            //    BaseFrame.GoBack();
        }

        private void ForwardButton_Click(object sender, RoutedEventArgs e)
        {
            //if (BaseFrame.CanGoForward)
            //    BaseFrame.GoForward();
        }

        private void navPane_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }
    }
}
