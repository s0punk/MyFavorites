using System;
using System.Media;
using System.Windows;
using System.Windows.Input;

namespace Myfavourites_Windows_Edition {
    public partial class MessageBox : Window {
        private string titre;
        private string line1;
        private string line2;
        private string icone;

        private bool choice;

        public MessageBox(string titre, string line1, string line2, string icone, bool choice) {
            InitializeComponent();
            DataContext = this;

            Titre = titre;
            Line1 = line1;
            Line2 = line2;
            Icone = icone;
            Choice = choice;

            if(choice) {
                btn_no.Visibility = Visibility.Visible;
                btn_yes.Visibility = Visibility.Visible;
                btn_ok.Visibility = Visibility.Hidden;
            }
            else {
                btn_no.Visibility = Visibility.Hidden;
                btn_yes.Visibility = Visibility.Hidden;
                btn_ok.Visibility = Visibility.Visible;
            }
            btn_no.IsEnabled = choice;
            btn_yes.IsEnabled = choice;
            btn_ok.IsEnabled = !choice;

            if (Icone == "Error")
                SystemSounds.Exclamation.Play();
            else
                SystemSounds.Hand.Play();
        }

        private void Ok_Click(object sender, EventArgs e) {
            Close();
        }

        private void No_Click(object sender, EventArgs e) {

        }

        private void Yes_Click(object sender, EventArgs e) {

        }

        private void Window_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e) {
            if (e.ChangedButton == MouseButton.Left)
                DragMove();
        }

        public string Titre {
            get { return titre; }
            set { titre = value; }
        }
        public string Line1 {
            get { return line1; }
            set { line1 = value; }
        }
        public string Line2 {
            get { return line2; }
            set { line2 = value; }
        }
        public string Icone {
            get { return icone; }
            set { icone = value; }
        }
        public bool Choice {
            get { return choice; }
            set { choice = value; }
        }
    }
}