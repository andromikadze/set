using System.Threading.Tasks;
using System.Windows;

namespace Set {
    public partial class RedWindow : Window {
        public RedWindow() {
            InitializeComponent();
            flickerScreen();
        }

        private async void flickerScreen() {
            for (int i = 0; i < 10; i++) {
                await Task.Delay(30);
                Opacity = 1;
                await Task.Delay(30);
                Opacity = 0;
            }
            Close();
        }
    }
}
