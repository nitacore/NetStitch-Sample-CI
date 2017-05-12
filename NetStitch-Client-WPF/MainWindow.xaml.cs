using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NetStitch_Client_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        NetStitch.NetStitchClient client = new NetStitch.NetStitchClient("http://localhost:53408/");

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var stub = client.Create<NetStitch_Sample_CI.ISharedInterface>();
            var result = await stub.TallyAsync(new int[] { 100, 20, 3 });
            MessageBox.Show(result.ToString());
        }
    }
}
