using System.Collections.ObjectModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using XGleaner_ONE.Model;
using XGleaner_ONE.ViewModel.WebService;

// https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x804 上介绍了“空白页”项模板

namespace XGleaner_ONE
{
	/// <summary>
	/// 可用于自身或导航至 Frame 内部的空白页。
	/// </summary>
	public sealed partial class MainPage : Page
    {
		private ObservableCollection<Datum> FMPDC { get; set; }

        public MainPage()
        {
			InitializeComponent();
			FMPDC = new ObservableCollection<Datum>();
        }

		private async void Page_Loaded(object sender, RoutedEventArgs e)
		{
			await GetMainPageDatumWS.FormatMainPageDatumAsync( FMPDC );
		}
	}
}
