using MaterialDesignThemes.Wpf;
using Myfavourites_Windows_Edition;
using System.Collections.Generic;
using System.Windows.Controls;

namespace BeautySolutions.View.ViewModel {
    public class ItemMenu {
        public ItemMenu(string header, UserControl screen, PackIconKind icon) {
            Header = header;
            Screen = screen;
            Icon = icon;
            Buttons = null;
        }

        public ItemMenu(string header, List<MenuButton> buttons, PackIconKind icon) {
            Header = header;
            Buttons = buttons;
            Icon = icon;
            Screen = null;
        }

        public string Header { get; private set; }
        public PackIconKind Icon { get; private set; }
        public List<MenuButton> Buttons { get; private set; }
        public UserControl Screen { get; private set; }
    }
}