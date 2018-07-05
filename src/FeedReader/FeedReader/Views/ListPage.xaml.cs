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
	public partial class ListPage : ContentPage
	{
		public ListPage ()
		{
			InitializeComponent ();

			BindingContext = new ViewModels.ListViewModel();

			if (Device.RuntimePlatform == "iOS") { Padding = new Thickness(0, 20, 0, 0); }
		}

		protected void listView_ItemTapped(object sender, ItemTappedEventArgs e)
		{
			ViewModels.ListViewModel viewModel = BindingContext as ViewModels.ListViewModel;
			Models.Item item = e.Item as Models.Item;
			if (viewModel.ItemClickedCommand.CanExecute(item)) viewModel.ItemClickedCommand.Execute(item);
			listView.SelectedItem = null;
		}

		protected override void OnAppearing()
		{
			ViewModels.ListViewModel viewModel = BindingContext as ViewModels.ListViewModel;
			if (viewModel.RefreshCommand.CanExecute(null)) viewModel.RefreshCommand.Execute(null);
			base.OnAppearing();
		}
	}
}