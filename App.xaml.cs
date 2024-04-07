using System.Collections.Generic;
using System.Windows;

namespace DocumentEditor
{
    public partial class App : Application
    {
        public static List<Window> ActiveWindows { get; private set; } = new List<Window>();
        public static Window CurrentWindow { get; set; }

        public static void AddCurrentWindow(Window window)
            => ActiveWindows.Add(window);
    }
}