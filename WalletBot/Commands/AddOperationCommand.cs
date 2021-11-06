using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using WalletBot.Services;

namespace WalletBot.Commands
{
    public class AddOperationCommand: BaseCommand
    {
        private readonly TelegramBotClient _botClient;

        public AddOperationCommand(TelegramBot telegramBot)
        {
            _botClient = telegramBot.GetBot().Result;
        }

        public override string Name => CommandNames.AddOperationCommand;
        
        public override async Task ExecuteAsync(Update update)
        {
            const string message = "Для добавления новой операции укажите сумму и описание операции в формате: \n" +
                                   "Доход - \"+1200:Петя вернул долг\" \n" +
                                   "Расход - \"-1200:Петя взял в долг\"";

            await _botClient.SendTextMessageAsync(update.Message.Chat.Id, message, ParseMode.Markdown);
        }
    }
}