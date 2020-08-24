using BeautySolutions.View.ViewModel;
using System;
using System.Windows;
using System.Windows.Controls;
using Myfavourites_Windows_Edition;

namespace DropDownMenu {
    public partial class UserControlMenuItem : UserControl {
        public ItemMenu itemMenu;
        
        public UserControlMenuItem(ItemMenu _itemMenu) {
            InitializeComponent();
            itemMenu = _itemMenu;
  
            ExpanderMenu.Visibility = itemMenu.Buttons == null ? Visibility.Collapsed : Visibility.Visible;
            ListViewItemMenu.Visibility = itemMenu.Buttons == null ? Visibility.Visible : Visibility.Collapsed;

            DataContext = itemMenu;
        }

        private void EventManager(object sender, EventArgs e) {
            TextBlock element = (TextBlock)sender;
            switch(element.Text) {
                case "New Playlist":
                    MainWindow.NewPlaylist_Click(null, null);
                    break;
                case "Open Playlist":
                    MainWindow.OpenPlaylist_Click(null, null);
                    break;
                case "Edit Playlist":
                    MainWindow.EditPlaylist_Click(null, null);
                    break;
                case "Delete All         Ctrl+Shift+D":
                    MainWindow.DeleteAll_Click(null, null);
                    break;
                case "Import Playlist":
                    MainWindow.Import_Click(null, null);
                    break;
                case "Export Playlist":
                    MainWindow.Export_Click(null, null);
                    break;
                case "Print                   Ctrl+P":
                    MainWindow.Print_Click(null, null);
                    break;
                case "Exit":
                    MainWindow.Exit_Click(null, null);
                    break;
                case "General":
                    MainWindow.General_Click(null, null);
                    break;
                case "Help":
                    MainWindow.Help_Click(null, null);
                    break;
                case "Paypal":
                    MainWindow.Paypal_Click(null, null);
                    break;
                default:
                    MainWindow.DashBoard_Click(null, null);
                    break;
            }
        }

        public ItemMenu Item {
            get { return itemMenu; }
            set { itemMenu = value; }
        }
    }
}