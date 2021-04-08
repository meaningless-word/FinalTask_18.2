using System.Threading.Tasks;

namespace FinalTask_18._2
{
	/// <summary>
	/// Общий интерфейс команд
	/// </summary>
	interface ICommand
	{
		Task Run();
	}
}
