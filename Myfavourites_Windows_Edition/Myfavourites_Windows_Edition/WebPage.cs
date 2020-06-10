namespace Myfavourites_Windows_Edition {
    public class WebPage : SystemApplication {
        private string url;

        public WebPage(string urlValue, string nameValue) : base(nameValue) {
            url = urlValue;
        }

        public string Url {
            get { return url; }
            set { url = value; }
        }
    }
}
