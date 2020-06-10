namespace Myfavourites_Windows_Edition {
    public class SystemApplication {
        protected string name;

        public SystemApplication(string nameValue) {
            name = nameValue;
        }

        public string Name {
            get { return name; }
            set { name = value; }
        }
    }
}
