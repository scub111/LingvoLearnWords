using System;
using System.Reflection;
using System.Windows;

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

                /// <summary>
        /// Последний активный вид.
        /// </summary>
        ViewBase viewLastVisible;

        StartView startView;

        DictionaryView dictionaryView;

        /// <summary>
        /// Активизации определенного вида.
        /// </summary>
        T ActivateView<T>(ViewBase view, EventHandler initCallback = null) where T : ViewBase, new()
        {
            if (viewLastVisible != null)
                viewLastVisible.Visibility = Visibility.Hidden;

            if (view == null)
            {
                view = (ViewBase)Activator.CreateInstance(typeof(T));
                //view = new T();

                if (initCallback != null)
                    initCallback(view, EventArgs.Empty);
            }

            if (LayoutRoot.Children.Contains(view))
                view.Visibility = Visibility.Visible;
            else
                LayoutRoot.Children.Add(view);

            viewLastVisible = view;
            return (T)view;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Title += $" {Assembly.GetExecutingAssembly().GetName().Version.ToString()}";

            //startView = ActivateView<StartView>(startView);
            dictionaryView = ActivateView<DictionaryView>(dictionaryView);
        }
    }
}
