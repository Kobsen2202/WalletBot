using System.Threading.Tasks;
using Telegram.Bot.Types;
using WalletBot.Entities;

namespace WalletBot.Services
{
    public interface IUserService
    {
        Task<AppUser> GetOrCreate(Update update);
    }
}