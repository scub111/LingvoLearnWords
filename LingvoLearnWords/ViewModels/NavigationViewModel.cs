using DevExpress.Mvvm;
using System;
using System.Windows;
using System.Windows.Input;

namespace LingvoLearnWords
{
    public class NavigationViewModel : ViewModelBase
    {
        public NavigationViewModel()
        {
        }

        private object selectedViewModel;
        public object SelectedViewModel
        {
            get { return selectedViewModel; }
            set { selectedViewModel = value; RaisePropertiesChanged("SelectedViewModel"); }
        }

        #region Commands
        #region DictionaryView
        private DelegateCommand dictionaryViewCommand;

        public ICommand DictionaryViewCommand
        {
            get
            {
                if (dictionaryViewCommand == null)
                    dictionaryViewCommand = new DelegateCommand(() =>
                    {
                        SelectedViewModel = new DictionaryViewModel(
                                new XMLDictionary(@"C:\Users\karnaushenkoSV\AppData\Local\ABBYY\Lingvo\16.0\Dic\TutorDict\Common2016EnRu.xml"));

                    });
                    return dictionaryViewCommand;
            }
        }
        #endregion

        #region Exit
        private DelegateCommand exitCommand;

        public ICommand ExitCommand
        {
            get
            {
                if (exitCommand == null)
                    exitCommand = new DelegateCommand(() =>
                    {
                        Application.Current.Shutdown();
                    });
                return exitCommand;
            }
        }
        #endregion

        #endregion
    }
}
