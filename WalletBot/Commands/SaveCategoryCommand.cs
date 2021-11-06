using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using WalletBot.Entities;
using WalletBot.Services;

namespace WalletBot.Commands
{
    public class SaveCategoryCommand : BaseCommand
    {
        private readonly TelegramBotClient _botClient;
        private readonly DataContext _context;
        private readonly IUserService _userService;
        public SaveCategoryCommand(TelegramBot telegramBot, DataContext context, IUserService userService)
        {
            _botClient = telegramBot.GetBot().Result;
            _context = context;
            _userService = userService;
        }

        public override string Name => CommandNames.SaveCategoryCommand;

        public override async Task ExecuteAsync(Update update)
        {
            var operAndName = update.Message.Text.Split(':');
            var oper = operAndName[0];
            var name = operAndName[1].Trim();
            OperationType operationType;

            if (oper.IndexOf('-') != -1)
            {
                operationType = OperationType.Debit;
            }
            else
            {
                operationType = OperationType.Credit;
            }
            

            var user = await _userService.GetOrCreate(update);
            var categories = _context.Categories.Where(x => x.UserId == user.Id).ToList();

            if (categories.Where(c => c.Name == name && c.Type == operationType).Any())
            {
                return;
            }

            var category = new Category
            {
                Name = name,
                Type = operationType,
                User = user,
                UserId = user.Id
            };
            
            var result = await _context.Categories.AddAsync(category);

            string message = $"Добавлена категория {category.Name} в операции {(operationType == OperationType.Credit ? "расходы" : "доходы")}";

            await _botClient.SendTextMessageAsync(update.Message.Chat.Id, message, ParseMode.Markdown);
        }
    }
}
