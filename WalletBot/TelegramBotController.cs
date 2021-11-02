using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using WalletBot.Entities;

namespace WalletBot
{
    [ApiController]
    [Route("api/message")]
    public class TelegramBotController : ControllerBase
    {
        private readonly TelegramBotClient _telegramBotClient;
        private readonly DataContext _context;

        public TelegramBotController(TelegramBot telegramBot)
        {
            _telegramBotClient = telegramBot.GetBot().Result;
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update([FromBody]object update)
        {
            // /start => register user

            var upd = JsonConvert.DeserializeObject<Update>(update.ToString());
            var chat = upd.Message?.Chat;

            if (chat == null) return Ok();

            var appUser = new AppUser
            {
                Username = chat.Username,
                ChatId = chat.Id,
                FirstName = chat.FirstName,
                Lastname = chat.LastName
            };

            await _context.Users.AddAsync(appUser);
            await _context.SaveChangesAsync();

            await _telegramBotClient.SendTextMessageAsync(chat.Id, "Вы успешно зарегистрировались", ParseMode.Markdown);

            return Ok();
        }
    }
}
