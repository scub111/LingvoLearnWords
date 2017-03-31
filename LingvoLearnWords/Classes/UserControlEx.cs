using System.Windows;
using System.Windows.Controls;

namespace LingvoLearnWords
{
    /// <summary>
    /// Абстрактрый родительский класс для всех видов.
    /// </summary>
    public abstract class UserControlEx : UserControl
    {
        public UserControlEx()
        {
            Visible = false;
            this.Loaded += UserControlEx_Loaded;
            this.Unloaded += UserControlEx_Unloaded;            
        }

        /// <summary>
        /// Видимость формы.
        /// </summary>
        public bool Visible { get; set; }

        void UserControlEx_Loaded(object sender, RoutedEventArgs e)
        {
            Visible = true;
        }

        void UserControlEx_Unloaded(object sender, RoutedEventArgs e)
        {
            Visible = false;
        }
    }
}
