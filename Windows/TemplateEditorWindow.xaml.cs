using DocumentEditor.Data;
using DocumentEditor.UserControls;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.Win32;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using PDFImage = iTextSharp.text.Image;

namespace DocumentEditor.Windows
{
    public partial class TemplateEditorWindow : Window
    {
        private readonly TemplateType _templateType;
        private readonly UserControl _userControl;

        public TemplateEditorWindow(TemplateType templateType)
        {
            try
            {
                App.CurrentWindow = this;
                _templateType = templateType;

                InitializeComponent();
                Topmost = true;

                switch (_templateType)
                {
                    case TemplateType.Order:
                        _userControl = new OrderUserControl();
                        DocumentEditPanel.Children.Add(((OrderUserControl)_userControl).OrderTemplateUserControl);
                        break;
                    case TemplateType.FaxMessageCorner:
                        _userControl = new FaxMessageCornerUserControl();
                        DocumentEditPanel.Children.Add(((FaxMessageCornerUserControl)_userControl).FaxMessageCornerTemplateUserControl);
                        break;
                    //case TemplateType.FaxMessageCenter:
                    //    _userControl = new FaxMessageCenterUserControl();
                    //    DocumentEditPanel.Children.Add(((FaxMessageCenterUserControl)_userControl).FaxMessageCenterTemplateUserControl);
                    //    break;
                    default:
                        Close();
                        throw new InvalidOperationException("Пожалуйста, повторите попытку создания шаблона!");
                }
                TemplateTypeTextBlock.Text = $"Тип документа: {TemplateTypeExtensions.GetNameFromType(_templateType)}";

                _userControl.Margin = new Thickness(20);
                UserControlGrid.Children.Add(_userControl);
            }
            catch (InvalidOperationException exception)
            {
                MessageBox.Show($"Произошла ошибка операции!\n{exception.Message}", "Произошла ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
            => Close();

        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
            => WindowState = WindowState.Minimized;

        //private void QuestionButton_Click(object sender, RoutedEventArgs e)
        //{

        //}

        private void ControlPanel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
            => DragMove();

        private void Window_Closing(object sender, CancelEventArgs e)
        {
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
            animation.Completed += (a, b) =>
            {
                foreach (Window window in App.ActiveWindows)
                {
                    if (window is TemplateSelectionWindow)
                    {
                        window.WindowState = WindowState.Normal;
                        window.Topmost = true;
                        break;
                    }
                }
            };
            BeginAnimation(OpacityProperty, animation);
        }

        private void SaveToPDFButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                UserControl userControl = null;
                switch (_templateType)
                {
                    case TemplateType.Order:
                        userControl = ((OrderUserControl)_userControl).OrderTemplateUserControl;
                        break;
                    case TemplateType.FaxMessageCorner:
                        userControl = ((FaxMessageCornerUserControl)_userControl).FaxMessageCornerTemplateUserControl;
                        break;
                    //case TemplateType.FaxMessageCenter:
                    //    userControl = ((FaxMessageCenterUserControl)_userControl).FaxMessageCenterTemplateUserControl;
                    //    break;
                    default:
                        throw new InvalidOperationException("Пожалуйста, повторите попытку!");
                }

                if (userControl != null)
                {
                    SaveControlToPDF(userControl);
                }
            }
            catch (InvalidOperationException exception)
            {
                MessageBox.Show($"Произошла ошибка операции!\n{exception.Message}\nОбратитесь к администратору!", "Произошла ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception exception)
            {
                MessageBox.Show($"{exception.Message}\nОбратитесь к администратору!", "Произошла неизвестная ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void SaveControlToPDF(UserControl userControl)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog { Filter = "PDF файлы (*.pdf)|*.pdf" };
            if (saveFileDialog.ShowDialog() == true)
            {
                string filePath = saveFileDialog.FileName;
                using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
                {
                    using (Document document = new Document())
                    {
                        PdfWriter writer = PdfWriter.GetInstance(document, fileStream);
                        document.Open();

                        double targetWidth = 1108;
                        double targetHeight = 794;

                        double controlWidth = userControl.ActualWidth;
                        double controlHeight = userControl.ActualHeight;

                        double widthRatio = targetWidth / controlWidth;
                        double heightRatio = targetHeight / controlHeight;

                        double minRatio = Math.Min(widthRatio, heightRatio);

                        double scaledWidth = controlWidth * minRatio;
                        double scaledHeight = controlHeight * minRatio;

                        DrawingVisual visual = new DrawingVisual();
                        using (DrawingContext context = visual.RenderOpen())
                        {
                            VisualBrush visualBrush = new VisualBrush(userControl);
                            context.DrawRectangle(visualBrush, null, new Rect(0, 0, scaledWidth, scaledHeight));
                        }

                        RenderTargetBitmap renderTargetBitmap = new RenderTargetBitmap((int)scaledWidth, (int)scaledHeight, 96, 96, PixelFormats.Pbgra32);
                        renderTargetBitmap.Render(visual);

                        using (MemoryStream memoryStream = new MemoryStream())
                        {
                            BmpBitmapEncoder encoder = new BmpBitmapEncoder();
                            encoder.Frames.Add(BitmapFrame.Create(renderTargetBitmap));
                            encoder.Save(memoryStream);

                            PDFImage image = PDFImage.GetInstance(memoryStream.GetBuffer());
                            image.ScaleToFit((float)targetWidth, (float)targetHeight);
                            document.Add(image);
                        }
                    }

                    MessageBoxResult openPage = MessageBox.Show("Документ был успешно сохранен!\nХотите открыть готовый документ?", "Успешное сохранение!", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (openPage == MessageBoxResult.Yes)
                    {
                        Process.Start("explorer.exe", filePath);
                    }
                }
            }
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