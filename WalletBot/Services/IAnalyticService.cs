using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace WalletBot.Services
{
    public interface IAnalyticService
    {
        Task<string> GetAnalytic(Update update, int days);
    }
}