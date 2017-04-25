using DevExpress.Xpf.Editors;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace LingvoLearnWords
{
    /// <summary>
    /// Interaction logic for DictionaryView.xaml
    /// </summary>
    public partial class DictionaryView2 : ViewBase
    {
        public DictionaryView2(XMLDictionary xmlDictionary)
        {
            InitializeComponent();
            this.xmlDictionary = xmlDictionary;
        }

        XMLDictionary xmlDictionary;

        private void ViewBase_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            gridControl.ItemsSource = xmlDictionary.Dictionary.Cards;
            //gridControl.View.DataNavigatorButtons = DevExpress.Xpf.Grid.NavigatorButtonType.All;
        }

        private void loadButton_Click(object sender, RoutedEventArgs e)
        {
            xmlDictionary.LoadFromXML();
            gridControl.ItemsSource = null;
            gridControl.ItemsSource = xmlDictionary.Dictionary.Cards;

            //gridControl.RefreshData();
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            xmlDictionary.SaveToXML();
        }
    }
}
