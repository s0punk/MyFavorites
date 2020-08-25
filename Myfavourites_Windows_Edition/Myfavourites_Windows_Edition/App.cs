using System.Data;
using System.Windows.Markup;

namespace Myfavourites_Windows_Edition {
    public class SystemApplication {
        protected string name;
        protected string publisher;
        protected string version;

        public SystemApplication() {
            Name = "Unknown";
            Publisher = "Unknown";
            Version = "Unknown";
        }

        public SystemApplication(string name) {
            Name = name;
            Publisher = "Unknown";
            Version = "Unknown";
        }

        public SystemApplication(string nameValue, string publisher) {
            name = nameValue;
            Publisher = publisher;
            Version = "Unknown";
        }

        public SystemApplication(string nameValue, string publisher, string version) {
            name = nameValue;
            Publisher = publisher;
            Version = version;
        }

        public string Name {
            get { return name; }
            set { name = value; }
        }

        public string Publisher {
            get { return publisher; }
            set { publisher = value; }
        }

        public string Version {
            get { return version; }
            set { version = value; }
        }
    }
}
