using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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

        private int _Value;
        public int Value
        {
            get
            {
                return _Value;
            }
            set
            {
                _Value = value;
                teBase.EditValue = _Value;
            }
        }
    }
}
