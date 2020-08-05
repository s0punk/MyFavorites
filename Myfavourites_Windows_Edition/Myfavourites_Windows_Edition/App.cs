namespace Myfavourites_Windows_Edition {
    public class SystemApplication {
        protected string name;
        protected string publisher;

        public SystemApplication(string name) {
            Name = name;
            Publisher = "Unknown";
        }

        public SystemApplication(string nameValue, string publisher) {
            name = nameValue;
            Publisher = publisher;
        }

        public string Name {
            get { return name; }
            set { name = value; }
        }

        public string Publisher {
            get { return publisher; }
            set { publisher = value; }
        }
    }
}
