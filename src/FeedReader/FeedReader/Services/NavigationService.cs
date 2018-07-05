using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FeedReader.Models;

namespace FeedReader.Services
{
	public class NavigationService : INavigationService
	{
		public async Task NavigateToDetailAsync(Item item) => await App.Current.MainPage.Navigation.PushAsync(new Views.DetailPage(item));

		public async Task NavigateToListAsync() => await App.Current.MainPage.Navigation.PushAsync(new Views.ListPage());
	}
}
