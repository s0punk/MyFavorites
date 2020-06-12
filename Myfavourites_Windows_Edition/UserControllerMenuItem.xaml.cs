using BeautySolutions.View.ViewModel;
using System.Windows;
using System.Windows.Controls;

namespace DropDownMenu {
  public partial class UserControlMenuItem : UserControl {
    public UserControlMenuItem(ItemMenu itemMenu) {
            InitializeComponent();
           
            ExpanderMenu.Visibility = itemMenu.Buttons == null ? Visibility.Collapsed : Visibility.Visible;
            ListViewItemMenu.Visibility = itemMenu.Buttons == null ? Visibility.Visible : Visibility.Collapsed;

            DataContext = itemMenu;
        }
  }
}