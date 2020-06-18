using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Linq;
using BeautySolutions.View.ViewModel;
using MaterialDesignThemes.Wpf;
using System.Windows.Controls;
using DropDownMenu;
using System.Windows.Input;

namespace Myfavourites_Windows_Edition {
    public partial class MainWindow : Window {
       // private List<Playlist> playlists;
        private List<SystemApplication> systemApps;
        private List<SteamGame> steamGames;
        // private Playlist selectedPlaylist;

        private static List<UIElement> startPage;

        private string langage = "EN";
        private static List<RoutedCommand> shortCuts = new List<RoutedCommand>();

        public MainWindow() {
            InitializeComponent();
            InitializeMenu();

            SetShortCuts();
            SetStartPage();
            SetStartPageState(false); // Dev purposes -- remove this line when all page's designs are done.

            startPage_linkNewPlaylist.PreviewMouseDown += NewPlaylist_Click;
            startPage_linkLoadPlaylist.PreviewMouseDown += OpenPlaylist_Click;
            startPage_linkImportPlaylist.PreviewMouseDown += Import_Click;
        }

        private void SetShortCuts() {
            CreateShortCut(0, 47, 2, 4, DeleteAll_Click);
            CreateShortCut(1, 62, 2, 0, Save_Click);
            CreateShortCut(2, 62, 2, 4, SaveAs_Click);
            CreateShortCut(3, 59, 2, 0, Print_Click);
            CreateShortCut(4, 69, 2, 0, Undo_Click);
            CreateShortCut(5, 68, 2, 0, Redo_Click);
            CreateShortCut(6, 67, 2, 0, Copy_Click);
            CreateShortCut(7, 65, 2, 0, Paste_Click);
        }

        private void SetStartPage() {
            startPage = new List<UIElement>();

            startPage.Add(startPage_title);
            startPage.Add(startPage_text1);
            startPage.Add(startPage_text2);
            startPage.Add(startPage_linkNewPlaylist);
            startPage.Add(startPage_linkLoadPlaylist);
            startPage.Add(startPage_linkImportPlaylist);
        }

        private static void SetStartPageState(bool state) {
            foreach (UIElement element in startPage) {
                if (state)
                    element.Visibility = Visibility.Visible;
                else
                    element.Visibility = Visibility.Collapsed;
                element.IsEnabled = state;
            }
        }

        private void CreateShortCut(int index, int key, int modifier1, int modifier2, ExecutedRoutedEventHandler handler) {
            shortCuts.Add(new RoutedCommand());
            shortCuts[index].InputGestures.Add(new KeyGesture((Key)key, (ModifierKeys)modifier1 | (ModifierKeys)modifier2));
            CommandBindings.Add(new CommandBinding(shortCuts[index], handler));
        }

        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e) {
            ButtonCloseMenu.Visibility = Visibility.Visible;
            ButtonOpenMenu.Visibility = Visibility.Collapsed;

            foreach (UserControlMenuItem item in Menu.Children)
                if (item.Item.Buttons != null)
                    item.ExpanderMenu.Visibility = Visibility.Visible;
        }

        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e) {
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
            ButtonOpenMenu.Visibility = Visibility.Visible;

            foreach (UserControlMenuItem item in Menu.Children)
                item.ExpanderMenu.Visibility = Visibility.Collapsed;
        }

        private void TextBox_KeyUp(object sender, KeyEventArgs e) {
            if (e.Key == Key.Enter) {
                Keyboard.ClearFocus();
            }
        }

        private void InitializeMenu() {
            List<MenuButton> fileList = new List<MenuButton>();
            fileList.Add(new MenuButton("New Playlist"));
            fileList.Add(new MenuButton("Open Playlist"));
            fileList.Add(new MenuButton("Edit Playlist"));
            fileList.Add(new MenuButton("Delete All         Ctrl+Shift+D"));
            fileList.Add(new MenuButton("Save                   Ctrl+S"));
            fileList.Add(new MenuButton("Save As              Ctrl+Shift+S"));
            fileList.Add(new MenuButton("Import Playlist"));
            fileList.Add(new MenuButton("Export Playlist"));
            fileList.Add(new MenuButton("Print                   Ctrl+P"));
            fileList.Add(new MenuButton("Exit"));
            ItemMenu fileMenu = new ItemMenu("Files", fileList, PackIconKind.File);

            List<MenuButton> editList = new List<MenuButton>();
            editList.Add(new MenuButton("Undo                 Ctrl+Z"));
            editList.Add(new MenuButton("Redo                 Ctrl+Y"));
            editList.Add(new MenuButton("Copy                 Ctrl+C"));
            editList.Add(new MenuButton("Cut                    Ctrl+X"));
            editList.Add(new MenuButton("Paste                Ctrl+V"));
            ItemMenu editMenu = new ItemMenu("Edit", editList, PackIconKind.Edit);

            List<MenuButton> settingsList = new List<MenuButton>();
            settingsList.Add(new MenuButton("General"));
            ItemMenu settingsMenu = new ItemMenu("Settings", settingsList, PackIconKind.Settings);

            ItemMenu help = new ItemMenu("Help", new UserControl(), PackIconKind.Help);

            List<MenuButton> supportList = new List<MenuButton>();
            supportList.Add(new MenuButton("Paypal"));
            ItemMenu supportMenu = new ItemMenu("Support Us", supportList, PackIconKind.Donate);

            ItemMenu dashboard = new ItemMenu("Dashboard", new UserControl(), PackIconKind.ViewDashboard);

            Menu.Children.Add(new UserControlMenuItem(dashboard));
            Menu.Children.Add(new UserControlMenuItem(fileMenu));
            Menu.Children.Add(new UserControlMenuItem(editMenu));
            Menu.Children.Add(new UserControlMenuItem(settingsMenu));
            Menu.Children.Add(new UserControlMenuItem(help));
            Menu.Children.Add(new UserControlMenuItem(supportMenu));
        }

        public static void Help_Click(object sender, EventArgs e) {

        }

        public static void DashBoard_Click(object sender, EventArgs e) {

        }

        public static void NewPlaylist_Click(object sender, EventArgs e) {
            SetStartPageState(false);

        }

        public static void OpenPlaylist_Click(object sender, EventArgs e) {

        }

        public static void EditPlaylist_Click(object sender, EventArgs e) {

        }

        public static void DeleteAll_Click(object sender, EventArgs e) {
            Console.WriteLine("Deleting all...");
        }

        public static void Save_Click(object sender, EventArgs e) {
            
        }

        public static void SaveAs_Click(object sender, EventArgs e) {
            
        }

        public static void Import_Click(object sender, EventArgs e) {

        }

        public static void Export_Click(object sender, EventArgs e) {

        }

        public static void Print_Click(object sender, EventArgs e) {

        }

        public static void Exit_Click(object sender, EventArgs e) {
            Application.Current.Shutdown();
        }

        public static void Undo_Click(object sender, EventArgs e) {

        }

        public static void Redo_Click(object sender, EventArgs e) {

        }

        public static void Copy_Click(object sender, EventArgs e) {

        }

        public static void Cut_Click(object sender, EventArgs e) {

        }

        public static void Paste_Click(object sender, EventArgs e) {

        }

        public static void General_Click(object sender, EventArgs e) {

        }

        public static void Paypal_Click(object sender, EventArgs e) {

        }

        private void GetSystemApplication() {
            systemApps = new List<SystemApplication>();
            string registry_key = @"SOFTWARE\WOW6432Node\Microsoft\Windows\CurrentVersion\Uninstall";
            using (RegistryKey key = Registry.LocalMachine.OpenSubKey(registry_key))
                foreach (string subkey_name in key.GetSubKeyNames())
                    using (RegistryKey subkey = key.OpenSubKey(subkey_name)) {
                        try {
                            systemApps.Add(new SystemApplication((subkey.GetValue("DisplayName")).ToString()));
                        }
                        catch (NullReferenceException) {
                        }
                    }
            GetSteamGames();
        }

        private void GetSteamGames() {
            string path = "C:\\Program Files (x86)\\Steam\\steamapps\\libraryfolders.vdf";
            DirectoryInfo taskDirectory;
            int counter = 0;

            if (File.Exists(path)) {
                steamGames = new List<SteamGame>();
                string[] fileContent = File.ReadAllLines(path);

                foreach (string line in fileContent)
                    counter++;
                for (int i = 4; i < counter - 1; i++) {
                    fileContent[i] = fileContent[i].Substring(6 + i.ToString().Length);
                    fileContent[i] = fileContent[i].Substring(0, fileContent[i].Length - 1);
                    fileContent[i] += "\\steamapps\\";

                    taskDirectory = new DirectoryInfo(fileContent[i]);
                    foreach (var file in taskDirectory.GetFiles("appmanifest_*.acf")) {
                        List<string> lines = File.ReadLines(fileContent[i] + file.Name).Take(5).ToList();
                        string appID = lines[2].Substring(11);
                        string name = lines[4].Substring(10);

                        name = name.Substring(0, name.Length - 1);
                        appID = appID.Substring(0, appID.Length - 1);

                        SteamGame game = new SteamGame(appID, name);
                        steamGames.Add(game);
                    }
                }
            }
        }

        private string Langage {
            get { return langage; }
            set {
                if (value == "En" || value == "FR")
                    langage = value;
            }
        }
    }
}