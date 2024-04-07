using DocumentEditor.UserControls.Template;
using Microsoft.Win32;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using static DocumentEditor.Helpers.ResourceHelper;

namespace DocumentEditor.UserControls
{
    public partial class FaxMessageCornerUserControl : UserControl
    {
        public FaxMessageCornerTemplateUserControl FaxMessageCornerTemplateUserControl { get; set; }

        public FaxMessageCornerUserControl()
        {
            InitializeComponent();
            FaxMessageCornerTemplateUserControl = new FaxMessageCornerTemplateUserControl();
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
                FaxMessageCornerTemplateUserControl.LogoImage.Source = ConvertUriToImageSource(selectedFilePath);
            }
        }

        private void ResetLogoButton_Click(object sender, RoutedEventArgs e)
            => FaxMessageCornerTemplateUserControl.LogoImage.Source = null;

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

        private void DocumentRegisterNumberLinkTextBox_TextChanged(object sender, TextChangedEventArgs e)
            => SetText(FaxMessageCornerTemplateUserControl.DocumentRegisterNumberLinkTextBlock, DocumentRegisterNumberLinkTextBox);

        private void DocumentRegisterNumberTextBox_TextChanged(object sender, TextChangedEventArgs e)
            => SetText(FaxMessageCornerTemplateUserControl.DocumentRegisterNumberTextBlock, DocumentRegisterNumberTextBox);

        private void DocumentDateTextBox_TextChanged(object sender, TextChangedEventArgs e)
            => SetText(FaxMessageCornerTemplateUserControl.DocumentDateTextBlock, DocumentDateTextBox);

        private void BackgroundOrganizationInfoTextBox_TextChanged(object sender, TextChangedEventArgs e) 
            => SetText(FaxMessageCornerTemplateUserControl.BackgroundOrganizationInfoTextBlock, BackgroundOrganizationInfoTextBox);

        private void OrganizationNameTextBox_TextChanged(object sender, TextChangedEventArgs e) 
            => SetText(FaxMessageCornerTemplateUserControl.OrganizationNameTextBlock, OrganizationNameTextBox);

        private void DocumentFormCodeTextBox_TextChanged(object sender, TextChangedEventArgs e)
            => SetText(FaxMessageCornerTemplateUserControl.DocumentFormCodeTextBlock, DocumentFormCodeTextBox);

        private void OrganizationCodeTextBox_TextChanged(object sender, TextChangedEventArgs e)
            => SetText(FaxMessageCornerTemplateUserControl.OrganizationCodeTextBlock, OrganizationCodeTextBox);

        private void TitleTextBox_TextChanged(object sender, TextChangedEventArgs e)
            => SetText(FaxMessageCornerTemplateUserControl.TitleTextBlock, TitleTextBox);

        private void NoteAvailabilityApplicationTextBox_TextChanged(object sender, TextChangedEventArgs e)
            => SetText(FaxMessageCornerTemplateUserControl.NoteAvailabilityApplicationTextBlock, NoteAvailabilityApplicationTextBox);

        private void SubtitleTextBox_TextChanged(object sender, TextChangedEventArgs e)
            => SetText(FaxMessageCornerTemplateUserControl.SubtitleTextBlock, SubtitleTextBox);

        private void ResolutionTextBox_TextChanged(object sender, TextChangedEventArgs e)
            => SetText(FaxMessageCornerTemplateUserControl.ResolutionTextBlock, ResolutionTextBox);

        private void AddresseeTextBox_TextChanged(object sender, TextChangedEventArgs e)
            => SetText(FaxMessageCornerTemplateUserControl.AddresseeTextBlock, AddresseeTextBox);

        private void VultureRestrictionsTextBox_TextChanged(object sender, TextChangedEventArgs e)
            => SetText(FaxMessageCornerTemplateUserControl.VultureRestrictionsTextBlock, VultureRestrictionsTextBox);

        private void PerformerMarkTextBox_TextChanged(object sender, TextChangedEventArgs e)
            => SetText(FaxMessageCornerTemplateUserControl.PerformerMarkTextBlock, PerformerMarkTextBox);

        private void PerformanceMarkTextBox_TextChanged(object sender, TextChangedEventArgs e)
            => SetText(FaxMessageCornerTemplateUserControl.PerformanceMarkTextBlock, PerformanceMarkTextBox);

        private void DocumentReceiptTextBox_TextChanged(object sender, TextChangedEventArgs e)
            => SetText(FaxMessageCornerTemplateUserControl.DocumentReceiptTextBlock, DocumentReceiptTextBox);

        private void SignatureTextBox_TextChanged(object sender, TextChangedEventArgs e)
            => SetText(FaxMessageCornerTemplateUserControl.SignatureTextBlock, SignatureTextBox);

        private void SignaturePostTextBox_TextChanged(object sender, TextChangedEventArgs e)
            => SetText(FaxMessageCornerTemplateUserControl.SignaturePostTextBlock, SignaturePostTextBox);

        private void DocumentRegisterNumberFromLinkTextBox_TextChanged(object sender, TextChangedEventArgs e)
            => SetText(FaxMessageCornerTemplateUserControl.DocumentRegisterNumberFromLinkTextBlock, DocumentRegisterNumberFromLinkTextBox);

        private void DocumentFormCodeTextBox_GotFocus(object sender, RoutedEventArgs e)
            => SetColor(FaxMessageCornerTemplateUserControl.DocumentFormCodeTextBlock, Brushes.Yellow);

        private void DocumentFormCodeTextBox_LostFocus(object sender, RoutedEventArgs e)
            => SetColor(FaxMessageCornerTemplateUserControl.DocumentFormCodeTextBlock, Brushes.Transparent);

        private void OrganizationCodeTextBox_GotFocus(object sender, RoutedEventArgs e)
            => SetColor(FaxMessageCornerTemplateUserControl.OrganizationCodeTextBlock, Brushes.Yellow);

        private void OrganizationCodeTextBox_LostFocus(object sender, RoutedEventArgs e)
            => SetColor(FaxMessageCornerTemplateUserControl.OrganizationCodeTextBlock, Brushes.Transparent);

        private void OrganizationNameTextBox_GotFocus(object sender, RoutedEventArgs e)
            => SetColor(FaxMessageCornerTemplateUserControl.OrganizationNameTextBlock, Brushes.Yellow);

        private void OrganizationNameTextBox_LostFocus(object sender, RoutedEventArgs e)
            => SetColor(FaxMessageCornerTemplateUserControl.OrganizationNameTextBlock, Brushes.Transparent);

        private void BackgroundOrganizationInfoTextBox_GotFocus(object sender, RoutedEventArgs e)
            => SetColor(FaxMessageCornerTemplateUserControl.BackgroundOrganizationInfoTextBlock, Brushes.Yellow);

        private void BackgroundOrganizationInfoTextBox_LostFocus(object sender, RoutedEventArgs e)
            => SetColor(FaxMessageCornerTemplateUserControl.BackgroundOrganizationInfoTextBlock, Brushes.Transparent);

        private void DocumentDateTextBox_GotFocus(object sender, RoutedEventArgs e)
            => SetColor(FaxMessageCornerTemplateUserControl.DocumentDateTextBlock, Brushes.Yellow);

        private void DocumentDateTextBox_LostFocus(object sender, RoutedEventArgs e)
            => SetColor(FaxMessageCornerTemplateUserControl.DocumentDateTextBlock, Brushes.Transparent);

        private void DocumentRegisterNumberTextBox_GotFocus(object sender, RoutedEventArgs e)
            => SetColor(FaxMessageCornerTemplateUserControl.DocumentRegisterNumberTextBlock, Brushes.Yellow);

        private void DocumentRegisterNumberTextBox_LostFocus(object sender, RoutedEventArgs e)
            => SetColor(FaxMessageCornerTemplateUserControl.DocumentRegisterNumberTextBlock, Brushes.Transparent);

        private void DocumentRegisterNumberLinkTextBox_GotFocus(object sender, RoutedEventArgs e)
            => SetColor(FaxMessageCornerTemplateUserControl.DocumentRegisterNumberLinkTextBlock, Brushes.Yellow);

        private void DocumentRegisterNumberLinkTextBox_LostFocus(object sender, RoutedEventArgs e)
            => SetColor(FaxMessageCornerTemplateUserControl.DocumentRegisterNumberLinkTextBlock, Brushes.Transparent);

        private void VultureRestrictionsTextBox_GotFocus(object sender, RoutedEventArgs e)
            => SetColor(FaxMessageCornerTemplateUserControl.VultureRestrictionsTextBlock, Brushes.Yellow);

        private void VultureRestrictionsTextBox_LostFocus(object sender, RoutedEventArgs e)
            => SetColor(FaxMessageCornerTemplateUserControl.VultureRestrictionsTextBlock, Brushes.Transparent);

        private void AddresseeTextBox_GotFocus(object sender, RoutedEventArgs e)
            => SetColor(FaxMessageCornerTemplateUserControl.AddresseeTextBlock, Brushes.Yellow);

        private void AddresseeTextBox_LostFocus(object sender, RoutedEventArgs e)
            => SetColor(FaxMessageCornerTemplateUserControl.AddresseeTextBlock, Brushes.Transparent);

        private void ResolutionTextBox_GotFocus(object sender, RoutedEventArgs e)
            => SetColor(FaxMessageCornerTemplateUserControl.ResolutionTextBlock, Brushes.Yellow);

        private void ResolutionTextBox_LostFocus(object sender, RoutedEventArgs e)
            => SetColor(FaxMessageCornerTemplateUserControl.ResolutionTextBlock, Brushes.Transparent);

        private void TitleTextBox_GotFocus(object sender, RoutedEventArgs e)
            => SetColor(FaxMessageCornerTemplateUserControl.TitleTextBlock, Brushes.Yellow);

        private void TitleTextBox_LostFocus(object sender, RoutedEventArgs e)
            => SetColor(FaxMessageCornerTemplateUserControl.TitleTextBlock, Brushes.Transparent);

        private void SubtitleTextBox_GotFocus(object sender, RoutedEventArgs e)
            => SetColor(FaxMessageCornerTemplateUserControl.SubtitleTextBlock, Brushes.Yellow);

        private void SubtitleTextBox_LostFocus(object sender, RoutedEventArgs e)
            => SetColor(FaxMessageCornerTemplateUserControl.SubtitleTextBlock, Brushes.Transparent);

        private void NoteAvailabilityApplicationTextBox_GotFocus(object sender, RoutedEventArgs e)
            => SetColor(FaxMessageCornerTemplateUserControl.NoteAvailabilityApplicationTextBlock, Brushes.Yellow);

        private void NoteAvailabilityApplicationTextBox_LostFocus(object sender, RoutedEventArgs e)
            => SetColor(FaxMessageCornerTemplateUserControl.NoteAvailabilityApplicationTextBlock, Brushes.Transparent);

        private void SignatureTextBox_GotFocus(object sender, RoutedEventArgs e)
            => SetColor(FaxMessageCornerTemplateUserControl.SignatureTextBlock, Brushes.Yellow);

        private void SignatureTextBox_LostFocus(object sender, RoutedEventArgs e)
            => SetColor(FaxMessageCornerTemplateUserControl.SignatureTextBlock, Brushes.Transparent);

        private void PerformerMarkTextBox_GotFocus(object sender, RoutedEventArgs e)
            => SetColor(FaxMessageCornerTemplateUserControl.PerformerMarkTextBlock, Brushes.Yellow);

        private void PerformerMarkTextBox_LostFocus(object sender, RoutedEventArgs e)
            => SetColor(FaxMessageCornerTemplateUserControl.PerformerMarkTextBlock, Brushes.Transparent);

        private void PerformanceMarkTextBox_GotFocus(object sender, RoutedEventArgs e)
            => SetColor(FaxMessageCornerTemplateUserControl.PerformanceMarkTextBlock, Brushes.Yellow);

        private void PerformanceMarkTextBox_LostFocus(object sender, RoutedEventArgs e)
            => SetColor(FaxMessageCornerTemplateUserControl.PerformanceMarkTextBlock, Brushes.Transparent);

        private void DocumentReceiptTextBox_GotFocus(object sender, RoutedEventArgs e)
            => SetColor(FaxMessageCornerTemplateUserControl.DocumentReceiptTextBlock, Brushes.Yellow);

        private void DocumentReceiptTextBox_LostFocus(object sender, RoutedEventArgs e)
            => SetColor(FaxMessageCornerTemplateUserControl.DocumentReceiptTextBlock, Brushes.Transparent);

        private void SignatureIdentificatorTextBox_GotFocus(object sender, RoutedEventArgs e)
            => SetColor(FaxMessageCornerTemplateUserControl.SignatureIdentificatorTextBlock, Brushes.Yellow);

        private void SignatureIdentificatorTextBox_LostFocus(object sender, RoutedEventArgs e)
            => SetColor(FaxMessageCornerTemplateUserControl.SignatureIdentificatorTextBlock, Brushes.Transparent);

        private void SignaturePostTextBox_GotFocus(object sender, RoutedEventArgs e)
            => SetColor(FaxMessageCornerTemplateUserControl.SignaturePostTextBlock, Brushes.Yellow);

        private void SignaturePostTextBox_LostFocus(object sender, RoutedEventArgs e)
            => SetColor(FaxMessageCornerTemplateUserControl.SignaturePostTextBlock, Brushes.Transparent);

        private void DocumentRegisterNumberFromLinkTextBox_GotFocus(object sender, RoutedEventArgs e)
            => SetColor(FaxMessageCornerTemplateUserControl.DocumentRegisterNumberFromLinkTextBlock, Brushes.Yellow);

        private void DocumentRegisterNumberFromLinkTextBox_LostFocus(object sender, RoutedEventArgs e)
            => SetColor(FaxMessageCornerTemplateUserControl.DocumentRegisterNumberFromLinkTextBlock, Brushes.Transparent);
    }
}