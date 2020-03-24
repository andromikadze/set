using System.Windows;
using System.Windows.Input;

namespace Set {
    public partial class SelectPlayerWindow : Window {
        public int player;

        public SelectPlayerWindow() {
            InitializeComponent();
        }

        //Click events
        private void Blue_MouseDown(object sender, MouseButtonEventArgs e) {
            player = 0;
            DialogResult = true;
            Close();
        }
        private void Yellow_MouseDown(object sender, MouseButtonEventArgs e) {
            player = 1;
            DialogResult = true;
            Close();
        }
        private void Red_MouseDown(object sender, MouseButtonEventArgs e) {
            player = 2;
            DialogResult = true;
            Close();
        }
        private void Green_MouseDown(object sender, MouseButtonEventArgs e) {
            player = 3;
            DialogResult = true;
            Close();
        }
    }
}
