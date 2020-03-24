using System.Windows;

namespace Set {
    public partial class ResultWindow : Window {
        public ResultWindow(int[] scoreboard) {
            InitializeComponent();
            Blue.Text = " Blue\n" + scoreboard[0];
            Yellow.Text = "Yellow\n" + scoreboard[1];
            Red.Text = " Red \n" + scoreboard[2];
            Green.Text = "Green\n" + scoreboard[3];
        }

        private void BlackBackground_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e) {
            Close();
        }
    }
}
