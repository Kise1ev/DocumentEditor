using System.Windows.Controls;
using static DocumentEditor.Helpers.ResourceHelper;

namespace DocumentEditor.UserControls.Template
{
    public partial class FaxMessageCornerTemplateUserControl : UserControl
    {
        public FaxMessageCornerTemplateUserControl()
        {
            InitializeComponent();
            DocumentImage.Source = ConvertBitmapToImageSource(Properties.Resources.FaxMessageCorner);
        }
    }
}