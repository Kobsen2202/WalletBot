using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using WalletBot.Services;

namespace WalletBot.Commands
{
    public class AddCategoryCommand : BaseCommand
    {
        private readonly TelegramBotClient _botClient;
        public AddCategoryCommand(TelegramBot telegramBot)
        {
            _botClient = telegramBot.GetBot().Result;
        }

        public override string Name => CommandNames.AddCategoryCommand;

        public override async Task ExecuteAsync(Update update)
        {
            
            const string message = "Для добавления новой категории укажите символ операции и описание категории в формате: \n" +
                                   "Доход - \"+: Вернул долг\" \n" +
                                   "Расход - \"-: Взял в долг\"";

            await _botClient.SendTextMessageAsync(update.Message.Chat.Id, message, ParseMode.Markdown);
        }
    }
}
