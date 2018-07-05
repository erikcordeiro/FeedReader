using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using FeedReader.Models;
using FeedReader.Services;
using Xamarin.Forms;

namespace FeedReader.ViewModels
{
	public class ListViewModel : ViewModelBase
	{
		private readonly IFeedService feedService;

		private RssObject rssObject;
		private bool isRefreshing;

		public RssObject RssObject
		{
			get => rssObject;
			set
			{
				rssObject = value;
				Notify();
			}
		}

		public bool IsRefreshing
		{
			get => isRefreshing;
			set
			{
				isRefreshing = value;
				Notify();
			}
		}


		public ICommand RefreshCommand { get; private set; }
		public ICommand ItemClickedCommand { get; private set; }


		public ListViewModel()
			: base()
		{
			feedService = DependencyService.Get<IFeedService>();

			RefreshCommand = new Command(ExecuteRefresh);
			ItemClickedCommand = new Command(ExecuteItemClicked);
		}


		private async void ExecuteRefresh(object arg)
		{
			IsRefreshing = true;
			string feedUrl = "http://windowsphonebrasil.com.br/index.php/feed/";
			try
			{
				RssObject = await feedService.GetFeedAsync(feedUrl);
			}
			catch (Exception)
			{
				await MessageService.ShowMessageAsync("Falha no aplicativo", "Não foi possível carregar o feed de notícias.");
			}
			finally
			{
				IsRefreshing = false;
			}
		}

		private async void ExecuteItemClicked(object arg) =>
			await NavigationService.NavigateToDetailAsync((Item)arg);
	}
}
