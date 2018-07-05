using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FeedReader.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DetailPage : ContentPage
	{
		public DetailPage(Models.Item item)
		{
			InitializeComponent ();

			BindingContext = new ViewModels.DetailViewModel(item);

			if (Device.RuntimePlatform == "iOS") { Padding = new Thickness(0, 20, 0, 0); }

			webView.Source = new HtmlWebViewSource { Html = item.content };
		}
	}
}