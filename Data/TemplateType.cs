namespace DocumentEditor.Data
{
    public enum TemplateType
    {
        Order,
        FaxMessageCorner,
        FaxMessageCenter
    }

    public static class TemplateTypeExtensions
    {
        public static string GetNameFromType(TemplateType type)
        {
            switch (type)
            {
                case TemplateType.Order:
                    return "Факс-сообщение | Регламент";
                case TemplateType.FaxMessageCorner:
                    return "Факс-сообщение | Угловое расположение";
                case TemplateType.FaxMessageCenter:
                    return "Факс-сообщение | Центрированное расположение";
                default:
                    return "Неизвестно";
            }
        }
    }
}