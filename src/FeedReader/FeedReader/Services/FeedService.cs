using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using FeedReader.Models;

namespace FeedReader.Services
{
	public class FeedService : IFeedService
	{
		public async Task<RssObject> GetFeedAsync(string feedUrl)
		{
			const string RSS_TO_JSON_URL = "https://api.rss2json.com/v1/api.json?rss_url={0}";
			var httpClient = new HttpClient { MaxResponseContentBufferSize = 256000 };
			var uri = new Uri(string.Format(RSS_TO_JSON_URL, feedUrl));
			var response = await httpClient.GetAsync(uri);

			if (response.IsSuccessStatusCode)
			{
				var content = await response.Content.ReadAsStringAsync();
				var result = Newtonsoft.Json.JsonConvert.DeserializeObject<RssObject>(content);

				return result;
			}
			else
			{
				throw new ApplicationException(response.ReasonPhrase);
			}
		}
	}
}
