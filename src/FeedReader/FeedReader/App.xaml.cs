using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace FeedReader
{
	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();

			DependencyService.Register<Services.IFeedService, Services.FeedService>();
			DependencyService.Register<Services.IMessageService, Services.MessageService>();
			DependencyService.Register<Services.INavigationService, Services.NavigationService>();

			MainPage = new NavigationPage(new Views.ListPage());
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
