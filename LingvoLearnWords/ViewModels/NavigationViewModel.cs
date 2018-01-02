using System.Windows;
using DevExpress.Mvvm.POCO;

namespace LingvoLearnWords
{
    //[POCOViewModel]
    public class NavigationViewModel 
    {
        protected NavigationViewModel()
        {
        }

        public static NavigationViewModel Create()
        {
            return ViewModelSource.Create(() => new NavigationViewModel());
        }

        public virtual object SelectedViewModel { get; set; }

        #region Commands

        public void DictionaryView()
        {
            //DXSplashScreen.Show<SplashScreenView>();
            SelectedViewModel = new DictionaryViewModel(
                new XmlDictionary(@"C:\Users\Admin\AppData\Local\ABBYY\Lingvo\16.0\Dic\TutorDict\Common2016EnRu.xml"));
            //Thread.Sleep(3000);
        }

        public void Exit()
        {
            Application.Current.Shutdown();
        }
        #endregion

    }
}
