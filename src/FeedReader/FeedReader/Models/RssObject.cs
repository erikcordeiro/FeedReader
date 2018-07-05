using System;
using System.Collections.Generic;
using System.Text;

namespace FeedReader.Models
{

	public class RssObject
	{
		public string status { get; set; }
		public Feed feed { get; set; }
		public Item[] items { get; set; }
	}

	public class Feed
	{
		public string url { get; set; }
		public string title { get; set; }
		public string link { get; set; }
		public string author { get; set; }
		public string description { get; set; }
		public string image { get; set; }
	}

	public class Item
	{
		private string _description;

		public string title { get; set; }
		public string pubDate { get; set; }
		public string link { get; set; }
		public string guid { get; set; }
		public string author { get; set; }
		public string thumbnail { get; set; }
		public string description
		{
			get => _description;
			set => _description = ClearHtmlFragment(value);
		}
		public string content { get; set; }
		public Enclosure enclosure { get; set; }
		public string[] categories { get; set; }

		private static string ClearHtmlFragment(string htmlFragment)
		{
			var xmlDoc = new System.Xml.XmlDocument();
			xmlDoc.LoadXml($"<root>{htmlFragment}</root>");

			var temp = xmlDoc.InnerText;

			return temp.Length > 100 ? temp.Substring(0, 100) + "..." : temp;
		}
	}

	public class Enclosure
	{
	}
}
