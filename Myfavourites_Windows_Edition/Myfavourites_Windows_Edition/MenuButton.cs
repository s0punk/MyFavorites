using System.Windows.Controls;

namespace Myfavourites_Windows_Edition {
    public class MenuButton : Button {
        public MenuButton(string name, System.Windows.RoutedEventHandler handler) : base() {
            Content = name;
            Click += new System.Windows.RoutedEventHandler(handler);
        }
    }
}
