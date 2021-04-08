using System.Threading.Tasks;

namespace FinalTask_18._2
{
	/// <summary>
	/// Команда отображения информации о видеоролике
	/// </summary>
	class ShowVideoInfo : ICommand
	{
		Receiver receiver;
		/// <summary>
		/// ссылка
		/// </summary>
		public string URL { get; set; }

		public ShowVideoInfo(Receiver receiver)
		{
			this.receiver = receiver;
		}

		// Выполнить
		public async Task Run()
		{
			await receiver.Informer(URL);
			return;
		}
	}
}
