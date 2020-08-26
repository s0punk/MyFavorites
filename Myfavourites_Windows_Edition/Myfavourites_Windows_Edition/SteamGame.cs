namespace Myfavourites_Windows_Edition {
    public class SteamGame : SystemApplication {
        private string appID;

        public SteamGame() : base() {
            AppID = "Unknown";
        }

        public SteamGame(string idValue, string nameValue) : base(nameValue) {
            appID = idValue;
        }

        public string AppID {
            get { return appID; }
            set { appID = value; }
        }
    }
}
