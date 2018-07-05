using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using FeedReader.Services;
using Xamarin.Forms;

namespace FeedReader.ViewModels
{
	public abstract class ViewModelBase : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;


		protected IMessageService MessageService { get; private set; }
		protected INavigationService NavigationService { get; private set; }


		public ViewModelBase()
		{
			MessageService = DependencyService.Get<IMessageService>();
			NavigationService = DependencyService.Get<INavigationService>();
		}


		protected void Notify([CallerMemberName] string propertyName = default) =>
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
