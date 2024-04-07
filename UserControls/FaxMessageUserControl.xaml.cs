using DocumentEditor.UserControls.Template;
using Microsoft.Win32;
using System.Windows;
using System.Windows.Controls;
using static DocumentEditor.Helpers.ResourceHelper;

namespace DocumentEditor.UserControls
{
    public partial class FaxMessageUserControl : UserControl
    {
        public FaxMessageTemplateUserControl FaxMessageTemplateUserControl { get; set; }

        public FaxMessageUserControl()
        {
            InitializeComponent();
            FaxMessageTemplateUserControl = new FaxMessageTemplateUserControl();
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
                FaxMessageTemplateUserControl.LogoImage.Source = ConvertUriToImageSource(selectedFilePath);
            }
        }

        private void DocumentRegisterNumberLinkTextBox_TextChanged(object sender, TextChangedEventArgs e)
            => FaxMessageTemplateUserControl.DocumentRegisterNumberLinkTextBlock.Text = DocumentRegisterNumberLinkTextBox.Text;

        private void DocumentRegisterNumberTextBox_TextChanged(object sender, TextChangedEventArgs e)
            => FaxMessageTemplateUserControl.DocumentRegisterNumberTextBlock.Text = DocumentRegisterNumberTextBox.Text;

        private void DocumentDateTextBox_TextChanged(object sender, TextChangedEventArgs e)
            => FaxMessageTemplateUserControl.DocumentDateTextBlock.Text = DocumentDateTextBox.Text;

        private void BackgroundOrganizationInfoTextBox_TextChanged(object sender, TextChangedEventArgs e) 
            => FaxMessageTemplateUserControl.BackgroundOrganizationInfoTextBlock.Text = BackgroundOrganizationInfoTextBox.Text;

        private void OrganizationNameTextBox_TextChanged(object sender, TextChangedEventArgs e) 
            => FaxMessageTemplateUserControl.OrganizationNameTextBlock.Text = OrganizationNameTextBox.Text;

        private void DocumentFormCodeTextBox_TextChanged(object sender, TextChangedEventArgs e)
            => FaxMessageTemplateUserControl.DocumentFormCodeTextBlock.Text = DocumentFormCodeTextBox.Text;

        private void OrganizationCodeTextBox_TextChanged(object sender, TextChangedEventArgs e)
            => FaxMessageTemplateUserControl.OrganizationCodeTextBlock.Text = OrganizationCodeTextBox.Text;

        private void TitleTextBox_TextChanged(object sender, TextChangedEventArgs e)
            => FaxMessageTemplateUserControl.TitleTextBlock.Text = TitleTextBox.Text;

        private void SignatureIdentificatorTextBox_TextChanged(object sender, TextChangedEventArgs e)
            => FaxMessageTemplateUserControl.SignatureIdentificatorTextBlock.Text = SignatureIdentificatorTextBox.Text;

        private void NoteAvailabilityApplicationTextBox_TextChanged(object sender, TextChangedEventArgs e)
            => FaxMessageTemplateUserControl.NoteAvailabilityApplicationTextBlock.Text = NoteAvailabilityApplicationTextBox.Text;

        private void SubtitleTextBox_TextChanged(object sender, TextChangedEventArgs e)
            => FaxMessageTemplateUserControl.SubtitleTextBlock.Text = SubtitleTextBox.Text;

        private void ResolutionTextBox_TextChanged(object sender, TextChangedEventArgs e)
            => FaxMessageTemplateUserControl.ResolutionTextBlock.Text = ResolutionTextBox.Text;

        private void AddresseeTextBox_TextChanged(object sender, TextChangedEventArgs e)
            => FaxMessageTemplateUserControl.AddresseeTextBlock.Text = AddresseeTextBox.Text;

        private void VultureRestrictionsTextBox_TextChanged(object sender, TextChangedEventArgs e)
            => FaxMessageTemplateUserControl.VultureRestrictionsTextBlock.Text = VultureRestrictionsTextBox.Text;

        private void PerformerMarkTextBox_TextChanged(object sender, TextChangedEventArgs e)
            => FaxMessageTemplateUserControl.PerformerMarkTextBlock.Text = PerformerMarkTextBox.Text;

        private void PerformanceMarkTextBox_TextChanged(object sender, TextChangedEventArgs e)
            => FaxMessageTemplateUserControl.PerformanceMarkTextBlock.Text = PerformanceMarkTextBox.Text;

        private void DocumentReceiptTextBox_TextChanged(object sender, TextChangedEventArgs e)
            => FaxMessageTemplateUserControl.DocumentReceiptTextBlock.Text = DocumentReceiptTextBox.Text;

        private void SignatureTextBox_TextChanged(object sender, TextChangedEventArgs e)
            => FaxMessageTemplateUserControl.SignatureTextBlock.Text = SignatureTextBox.Text;
    }
}