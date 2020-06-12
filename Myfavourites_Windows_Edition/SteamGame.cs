namespace Myfavourites_Windows_Edition {
    public class SteamGame : SystemApplication {
        private string appID;

        public SteamGame(string idValue, string nameValue) : base(nameValue) {
            appID = idValue;
        }

        public string AppID { get; set; }
    }
}
