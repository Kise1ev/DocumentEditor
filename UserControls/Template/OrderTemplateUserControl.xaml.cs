using System.Windows.Controls;
using static DocumentEditor.Helpers.ResourceHelper;

namespace DocumentEditor.UserControls.Template
{
    public partial class OrderTemplateUserControl : UserControl
    {
        public OrderTemplateUserControl()
        {
            InitializeComponent();
            DocumentImage.Source = ConvertBitmapToImageSource(Properties.Resources.Order);
        }
    }
}