using System.Threading.Tasks;

namespace FinalTask_18._2
{
	class Sender
	{
		ICommand command;

		// Подключить команду
		public void SetCommand(ICommand command)
		{
			this.command = command;
		}

		// Выполнить команду
		public async Task Run()
		{
			if (command != null)
			{
				await command.Run();
			}
			return;
		}
	}
}
