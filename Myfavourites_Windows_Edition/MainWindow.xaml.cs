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

        private string langage = "EN";
        private static List<RoutedCommand> shortCuts = new List<RoutedCommand>();

        public MainWindow() {
            InitializeComponent();
            InitializeMenu();

            CreateShortCut(0, 47, 2, 4, DeleteAll_Click);
            CreateShortCut(1, 62, 2, 0, Save_Click);
            CreateShortCut(2, 62, 2, 4, SaveAs_Click);
            CreateShortCut(3, 59, 2, 0, Print_Click);
            CreateShortCut(4, 69, 2, 0, Undo_Click);
            CreateShortCut(5, 68, 2, 0, Redo_Click);
            CreateShortCut(6, 67, 2, 0, Copy_Click);
            CreateShortCut(7, 65, 2, 0, Paste_Click);
        }

        private void CreateShortCut(int index, int key, int modifier1, int modifier2, ExecutedRoutedEventHandler handler) {
            shortCuts.Add(new RoutedCommand());
            shortCuts[index].InputGestures.Add(new KeyGesture((Key)key, (ModifierKeys)modifier1 | (ModifierKeys)modifier2));
            CommandBindings.Add(new CommandBinding(shortCuts[index], handler));
        }

        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e) {
            ButtonCloseMenu.Visibility = Visibility.Visible;
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
        }

        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e) {
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
            ButtonOpenMenu.Visibility = Visibility.Visible;
        }

        private void InitializeMenu() {
            List<MenuButton> fileList = new List<MenuButton>();
            fileList.Add(new MenuButton("New Playlist", NewPlaylist_Click));
            fileList.Add(new MenuButton("Open Playlist", OpenPlaylist_Click));
            fileList.Add(new MenuButton("Edit Playlist", OpenPlaylist_Click));
            fileList.Add(new MenuButton("Delete All         Ctrl+Shift+D", OpenPlaylist_Click));
            fileList.Add(new MenuButton("Save                   Ctrl+S", Save_Click));
            fileList.Add(new MenuButton("Save As              Ctrl+Shift+S", SaveAs_Click));
            fileList.Add(new MenuButton("Import", Import_Click));
            fileList.Add(new MenuButton("Export", Export_Click));
            fileList.Add(new MenuButton("Print                   Ctrl+P", Print_Click));
            fileList.Add(new MenuButton("Exit", Exit_Click));
            ItemMenu fileMenu = new ItemMenu("Files", fileList, PackIconKind.File);

            List<MenuButton> editList = new List<MenuButton>();
            editList.Add(new MenuButton("Undo                 Ctrl+Z", Undo_Click));
            editList.Add(new MenuButton("Redo                 Ctrl+Y", Redo_Click));
            editList.Add(new MenuButton("Copy                 Ctrl+C", Copy_Click));
            editList.Add(new MenuButton("Cut                    Ctrl+X", Cut_Click));
            editList.Add(new MenuButton("Paste                Ctrl+V", Paste_Click));
            ItemMenu editMenu = new ItemMenu("Edit", editList, PackIconKind.Edit);

            List<MenuButton> settingsList = new List<MenuButton>();
            settingsList.Add(new MenuButton("General", General_Click));
            ItemMenu settingsMenu = new ItemMenu("Settings", settingsList, PackIconKind.Settings);

            ItemMenu help = new ItemMenu("Help", new UserControl(), PackIconKind.Help);

            List<MenuButton> supportList = new List<MenuButton>();
            supportList.Add(new MenuButton("Paypal", Paypal_Click));
            ItemMenu supportMenu = new ItemMenu("Support Us", supportList, PackIconKind.Donate);

            ItemMenu dashboard = new ItemMenu("Dashboard", new UserControl(), PackIconKind.ViewDashboard);

            Menu.Children.Add(new UserControlMenuItem(dashboard));
            Menu.Children.Add(new UserControlMenuItem(fileMenu));
            Menu.Children.Add(new UserControlMenuItem(editMenu));
            Menu.Children.Add(new UserControlMenuItem(settingsMenu));
            Menu.Children.Add(new UserControlMenuItem(help));
            Menu.Children.Add(new UserControlMenuItem(supportMenu));
        }

        private void NewPlaylist_Click(object sender, EventArgs e) {
            Console.WriteLine("Bouton activé");
        }

        private void OpenPlaylist_Click(object sender, EventArgs e) {

        }

        private void EditPlaylist_Click(object sender, EventArgs e) {

        }

        private void DeleteAll_Click(object sender, EventArgs e) {
            Console.WriteLine("Deleting all...");
        }

        private void Save_Click(object sender, EventArgs e) {
            
        }

        private void SaveAs_Click(object sender, EventArgs e) {
            
        }

        private void Import_Click(object sender, EventArgs e) {

        }

        private void Export_Click(object sender, EventArgs e) {

        }

        private void Print_Click(object sender, EventArgs e) {

        }

        private void PrintHTML_Click(object sender, EventArgs e) {

        }

        private void Exit_Click(object sender, EventArgs e) {
            Application.Current.Shutdown();
        }

        private void Undo_Click(object sender, EventArgs e) {

        }

        private void Redo_Click(object sender, EventArgs e) {

        }

        private void Copy_Click(object sender, EventArgs e) {

        }

        private void Cut_Click(object sender, EventArgs e) {

        }

        private void Paste_Click(object sender, EventArgs e) {

        }

        private void General_Click(object sender, EventArgs e) {

        }

        private void Paypal_Click(object sender, EventArgs e) {

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
