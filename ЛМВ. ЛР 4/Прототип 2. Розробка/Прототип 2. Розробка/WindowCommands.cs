using System.Windows.Input;

namespace Прототип_2._Розробка
{
    public class WindowCommands
    {
        static WindowCommands()
        {
            Clear = new RoutedCommand("Clear", typeof(MainWindow));
            Exit = new RoutedCommand("Exit", typeof(MainWindow));

        }
        public static RoutedCommand Clear { get; set; }
        public static RoutedCommand Exit { get; set; }
    }
}
