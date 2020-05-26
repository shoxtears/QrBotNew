using System;
using System.Threading;

using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using Telegram.Bot.Types.InlineQueryResults;

using System.Net;
using System.IO;
using System.Collections.Generic;

namespace QRbot2
{
    class Program
    {
        static TelegramBotClient Bot;

        public static List<string> Messages = new List<string>() { "", "", "" };

        public static List<string> ClearMessages(List<string> Messages)
        {
            Messages.Clear();

            Messages.Add("");

            Messages.Add("");

            Messages.Add("");

            return Messages;
        }

        static void Main()
        {
            Bot = new TelegramBotClient("1273347539:AAFUCj6twYklv6wQHBQILPMwFoEznr_XLT8");

            Bot.OnMessage += BotOnMessageReceived;
            //Bot.OnCallbackQuery += BotOnCallbackQueryReceived;
            //Bot.OnUpdate += BotOnUpdate;

            var me = Bot.GetMeAsync().Result;
            Console.WriteLine($"Hello, World! I am user {me.Id} and my name is {me.FirstName}.");

            Bot.StartReceiving();
            Console.ReadLine();
            Bot.StopReceiving();
            Thread.Sleep(int.MaxValue);
        }

        public static ReplyKeyboardMarkup keyboard1()
        {
            var replyKeyboard = new ReplyKeyboardMarkup(
               new[]

               {
                    new[] { new KeyboardButton("/start"),new KeyboardButton("/create") },

                    new[] { new KeyboardButton("/chooseTheFormat"),new KeyboardButton("/chooseTheColor") },

                    new[] { new KeyboardButton("/chooseTheSize")},

                    new[] { new KeyboardButton("/help")}

               });

            replyKeyboard.ResizeKeyboard = true;

            return replyKeyboard;
        }
        public static ReplyKeyboardMarkup keyboardColor()
        {
            var replyKeyboard = new ReplyKeyboardMarkup(
               new[]

               {
                    new[] { new KeyboardButton("/yellow"),new KeyboardButton("/green") },

                    new[] { new KeyboardButton("/red"),new KeyboardButton("/blue") },

                    new[] { new KeyboardButton("/acid"), },

                    new[] { new KeyboardButton("/help"), }

               });

            replyKeyboard.ResizeKeyboard = true;

            return replyKeyboard;
        }
        public static ReplyKeyboardMarkup keyboardFormat()
        {
            var replyKeyboard = new ReplyKeyboardMarkup(
               new[]

               {
                    new[] { new KeyboardButton("/pngQR"),new KeyboardButton("/jpgQR") },

                    new[] { new KeyboardButton("/gifQR"),new KeyboardButton("/jpegQR") },

                    new[] { new KeyboardButton("/help")},


               });

            replyKeyboard.ResizeKeyboard = true;

            return replyKeyboard;
        }
        public static ReplyKeyboardMarkup keyboardSize()
        {
            var replyKeyboard = new ReplyKeyboardMarkup(
               new[]

               {
                    new[] { new KeyboardButton("/300x300"),new KeyboardButton("/500x500") },

                    new[] { new KeyboardButton("/700x700"),new KeyboardButton("/900x900") },

                    new[] { new KeyboardButton("/1000x1000")},


               });

            replyKeyboard.ResizeKeyboard = true;

            return replyKeyboard;
        }
        private static async void BotOnMessageReceived(object sender, Telegram.Bot.Args.MessageEventArgs e)
        {
            try
            {
                var message = e.Message;
                var text = e.Message.Text;
                if (text == "/start" || text == "/create" || text == "/format" || text == "/pngQR" || text == "/jpgQR" || text == "/svgQR" || text == "/chooseTheFormat" || text == "/gifQR" || text == "/jpegQR" || text == "/yellow" || text == "/green" || text == "/blue" || text == "/red" || text == "/acid" || text == "/300x300" || text == "/500x500" || text == "/700x700" || text == "/900x900" || text == "/1000x1000" || text == "/chooseTheSize" || text == "/help" || text == "/chooseTheColor")
                {
                    string name = $"{message.From.FirstName} {message.From.LastName}";
                    Console.WriteLine($"{name} sent message : '{message.Text}'");
                    try
                    {
                        switch (text)
                        {
                            case "/start":
                                string text66 =
        @"Hello!🖼
Welcome to QRCreatorBot!
Here, you can create your unique QRCode.
You are allowed to get a photo or a file version of QRCode.

Functions:
If you want just to create a simple QRCode -
send me /create and then a link or text you want to be encrypted.
Also you can use another commands to customize your QRCode.

Bigger size - better quality, remember!

List of commands:
/start - start bot
/help - get some help
/create - to create a QRCode (and receive it as photo, not document)
/chooseTheFormat - to choose the format of file you will receive from Bot
/chooseTheColor - if you want to customize your QRCode with colors!
/chooseTheSize - if you want to customize the size of QRCode

(If you want to get a file of QRCode with different extensions - send me a /chooseTheFormat command!)

Get started!
All is simple!

Rules: If you see a message 'Insert a data' - Then you should type in the text, or the link you want make QRCode from! Warning! If you asked for a bigger size or larger format (Like jpg) - Bot will need more time than usual to answer";

                                await Bot.SendTextMessageAsync(message.From.Id, text66, replyMarkup: keyboard1());
                                break;

                            case "/chooseTheSize":

                                Messages[0] = text;
                                await Bot.SendTextMessageAsync(message.From.Id, "Select, please, the size from the list on your keyboard", replyMarkup: keyboardSize());

                                break;
                            case "/help":
                                string text4 = @"
List of commands:
/start - start bot
/help - get some help
/create - to create a QRCode \n(and receive it as photo, not document)
/chooseTheFormat - to choose the format of file you will receive from Bot
/chooseTheColor - if you want to customize your QRCode with colors!
/chooseTheSize - if you want to customize the size of QRCode

The bigger size - the better quality, remember!

If something got crushed, don't worry, just restart the bot!

If nothing works - contact me via Telegram 
(@shoxtears)
I'll be gratefull for a feedback!
Keep using!";

                                await Bot.SendTextMessageAsync(message.From.Id, text4, replyMarkup: keyboard1());
                                break;

                            case "/create":

                                Messages[0] = text;
                                await Bot.SendTextMessageAsync(message.From.Id, "Insert a data");

                                break;

                            case "/pngQR":

                                Messages[0] = text;
                                await Bot.SendTextMessageAsync(message.From.Id, "Insert a data");

                                break;
                            case "/jpgQR":

                                Messages[0] = text;
                                await Bot.SendTextMessageAsync(message.From.Id, "Insert a data");

                                break;
                            case "/svgQR":

                                Messages[0] = text;
                                await Bot.SendTextMessageAsync(message.From.Id, "Insert a data");

                                break;
                            case "/chooseTheFormat":
                                Messages[0] = text;
                                await Bot.SendTextMessageAsync(message.From.Id, "Select, please, the format from the list on your keyboard", replyMarkup: keyboardFormat());
                                break;
                            case "/gifQR":

                                Messages[0] = text;
                                await Bot.SendTextMessageAsync(message.From.Id, "Insert a data");

                                break;
                            case "/jpegQR":

                                Messages[0] = text;
                                await Bot.SendTextMessageAsync(message.From.Id, "Insert a data");

                                break;
                            case "/yellow":

                                Messages[0] = text;
                                await Bot.SendTextMessageAsync(message.From.Id, "Insert a data");

                                break;
                            case "/green":

                                Messages[0] = text;
                                await Bot.SendTextMessageAsync(message.From.Id, "Insert a data");

                                break;
                            case "/blue":

                                Messages[0] = text;
                                await Bot.SendTextMessageAsync(message.From.Id, "Insert a data");

                                break;
                            case "/red":

                                Messages[0] = text;
                                await Bot.SendTextMessageAsync(message.From.Id, "Insert a data");

                                break;
                            case "/acid":

                                Messages[0] = text;
                                await Bot.SendTextMessageAsync(message.From.Id, "Insert a data");

                                break;
                            case "/chooseTheColor":

                                Messages[0] = text;
                                await Bot.SendTextMessageAsync(message.From.Id, "Select, please, the color from the list on your keyboard 🐳\n(If you don't have the list buttons - just press the menu button, it looks like a kitchen stove!😆)", replyMarkup: keyboardColor());

                                break;
                            case "/300x300":

                                Messages[0] = text;
                                await Bot.SendTextMessageAsync(message.From.Id, "Insert a data");

                                break;
                            case "/700x700":

                                Messages[0] = text;
                                await Bot.SendTextMessageAsync(message.From.Id, "Insert a data");

                                break;
                            case "/500x500":

                                Messages[0] = text;
                                await Bot.SendTextMessageAsync(message.From.Id, "Insert a data");

                                break;
                            case "/900x900":

                                Messages[0] = text;
                                await Bot.SendTextMessageAsync(message.From.Id, "Insert a data");

                                break;
                            case "/1000x1000":

                                Messages[0] = text;
                                await Bot.SendTextMessageAsync(message.From.Id, "Insert a data");

                                break;
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Some Error");
                        await Bot.SendTextMessageAsync(e.Message.From.Id, "Oh, I'm sorry, we got some error!🛑 \nPlease, try another command or restart the bot with /start command! \nAnother questions - write to me \n(My Telegram is @shoxtears 🦖)\nPress the menu button to get comands!📱💻\nGood Luck!", replyMarkup: keyboard1());

                    }
                }
                else
                {
                    if (Messages[0] == "/create")
                    {
                        string encrypt = text;

                        await Bot.SendPhotoAsync(e.Message.Chat.Id, $"https://api.qrserver.com/v1/create-qr-code/?size=150x150&data={encrypt}", replyMarkup: keyboard1());

                        ClearMessages(Messages);
                    }
                    if (Messages[0] == "/pngQR")
                    {
                        string encrypt = text;

                        await Bot.SendDocumentAsync(e.Message.Chat.Id, $"https://api.qrserver.com/v1/create-qr-code/?size=150x150&data={encrypt}", replyMarkup: keyboard1());

                        ClearMessages(Messages);
                    }
                    if (Messages[0] == "/jpgQR")
                    {
                        string encrypt = text;

                        await Bot.SendDocumentAsync(e.Message.Chat.Id, $"https://api.qrserver.com/v1/create-qr-code/?size=150x150&data={encrypt}&format=jpg", replyMarkup: keyboard1());

                        ClearMessages(Messages);
                    }
                    if (Messages[0] == "/svgQR")
                    {
                        string encrypt = text;

                        await Bot.SendDocumentAsync(e.Message.Chat.Id, $"https://api.qrserver.com/v1/create-qr-code/?size=150x150&data={encrypt}&format=svg", replyMarkup: keyboard1());

                        ClearMessages(Messages);
                    }
                    if (Messages[0] == "/gifQR")
                    {
                        string encrypt = text;

                        await Bot.SendDocumentAsync(e.Message.Chat.Id, $"https://api.qrserver.com/v1/create-qr-code/?size=150x150&data={encrypt}&format=gif", replyMarkup: keyboard1());

                        ClearMessages(Messages);
                    }
                    if (Messages[0] == "/jpegQR")
                    {
                        string encrypt = text;

                        await Bot.SendDocumentAsync(e.Message.Chat.Id, $"https://api.qrserver.com/v1/create-qr-code/?size=150x150&data={encrypt}&format=jpg", replyMarkup: keyboard1());

                        ClearMessages(Messages);
                    }
                    if (Messages[0] == "/yellow")
                    {
                        string encrypt = text;

                        await Bot.SendDocumentAsync(e.Message.Chat.Id, $"https://api.qrserver.com/v1/create-qr-code/?size=150x150&data={encrypt}&color=255-255-0", replyMarkup: keyboard1());

                        ClearMessages(Messages);
                    }
                    if (Messages[0] == "/green")
                    {
                        string encrypt = text;

                        await Bot.SendDocumentAsync(e.Message.Chat.Id, $"https://api.qrserver.com/v1/create-qr-code/?size=150x150&data={encrypt}&color=0-255-0", replyMarkup: keyboard1());

                        ClearMessages(Messages);
                    }
                    if (Messages[0] == "/blue")
                    {
                        string encrypt = text;

                        await Bot.SendDocumentAsync(e.Message.Chat.Id, $"https://api.qrserver.com/v1/create-qr-code/?size=150x150&data={encrypt}&color=0-0-255", replyMarkup: keyboard1());

                        ClearMessages(Messages);
                    }
                    if (Messages[0] == "/red")
                    {
                        string encrypt = text;

                        await Bot.SendDocumentAsync(e.Message.Chat.Id, $"https://api.qrserver.com/v1/create-qr-code/?size=150x150&data={encrypt}&color=255-0-0", replyMarkup: keyboard1());

                        ClearMessages(Messages);
                    }
                    if (Messages[0] == "/acid")
                    {
                        string encrypt = text;

                        await Bot.SendDocumentAsync(e.Message.Chat.Id, $"https://api.qrserver.com/v1/create-qr-code/?size=150x150&data={encrypt}&color=33FF33", replyMarkup: keyboard1());

                        ClearMessages(Messages);
                    }
                    if (Messages[0] == "/300x300")
                    {
                        string encrypt = text;

                        await Bot.SendDocumentAsync(e.Message.Chat.Id, $"https://api.qrserver.com/v1/create-qr-code/?size=150x150&data={encrypt}&size=300x300", replyMarkup: keyboard1());

                        ClearMessages(Messages);
                    }
                    if (Messages[0] == "/500x500")
                    {
                        string encrypt = text;

                        await Bot.SendDocumentAsync(e.Message.Chat.Id, $"https://api.qrserver.com/v1/create-qr-code/?size=150x150&data={encrypt}&size=500x500", replyMarkup: keyboard1());

                        ClearMessages(Messages);
                    }
                    if (Messages[0] == "/700x700")
                    {
                        string encrypt = text;

                        await Bot.SendDocumentAsync(e.Message.Chat.Id, $"https://api.qrserver.com/v1/create-qr-code/?size=150x150&data={encrypt}&size=700x700", replyMarkup: keyboard1());

                        ClearMessages(Messages);
                    }
                    if (Messages[0] == "/900x900")
                    {
                        string encrypt = text;

                        await Bot.SendDocumentAsync(e.Message.Chat.Id, $"https://api.qrserver.com/v1/create-qr-code/?size=150x150&data={encrypt}&size=900x900", replyMarkup: keyboard1());

                        ClearMessages(Messages);
                    }
                    if (Messages[0] == "/1000x1000")
                    {
                        string encrypt = text;

                        await Bot.SendDocumentAsync(e.Message.Chat.Id, $"https://api.qrserver.com/v1/create-qr-code/?size=150x150&data={encrypt}&size=1000x1000", replyMarkup: keyboard1());

                        ClearMessages(Messages);
                    }
                }
            }
            catch
            {
                Console.WriteLine("Some Error");
                await Bot.SendTextMessageAsync(e.Message.From.Id, "Oh, I'm sorry, we got some error!🛑 \nPlease, try another command or restart the bot with /start command! \nAnother questions - write to me \n(My Telegram is @shoxtears 🦖)\nPress the menu button to get comands!📱💻\nGood Luck!", replyMarkup: keyboard1());
            }

        }

    }
}

