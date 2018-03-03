using ReactiveList.ViewModels;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ReactiveList.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainViewModel ViewModel { get; set; }

        public MainPage()
        {
            this.InitializeComponent();
            ViewModel = new MainViewModel();
        }

        private void AddThree_OnClick(object sender, RoutedEventArgs e)
        {
            ViewModel.Load(3);
        }

        private void AddOneHundreed_OnClick(object sender, RoutedEventArgs e)
        {
            ViewModel.Load(100);
        }
    }
}
