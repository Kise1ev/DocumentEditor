using DocumentEditor.UserControls.Template;
using Microsoft.Win32;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using static DocumentEditor.Helpers.ResourceHelper;

namespace DocumentEditor.UserControls
{
    public partial class OrderUserControl : UserControl
    {
        public OrderTemplateUserControl OrderTemplateUserControl { get; set; }

        public OrderUserControl()
        {
            InitializeComponent();
            OrderTemplateUserControl = new OrderTemplateUserControl();
        }

        private void LoadLogoButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Filter = "JPEG Files (*.jpg)|*.jpg|PNG Files (*.png)|*.png"
            };
            bool? result = openFileDialog.ShowDialog();
            if (result == true)
            {
                string selectedFilePath = openFileDialog.FileName;
                OrderTemplateUserControl.LogoImage.Source = ConvertUriToImageSource(selectedFilePath);
            }
        }

        private void ResetLogoButton_Click(object sender, RoutedEventArgs e)
            => OrderTemplateUserControl.LogoImage.Source = null;

        private void SetColor<T>(T control, Brush brush)
        {
            if (control is TextBlock textBlock)
            {
                textBlock.Background = brush;
            }
        }

        private void SetText<T, D>(T control, D setControl)
        {
            if (control is TextBlock textBlock && setControl is TextBox textBox)
            {
                textBlock.Text = textBox.Text;
            }
        }

        private void SetCursive<T>(T control, bool cursive)
        {
            if (control is TextBlock textBlock)
            {
                textBlock.FontStyle = cursive ? FontStyles.Italic : FontStyles.Normal;
            }
        }

        private void SetBold<T>(T control, bool bold)
        {
            if (control is TextBlock textBlock)
            {
                textBlock.FontWeight = bold ? FontWeights.Bold : FontWeights.Normal;
            }
        }

        private void DocumentTypeTextBox_TextChanged(object sender, TextChangedEventArgs e)
            => SetText(OrderTemplateUserControl.DocumentTypeTextBlock, DocumentTypeTextBox);

        private void OrganizationNameTextBox_TextChanged(object sender, TextChangedEventArgs e)
            => SetText(OrderTemplateUserControl.OrganizationNameTextBlock, OrganizationNameTextBox);

        private void DocumentAuthorTextBox_TextChanged(object sender, TextChangedEventArgs e) 
            => SetText(OrderTemplateUserControl.DocumentAuthorTextBlock, DocumentAuthorTextBox);

        private void DocumentDateTextBox_TextChanged(object sender, TextChangedEventArgs e)
            => SetText(OrderTemplateUserControl.DocumentDateTextBlock, DocumentDateTextBox);

        private void DocumentRegisterNumberTextBox_TextChanged(object sender, TextChangedEventArgs e)
            => SetText(OrderTemplateUserControl.DocumentRegisterNumberTextBlock, DocumentRegisterNumberTextBox);

        private void DocumentPlaceTextBox_TextChanged(object sender, TextChangedEventArgs e)
            => SetText(OrderTemplateUserControl.DocumentPlaceTextBlock, DocumentPlaceTextBox);

        private void TitleTextBox_TextChanged(object sender, TextChangedEventArgs e)
            => SetText(OrderTemplateUserControl.TitleTextBlock, TitleTextBox);

        private void OrganizationNameTextBox_LostFocus(object sender, RoutedEventArgs e)
            => SetColor(OrderTemplateUserControl.OrganizationNameTextBlock, Brushes.Transparent);

        private void OrganizationNameTextBox_GotFocus(object sender, RoutedEventArgs e)
            => SetColor(OrderTemplateUserControl.OrganizationNameTextBlock, Brushes.Yellow);

        private void DocumentAuthorTextBox_GotFocus(object sender, RoutedEventArgs e)
            => SetColor(OrderTemplateUserControl.DocumentAuthorTextBlock, Brushes.Yellow);

        private void DocumentAuthorTextBox_LostFocus(object sender, RoutedEventArgs e)
            => SetColor(OrderTemplateUserControl.DocumentAuthorTextBlock, Brushes.Transparent);

        private void DocumentTypeTextBox_GotFocus(object sender, RoutedEventArgs e)
            => SetColor(OrderTemplateUserControl.DocumentTypeTextBlock, Brushes.Yellow);

        private void DocumentTypeTextBox_LostFocus(object sender, RoutedEventArgs e)
            => SetColor(OrderTemplateUserControl.DocumentTypeTextBlock, Brushes.Transparent);

        private void DocumentDateTextBox_GotFocus(object sender, RoutedEventArgs e)
            => SetColor(OrderTemplateUserControl.DocumentDateTextBlock, Brushes.Yellow);

        private void DocumentDateTextBox_LostFocus(object sender, RoutedEventArgs e)
            => SetColor(OrderTemplateUserControl.DocumentDateTextBlock, Brushes.Transparent);

        private void DocumentRegisterNumberTextBox_GotFocus(object sender, RoutedEventArgs e)
            => SetColor(OrderTemplateUserControl.DocumentRegisterNumberTextBlock, Brushes.Yellow);

        private void DocumentRegisterNumberTextBox_LostFocus(object sender, RoutedEventArgs e)
          => SetColor(OrderTemplateUserControl.DocumentRegisterNumberTextBlock, Brushes.Transparent);

        private void DocumentPlaceTextBox_GotFocus(object sender, RoutedEventArgs e)
            => SetColor(OrderTemplateUserControl.DocumentPlaceTextBlock, Brushes.Yellow);

        private void DocumentPlaceTextBox_LostFocus(object sender, RoutedEventArgs e)
            => SetColor(OrderTemplateUserControl.DocumentPlaceTextBlock, Brushes.Transparent);

        private void TitleTextBox_GotFocus(object sender, RoutedEventArgs e)
            => SetColor(OrderTemplateUserControl.TitleTextBlock, Brushes.Yellow);

        private void TitleTextBox_LostFocus(object sender, RoutedEventArgs e)
            => SetColor(OrderTemplateUserControl.TitleTextBlock, Brushes.Transparent);

        private void DocumentRegisterNumberBoldCheckBox_Checked(object sender, RoutedEventArgs e)
            => SetBold(OrderTemplateUserControl.DocumentRegisterNumberTextBlock, true);

        private void DocumentRegisterNumberBoldCheckBox_Unchecked(object sender, RoutedEventArgs e)
            => SetBold(OrderTemplateUserControl.DocumentRegisterNumberTextBlock, false);

        private void DocumentRegisterNumberCursiveCheckBox_Checked(object sender, RoutedEventArgs e)
            => SetCursive(OrderTemplateUserControl.DocumentRegisterNumberTextBlock, true);

        private void DocumentRegisterNumberCursiveCheckBox_Unchecked(object sender, RoutedEventArgs e)
            => SetCursive(OrderTemplateUserControl.DocumentRegisterNumberTextBlock, false);

        private void DocumentPlaceCursiveCheckBox_Checked(object sender, RoutedEventArgs e)
            => SetCursive(OrderTemplateUserControl.DocumentPlaceTextBlock, true);

        private void DocumentPlaceCursiveCheckBox_Unchecked(object sender, RoutedEventArgs e)
            => SetCursive(OrderTemplateUserControl.DocumentPlaceTextBlock, false);

        private void DocumentPlaceBoldCheckBox_Checked(object sender, RoutedEventArgs e)
            => SetBold(OrderTemplateUserControl.DocumentPlaceTextBlock, true);

        private void DocumentPlaceBoldCheckBox_Unchecked(object sender, RoutedEventArgs e)
            => SetBold(OrderTemplateUserControl.DocumentPlaceTextBlock, false);

        private void TitleCursiveCheckBox_Checked(object sender, RoutedEventArgs e)
            => SetCursive(OrderTemplateUserControl.TitleTextBlock, true);

        private void TitleCursiveCheckBox_Unchecked(object sender, RoutedEventArgs e)
            => SetCursive(OrderTemplateUserControl.TitleTextBlock, false);

        private void TitleBoldCheckBox_Checked(object sender, RoutedEventArgs e)
            => SetBold(OrderTemplateUserControl.TitleTextBlock, true);

        private void TitleBoldCheckBox_Unchecked(object sender, RoutedEventArgs e)
            => SetBold(OrderTemplateUserControl.TitleTextBlock, false);

        private void DocumentDateCursiveCheckBox_Checked(object sender, RoutedEventArgs e)
            => SetCursive(OrderTemplateUserControl.DocumentDateTextBlock, true);

        private void DocumentDateCursiveCheckBox_Unchecked(object sender, RoutedEventArgs e)
            => SetCursive(OrderTemplateUserControl.DocumentDateTextBlock, false);

        private void DocumentDateBoldCheckBox_Checked(object sender, RoutedEventArgs e)
            => SetBold(OrderTemplateUserControl.DocumentDateTextBlock, true);

        private void DocumentDateBoldCheckBox_Unchecked(object sender, RoutedEventArgs e)
            => SetBold(OrderTemplateUserControl.DocumentDateTextBlock, false);

        private void DocumentTypeCursiveCheckBox_Checked(object sender, RoutedEventArgs e)
            => SetCursive(OrderTemplateUserControl.DocumentTypeTextBlock, true);

        private void DocumentTypeCursiveCheckBox_Unchecked(object sender, RoutedEventArgs e)
            => SetCursive(OrderTemplateUserControl.DocumentTypeTextBlock, false);

        private void DocumentTypeBoldCheckBox_Checked(object sender, RoutedEventArgs e)
            => SetBold(OrderTemplateUserControl.DocumentTypeTextBlock, true);

        private void DocumentTypeBoldCheckBox_Unchecked(object sender, RoutedEventArgs e)
            => SetBold(OrderTemplateUserControl.DocumentTypeTextBlock, false);

        private void DocumentAuthorCursiveCheckBox_Checked(object sender, RoutedEventArgs e)
            => SetCursive(OrderTemplateUserControl.DocumentAuthorTextBlock, true);

        private void DocumentAuthorCursiveCheckBox_Unchecked(object sender, RoutedEventArgs e)
            => SetCursive(OrderTemplateUserControl.DocumentAuthorTextBlock, false);

        private void DocumentAuthorBoldCheckBox_Checked(object sender, RoutedEventArgs e)
            => SetBold(OrderTemplateUserControl.DocumentAuthorTextBlock, true);

        private void DocumentAuthorBoldCheckBox_Unchecked(object sender, RoutedEventArgs e)
             => SetBold(OrderTemplateUserControl.DocumentAuthorTextBlock, false);

        private void OrganizationNameCursiveCheckBox_Checked(object sender, RoutedEventArgs e)
            => SetCursive(OrderTemplateUserControl.OrganizationNameTextBlock, true);

        private void OrganizationNameCursiveCheckBox_Unchecked(object sender, RoutedEventArgs e)
            => SetCursive(OrderTemplateUserControl.OrganizationNameTextBlock, false);

        private void OrganizationNameBoldCheckBox_Checked(object sender, RoutedEventArgs e)
            => SetBold(OrderTemplateUserControl.OrganizationNameTextBlock, true);

        private void OrganizationNameBoldCheckBox_Unchecked(object sender, RoutedEventArgs e)
            => SetBold(OrderTemplateUserControl.OrganizationNameTextBlock, false);
    }
}