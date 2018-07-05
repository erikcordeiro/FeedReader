using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FeedReader.Services
{
	public interface IMessageService
	{
		Task ShowMessageAsync(string title, string message);
	}
}
