namespace MyFavourites_Windows {
    public class SteamGame : App {
        private string appID;

        public SteamGame(string idValue, string nameValue) : base(nameValue) {
            appID = idValue;
        }

        public string AppID {
            get { return appID; }
            set { appID = value; }
        }
    }
}
