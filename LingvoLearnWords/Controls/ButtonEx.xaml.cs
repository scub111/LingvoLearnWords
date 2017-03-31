using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace LingvoLearnWords
{
    /// <summary>
    /// Interaction logic for HMILabel.xaml
    /// </summary>
    public partial class ButtonEx : UserControlEx
    {
        public ButtonEx()
        {
            InitializeComponent();
            //Foreground = Color.FromRgb(255, 0, 0);
        }

        public Brush FillBrush
        {
            get { return recFill.Fill; }
            set { recFill.Fill = value; }
        }

        public string Text
        {
            get { return txtCaption.Text; }
            set { txtCaption.Text = value; }
        }

        /// <summary>
        /// Цвет кнопки.
        /// </summary>
        public Color Color
        {
            get { return ((LinearGradientBrush)recMouse.Fill).GradientStops[1].Color; }
            set { ((LinearGradientBrush)recMouse.Fill).GradientStops[1].Color = value; }
        }

        /// <summary>
        /// Размер шрифта.
        /// </summary>
        public double CaptionFontSize
        {
            get { return txtCaption.FontSize; }
            set { txtCaption.FontSize = value; }
        }

        /// <summary>
        /// Радиус скругления.
        /// </summary>
        public double RectangleRadius
        {
            get { return recMouse.RadiusX; }
            set { recMouse.RadiusX = recMouse.RadiusY = value; }
        }

        /// <summary>
        /// Событие на отжатие кнопки.
        /// </summary>
        public event EventHandler ClickUp = delegate { };

        /// <summary>
        /// Нажатое состояние
        /// </summary>
        private void PressedState()
        {
            ((LinearGradientBrush)recMouse.Fill).StartPoint = new Point(0.5, 1);
            ((LinearGradientBrush)recMouse.Fill).EndPoint = new Point(0.5, 0);
        }

        /// <summary>
        /// Ненажатоесостояние
        /// </summary>
        private void UnpressedState()
        {
            ((LinearGradientBrush)recMouse.Fill).StartPoint = new Point(0.5, 0);
            ((LinearGradientBrush)recMouse.Fill).EndPoint = new Point(0.5, 1);
        }

        private void HMIBase_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            PressedState();
        }

        private void HMIBase_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            UnpressedState();
            ClickUp(this, EventArgs.Empty);
        }

        private void HMIBase_MouseLeave(object sender, MouseEventArgs e)
        {
            UnpressedState();
            ClickUp(this, EventArgs.Empty);
        }
    }
}
