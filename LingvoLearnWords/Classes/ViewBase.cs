using System.Windows;

namespace LingvoLearnWords
{
    public abstract class ViewBase : UserControlEx
    {
        public ViewBase()
        {
            Loaded += ViewBase_Loaded;
        }

        /// <summary>
        /// Пост-конструктор.
        /// </summary>
        /// <param name="controller"></param>
        public void PostConstructor()
        {
        }

        private void ViewBase_Loaded(object sender, RoutedEventArgs e)
        { 

        }
    }
}
