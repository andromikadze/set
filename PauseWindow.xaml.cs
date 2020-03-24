using System.Windows;

namespace Set {
    public partial class PauseWindow : Window {
        public string decision = "";

        public PauseWindow() {
            InitializeComponent();
        }

        private void Resume_Click(object sender, RoutedEventArgs e) {
            Close();
        }
        private void Finish_Click(object sender, RoutedEventArgs e) {
            decision = "finish";
            Close();
        }
        private void Restart_Click(object sender, RoutedEventArgs e) {
            decision = "restart";
            Close();
        }
        private void Quit_Click(object sender, RoutedEventArgs e) {
            decision = "quit";
            Close();
        }
    }
}
