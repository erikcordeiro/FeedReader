using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FeedReader.Services
{
	public class MessageService : IMessageService
	{
		public async Task ShowMessageAsync(string title, string message) => await App.Current.MainPage.DisplayAlert(title, message, "OK");
	}
}
