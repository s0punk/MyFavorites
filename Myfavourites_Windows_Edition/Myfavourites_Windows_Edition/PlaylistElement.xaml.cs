using System.Windows.Controls;
using System.Windows;
using System.Net;
using System;
using System.Windows.Input;
using Microsoft.Win32;
using System.Collections.Generic;
using System.Linq;

namespace Myfavourites_Windows_Edition {
    
    public partial class PlaylistElement : UserControl {
        private string icone;
        private string elementName;

        private bool validURL;

		public PlaylistElement(string icone) {
			InitializeComponent();
            DataContext = this;

            SetComboBox();

            Icone = icone;
            if (Icone == "Web") {
                ElementName = "New Web Page";

                apps.Visibility = Visibility.Hidden;
                apps.IsEnabled = false;

                folder.Visibility = Visibility.Hidden;
                folder.IsEnabled = false;

                validURL = false;
                urlBox.KeyUp += ValidateURL;
            }  
            else {
                ElementName = "New " + Icone;

                urlBox.Visibility = Visibility.Hidden;
                urlBox.IsEnabled = false;
            }
        }

        public PlaylistElement(string icone, string elementName) { // to complete for already existing playlist
            InitializeComponent();
            DataContext = this;

            ElementName = elementName;
            SetComboBox();

            Icone = icone;
            if (Icone == "Web") {
                apps.Visibility = Visibility.Hidden;
                apps.IsEnabled = false;

                folder.Visibility = Visibility.Hidden;
                folder.IsEnabled = false;
            }
            else {
                urlBox.Visibility = Visibility.Hidden;
                urlBox.IsEnabled = false;
            }
        }

        private void SetComboBox() {
            List<SystemApplication> elements = MainWindow.SystemApps;

            elements.AddRange(MainWindow.SteamGames);
            elements.Sort((i, j) => i.Name.CompareTo(j.Name));
            elements = elements.GroupBy(x => x.Name).Select(x => x.First()).ToList();

            foreach (SystemApplication element in elements) {
                ComboBoxItem item = new ComboBoxItem();
                item.Content = element.Name;
                apps.Items.Add(item);
            }
        }

        private void Trash_Click(object sender, EventArgs e) {
            MainWindow.ListElement.Children.Remove(this);
        }

        private void ValidateURL(object sender, KeyEventArgs e) {
            if (e.Key == Key.Enter) {
                TextBox box = (TextBox)sender;
                if (!CheckURL(box.Text)) {
                    MessageBox error = new MessageBox("Invalid URL", "The entered URL is invalid.",
                                                      "Enter a valid URL or make sure you entered the URL correctly.\n\nFor example: https://Google.com", "Error", false); // Mettre url du site
                    error.Show();

                    validURL = false;
                }
                else
                    validURL = true;
            }
            else
                validURL = false;
        }

        private void File_Click(object sender, EventArgs e) {
            OpenFileDialog fileBrowser = new OpenFileDialog();

            if (fileBrowser.ShowDialog() == true)
                ElementName = fileBrowser.SafeFileName;
            MainWindow.SystemApps.Add(new SystemApplication(ElementName)); // resave in file

            ComboBoxItem appName = new ComboBoxItem();
            appName.Content = ElementName;
            apps.Items.Add(appName);
            apps.SelectedItem = appName;
        }

        private bool CheckURL(string url) {
            try {
                HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
                request.Method = "HEAD";

                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                response.Close();
                return (response.StatusCode == HttpStatusCode.OK);
            }
            catch {
                return false;
            }
        }

        public string Icone {
            get { return icone; }
            set { icone = value; }
        }

        public string ElementName {
            get { return elementName; }
            set { elementName = value; }
        }

        public bool ValidURL {
            get { return validURL; }
            set { validURL = value; }
        }
	}
}