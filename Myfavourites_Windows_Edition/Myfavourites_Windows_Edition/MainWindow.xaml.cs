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
using System.Management.Automation;

namespace Myfavourites_Windows_Edition {
    public partial class MainWindow : Window {
       // private List<Playlist> playlists;
        private static List<SystemApplication> systemApps;
        private static List<SteamGame> steamGames;
        private static List<WebPage> webPages;

        private static string[] publisherBlacklist;

        private static List<UIElement> startPage;
        private static List<UIElement> playlistPage;

        private string langage = "EN";
        private bool firstLoad = true;

        private static StackPanel listElement;

        public MainWindow() {
            InitializeComponent();
            InitializeMenu();

            GetConfig();

            SetStartPage();
            SetPlaylistPage();

            SetPageState(startPage, false); // Dev purposes -- remove this line when all page's designs are done. // all pages set to false except startpage
            SetPageState(playlistPage, true); 

            startPage_linkNewPlaylist.PreviewMouseDown += NewPlaylist_Click;
            startPage_linkLoadPlaylist.PreviewMouseDown += OpenPlaylist_Click;
            startPage_linkImportPlaylist.PreviewMouseDown += Import_Click;

            publisherBlacklist = File.ReadAllLines("Details\\Publisher_Blacklist.txt");

            if(FirstLoad)
                GetSystemApplication();
            else {

            }
        }

        private void GetConfig() {
            string[] content = File.ReadAllLines("General\\Config.cfg");

            try {
                FirstLoad = content[0] == "FALSE" ? false : true;
                Langage = content[1];
            }
            catch(IndexOutOfRangeException) {
                LoadDefaultConfig();
            }
        }

        private void LoadDefaultConfig() {

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

        private void SetPlaylistPage() {
            playlistPage = new List<UIElement>();

            playlistPage.Add(newPlaylist_name);
            playlistPage.Add(newPlaylist_checkbox);
            playlistPage.Add(newPlaylist_play);
            playlistPage.Add(newPlaylist_newApp);
            playlistPage.Add(newPlaylist_newWebpage);
            playlistPage.Add(newPlaylist_filter);
            playlistPage.Add(newPlaylist_filter1);
            playlistPage.Add(newPlaylist_filter2);
            playlistPage.Add(newPlaylist_scrollList);

            listElement = new StackPanel();
            Thickness margin = listElement.Margin;
            margin.Left = 10;
            listElement.Margin = margin;

            newPlaylist_scrollList.Content = listElement;
        }

        private static void SetPageState(List<UIElement> page, bool state) {
            foreach (UIElement element in page) {
                if (state)
                    element.Visibility = Visibility.Visible;
                else
                    element.Visibility = Visibility.Collapsed;
                element.IsEnabled = state;
            }
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

        private void NewPlaylist_newApp_Click(object sender, RoutedEventArgs e) {
            listElement.Children.Add(new PlaylistElement("Application"));
        }

        private void NewPlaylist_newWebpage_Click(object sender, RoutedEventArgs e) {
            listElement.Children.Add(new PlaylistElement("Web"));
        }

        private void InitializeMenu() {
            List<MenuButton> fileList = new List<MenuButton>();
            fileList.Add(new MenuButton("New Playlist"));
            fileList.Add(new MenuButton("Open Playlist")); // open dashboard    
            fileList.Add(new MenuButton("Import Playlist"));
            fileList.Add(new MenuButton("Export Playlist"));
            ItemMenu fileMenu = new ItemMenu("Files", fileList, PackIconKind.File);

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
            Menu.Children.Add(new UserControlMenuItem(settingsMenu));
            Menu.Children.Add(new UserControlMenuItem(help));
            Menu.Children.Add(new UserControlMenuItem(supportMenu));
        }

        public static void Help_Click(object sender, EventArgs e) {
            
        }

        public static void DashBoard_Click(object sender, EventArgs e) {

        }

        public static void NewPlaylist_Click(object sender, EventArgs e) {
            SetPageState(startPage, false);
            SetPageState(playlistPage, true);
        }

        public static void OpenPlaylist_Click(object sender, EventArgs e) {

        }

        public static void EditPlaylist_Click(object sender, EventArgs e) {

        }

        public static void DeleteAll_Click(object sender, EventArgs e) {
            Console.WriteLine("Deleting all...");
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

        public static void General_Click(object sender, EventArgs e) {

        }

        public static void Paypal_Click(object sender, EventArgs e) {

        }

        private void GetSystemApplication() {
            string command = "Get-ItemProperty HKLM:\\Software\\Wow6432Node\\Microsoft\\Windows\\CurrentVersion\\Uninstall\\*" +
                " | Select-Object DisplayName, DisplayVersion, Publisher | Format-List > Details\\Installed_Programs.txt";
            systemApps = new List<SystemApplication>();

            PowerShell ps = PowerShell.Create();
            ps.AddScript(command);
            ps.Invoke();

            systemApps = new List<SystemApplication>();
            TreatApps("Details\\Installed_Programs.txt");
            SaveContent("Details\\Treated_Programs.txt");

            GetSteamGames();
            SaveContent("Details\\Installed_SteamGames.txt", true, false);
        }

        private void SaveContent(string file, bool isGame = false, bool isWeb = false) {
            List<string> content = new List<string>();

            if(isGame)
                foreach(SteamGame game in steamGames) {
                    content.Add("DisplayName    : " + game.Name);
                    content.Add("SteamID        : " + game.AppID);
                    content.Add("\n\n");
                }
            else if(isWeb)
                foreach(WebPage web in webPages) {
                    content.Add("DisplayName    : " + web.Name);
                    content.Add("URL            : " + web.Url);
                    content.Add("\n\n");
                }
            else
                foreach(SystemApplication app in systemApps) {
                    content.Add("DisplayName    : " + app.Name);
                    content.Add("DisplayVersion : " + app.Version);
                    content.Add("Publisher      : " + app.Publisher);
                    content.Add("\n\n");
                }

            File.WriteAllLines(file, content.ToArray());
        }

        private void TreatApps(string file) {
            if (!File.Exists(file))
                return;

            string[] content = File.ReadAllLines(file);

            for (int i = 0; i < content.Length - 1; i++) {
                int index = content[i].IndexOf(" ");
                if(index > 0)
                    if(content[i].Substring(0, index) == "DisplayName") {
                        SystemApplication app = new SystemApplication();
                        int start = content[i].IndexOf(":") + 2;
                        app.Name = content[i].Substring(start);

                        start = content[i + 1].IndexOf(":") + 2;
                        app.Version = content[i + 1].Substring(start);

                        start = content[i + 2].IndexOf(":") + 2;
                        app.Publisher = content[i + 2].Substring(start);

                        if(!string.IsNullOrWhiteSpace(app.Name)) {
                            bool blacklisted = false;
                            foreach (string publisher in publisherBlacklist)
                                if(app.Publisher == publisher) {
                                    blacklisted = true;
                                    break;
                                }
                            if (!blacklisted)
                                systemApps.Add(app);
                        }
                    }
            }
            systemApps.Sort((i, j) => i.Name.CompareTo(j.Name));
            systemApps = systemApps.GroupBy(x => x.Name).Select(x => x.First()).ToList();
        }

        private void GetSteamGames() {
            string path = "C:\\Program Files (x86)\\Steam\\steamapps\\libraryfolders.vdf";
            DirectoryInfo taskDirectory;

            if (File.Exists(path)) {
                steamGames = new List<SteamGame>();
                string[] fileContent = File.ReadAllLines(path);

                for (int i = 4; i < fileContent.Length - 1; i++) {
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
                steamGames.Sort((i, j) => i.Name.CompareTo(j.Name));
                steamGames = steamGames.GroupBy(x => x.Name).Select(x => x.First()).ToList();
            }
        }

        public string Langage {
            get { return langage; }
            set {
                if (value == "En" || value == "FR")
                    langage = value;
            }
        }

        public bool FirstLoad {
            get { return firstLoad; }
            set { firstLoad = value; }
        }

        public static List<SystemApplication> SystemApps {
            get { return systemApps; }
            set { systemApps = value; }
        }

        public static List<SteamGame> SteamGames {
            get { return steamGames; }
            set { steamGames = value; }
        }

        public static StackPanel ListElement {
            get { return listElement; }
            set { listElement = value; }
        }
    }
}