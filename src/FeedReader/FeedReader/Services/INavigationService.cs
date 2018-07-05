using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using FeedReader.Models;

namespace FeedReader.Services
{
	public interface INavigationService
	{
		Task NavigateToDetailAsync(Item item);
		Task NavigateToListAsync();
	}
}
