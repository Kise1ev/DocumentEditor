using DocumentEditor.Data;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Animation;

namespace DocumentEditor.Windows
{
    public partial class TemplateSelectionWindow : Window
    {
        public TemplateSelectionWindow()
        {
            App.CurrentWindow = this;
            App.AddCurrentWindow(this);
            InitializeComponent();
        }

        private void FaxMessageCornerTemplateBorder_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            WindowState = WindowState.Minimized;
            TemplateEditorWindow templateEditorWindow = new TemplateEditorWindow(TemplateType.FaxMessageCorner);
            templateEditorWindow.Show();
        }

        //private void FaxMessageCenterTemplateBorder_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        //{
            //WindowState = WindowState.Minimized;
            //TemplateEditorWindow templateEditorWindow = new TemplateEditorWindow(TemplateType.FaxMessageCenter);
            //templateEditorWindow.Show();
        //}

        private void OrderTemplateBorder_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            WindowState = WindowState.Minimized;
            TemplateEditorWindow templateEditorWindow = new TemplateEditorWindow(TemplateType.Order);
            templateEditorWindow.Show();
        }

        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
            => WindowState = WindowState.Minimized;

        private void CloseButton_Click(object sender, RoutedEventArgs e)
            => Close();

        private void ControlPanel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
            => DragMove();

        //private void QuestionButton_Click(object sender, RoutedEventArgs e)
        //{

        //}

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            e.Cancel = true;

            DoubleAnimation animation = new DoubleAnimation
            {
                From = 1,
                To = 0,
                Duration = TimeSpan.FromSeconds(0.2),
                EasingFunction = new ExponentialEase()
                {
                    EasingMode = EasingMode.EaseInOut,
                    Exponent = 2
                }
            };
            animation.Completed += (a, b) => Application.Current.Shutdown();
            BeginAnimation(OpacityProperty, animation);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DoubleAnimation animation = new DoubleAnimation
            {
                From = 0,
                To = 1,
                Duration = TimeSpan.FromSeconds(0.2),
                EasingFunction = new ExponentialEase()
                {
                    EasingMode = EasingMode.EaseInOut,
                    Exponent = 2
                }
            };
            BeginAnimation(OpacityProperty, animation);
        }
    }
}