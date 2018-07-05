using FeedReader.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FeedReader.Services
{
	public interface IFeedService
	{
		Task<RssObject> GetFeedAsync(string feedUrl);
	}
}
