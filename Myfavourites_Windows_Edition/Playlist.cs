using System.Collections.Generic;
using System.Windows.Controls;

namespace Myfavourites_Windows_Edition {
    public class Playlist {
        private int id;
        private string name;
        private bool active;

        private List<App> apps;
        private List<SteamGame> steamGames;
        private List<WebPage> webPages;

        public Playlist() {
            apps = new List<App>();
            steamGames = new List<SteamGame>();
            webPages = new List<WebPage>();

            //id = mfStartPage.window.getPlaylistsNum();
            id++;
            name = "New Playlist (" + id + ")";

            active = false;
        }

        public void addApp(App newApp) {
            if (newApp is App)
                apps.Add(newApp);
        }

        public void addSteamGame(SteamGame newSteamGame) {
            if (newSteamGame is SteamGame)
                steamGames.Add(newSteamGame);
        }

        public void addWebPage(WebPage newWebPage) {
            if (newWebPage is WebPage)
                webPages.Add(newWebPage);
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public List<App> Apps { get; set; }
        public List<SteamGame> SteamGames { get; set; }
        public List<WebPage> WebPages { get; set; }
        public bool Active { get; set; }
    }

    public class PlaylistLabel : TextBox {
        private int id;

        public PlaylistLabel(string text, int targetId) : base() {
            id = targetId;
            Text = text;
        }

        public int Id { get; set; }
    }
}
