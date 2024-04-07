using System.Windows.Controls;
using static DocumentEditor.Helpers.ResourceHelper;

namespace DocumentEditor.UserControls.Template
{
    public partial class FaxMessageTemplateUserControl : UserControl
    {
        public FaxMessageTemplateUserControl()
        {
            InitializeComponent();
            DocumentImage.Source = ConvertBitmapToImageSource(Properties.Resources.FaxMessage);
        }
    }
}