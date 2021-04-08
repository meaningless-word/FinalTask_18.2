using System;
using System.Threading.Tasks;
using YoutubeExplode;
using YoutubeExplode.Videos;
using YoutubeExplode.Videos.Streams;

namespace FinalTask_18._2
{
	public class Receiver
	{
		/// <summary>
		/// клиент youtube
		/// </summary>
		private YoutubeClient client { get; set; }
		/// <summary>
		/// описание видео
		/// </summary>
		private Video video { get; set; }

		public Receiver()
		{
			client = new YoutubeClient();
		}

		/// <summary>
		/// запрос информации о видео
		/// </summary>
		public async Task Informer(string URL)
		{
			video = await client.Videos.GetAsync(URL);
			Console.WriteLine($"Название: {video.Title}");
			Console.WriteLine($"Продолжительность: {video.Duration}");
			Console.WriteLine($"Автор: {video.Author}");
			return;
		}

		public async Task Downloader(string URL, string Path)
		{
			// если описание не загружалось - загрузить для формирования имени файла
			if (video is null)
			{
				video = await client.Videos.GetAsync(URL);
			}
			var streams = await client.Videos.Streams.GetManifestAsync(URL);
			var streamInfo = streams.GetMuxed().WithHighestVideoQuality();
			if (streamInfo is null)
			{
				Console.Error.WriteLine("Не удалось обнаружить поток");
				return;
			}

			// Составление имени файла из пути, заголовка видео и типа содержимого
			var fileName = $"{Path}\\{video.Title}.{streamInfo.Container.Name}";

			// Загрузка
			Console.Write($"Загружается: {streamInfo.VideoQualityLabel} / {streamInfo.Container.Name}... ");
			await client.Videos.Streams.DownloadAsync(streamInfo, fileName);

			Console.WriteLine($"Видео сохранено в: '{fileName}'");
			return;
		}
	}
}
