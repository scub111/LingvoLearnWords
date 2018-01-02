using System.Windows.Controls;

namespace LingvoLearnWords
{
    /// <summary>
    /// Interaction logic for CurrentDetail.xaml
    /// </summary>
    public partial class CurrentDetail : UserControl
    {
        public CurrentDetail()
        {
            InitializeComponent();
        }

        private int _value;
        public int Value
        {
            get => _value;
            set
            {
                _value = value;
                teBase.EditValue = _value;
            }
        }
    }
}
