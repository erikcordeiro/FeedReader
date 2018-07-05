using System;
using System.Collections.Generic;
using System.Text;

using FeedReader.Models;

namespace FeedReader.ViewModels
{
	public class DetailViewModel : ViewModelBase
	{
		private Item item;

		public Item Item
		{
			get => item;
			set
			{
				item = value;
				Notify();
			}
		}


		public DetailViewModel(Item item)
			: base()
		{
			Item = item;
		}
	}
}
