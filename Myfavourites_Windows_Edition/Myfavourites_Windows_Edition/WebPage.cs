namespace MyFavourites_Windows {
    public class WebPage : App {
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
