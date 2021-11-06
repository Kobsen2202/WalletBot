using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace WalletBot.Services
{
    public interface ICommandExecutor
    {
        Task Execute(Update update);
    }
}