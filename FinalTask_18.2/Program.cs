using System;
using System.Threading.Tasks;

namespace FinalTask_18._2
{
	public static class Program
	{
		static async Task Main(string[] args)
		{
			string LinkToVideo = "https://www.youtube.com/watch?v=slvzJgJUXxw&ab_channel=brerzDMR";
			string DownloadPath = @"C:\Download";

			Sender sender = new Sender();

			Receiver receiver = new Receiver();

			ICommand cmdShowInfo = new ShowVideoInfo(receiver) { URL = LinkToVideo };
			ICommand cmdDownload = new DownloadVideo(receiver) { URL = LinkToVideo, Path= DownloadPath };

			Console.WriteLine("1: информация о видео");
			Console.WriteLine("2: скачать видео");
			var input = Console.ReadLine();
			switch (input)
			{
				case "1":
					sender.SetCommand(cmdShowInfo);
					break;
				case "2":
					sender.SetCommand(cmdDownload);
					break;
			}
			await sender.Run();
			return;
		}
	}
}
