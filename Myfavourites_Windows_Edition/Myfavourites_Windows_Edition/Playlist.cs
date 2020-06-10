using System.Collections.Generic;

namespace MyFavourites_Windows {
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

            id = mfStartPage.window.getPlaylistsNum();
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

        public int Id {
            get { return id; }
            set { id = value; }
        }

        public string Name {
            get { return name; }
            set { name = value; }
        }

        public List<App> Apps {
            get { return apps; }
            set { apps = value; }
        }

        public List<SteamGame> SteamGames {
            get { return steamGames; }
            set { steamGames = value; }
        }

        public List<WebPage> WebPages {
            get { return webPages; }
            set { webPages = value; }
        }

        public bool Active {
            get { return active; }
            set { active = value; }
        }
    }
}
