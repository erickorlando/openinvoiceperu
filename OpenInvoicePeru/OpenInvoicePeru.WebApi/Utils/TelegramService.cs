using System;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace OpenInvoicePeru.WebApi.Utils
{
    public class TelegramService
    {
        private readonly ITelegramBotClient _telegramBot;

        public TelegramService()
        {
            _telegramBot = new TelegramBotClient("1515003886:AAFKvOdveIdOx07N62MHUR29M6YenXzxwkY");
        }

        public async Task EnviarMensaje(string request)
        {
            _telegramBot.StartReceiving();
            var me = await _telegramBot.GetMeAsync();
#if DEBUG
            Console.WriteLine($"Bot {me.Id} is running => {me.FirstName}");
#endif
            var message = await _telegramBot.SendTextMessageAsync(new ChatId("@oipnotifications"),
                text: request);
#if DEBUG
            Console.WriteLine(message.ToString());
#endif
            //_telegramBot.OnCallbackQuery += (x, y) => _telegramBot.StopReceiving();
        }
    }
}