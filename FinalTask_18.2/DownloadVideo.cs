using System.Threading.Tasks;

namespace FinalTask_18._2
{
	/// <summary>
	/// Скачивание видеофайла
	/// </summary>
	class DownloadVideo : ICommand
	{
		Receiver receiver;
		/// <summary>
		/// ссылка
		/// </summary>
		public string URL { get; set; }
		/// <summary>
		/// путь загрузки
		/// </summary>
		public string Path { get; set; }

		public DownloadVideo(Receiver receiver)
		{
			this.receiver = receiver;
		}

		//Выполнение
		public async Task Run()
		{
			await receiver.Downloader(URL, Path);
			return;
		}
	}
}
