using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace LingvoLearnWords
{
    /// <summary>
    /// Interaction logic for HMILabel.xaml
    /// </summary>
    [DefaultEvent("ClickDown")]
    public partial class ButtonEx
    {
        public ButtonEx()
        {
            InitializeComponent();
            //Foreground = Color.FromRgb(255, 0, 0);
        }

        public Brush FillBrush
        {
            get => recFill.Fill;
            set => recFill.Fill = value;
        }

        public string Text
        {
            get => txtCaption.Text;
            set => txtCaption.Text = value;
        }

        /// <summary>
        /// Цвет кнопки.
        /// </summary>
        public Color Color
        {
            get => ((LinearGradientBrush)recMouse.Fill).GradientStops[1].Color;
            set => ((LinearGradientBrush)recMouse.Fill).GradientStops[1].Color = value;
        }

        /// <summary>
        /// Размер шрифта.
        /// </summary>
        public double CaptionFontSize
        {
            get => txtCaption.FontSize;
            set => txtCaption.FontSize = value;
        }

        /// <summary>
        /// Радиус скругления.
        /// </summary>
        public double RectangleRadius
        {
            get => recMouse.RadiusX;
            set => recMouse.RadiusX = recMouse.RadiusY = value;
        }
        
        /// <summary>
        /// Событие на нажатие кнопки.
        /// </summary>
        public event EventHandler ClickDown = delegate { };


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
            ClickDown(this, EventArgs.Empty);
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
