using static Deorium.Inject;
using static Deorium.Functions;
using static Deorium.Variables;
using Telegram.Bot;
using Telegram.Bot.Types;
using Microsoft.VisualBasic.ApplicationServices;

namespace Deorium
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            lang = true;
            processFind();
            var client = new TelegramBotClient($"{tknBot}");
            client.StartReceiving(Update, Error);
            this.Close();
        }
        async static Task Update(ITelegramBotClient botClient, Update update, CancellationToken token)
        {
            var msg = update.Message;
            if (msg != null)
            {
                if (msg.Chat.Id == (long)Convert.ToInt64(userID))
                {
                    if (msg.Text.ToLower().Contains("/start"))
                    {
                        if (lang)
                        {
                            botClient.SendTextMessageAsync(msg.Chat.Id, "Deorium \n \n ⭐/inject Инжект \n 💥/wallhackMenu - меню вх " +
                                "\n ⚡/radarhack - Радархак \n 🔥/antiflash - Антифлеш \n " +
                                $"🚀/bunnyhop - баннихоп \n ✨/chamsMenu - меню чамсов \n 🔹/language - Поменять язык \n ⛔/exit - выход \n \n \n {linkTG}");
                        }
                        else
                        {
                            botClient.SendTextMessageAsync(msg.Chat.Id, "Deorium \n \n ⭐/inject Inject \n 💥/wallhackMenu - Inject" +
                                "\n ⚡/radarhack - Radarhack \n 🔥/antiflash - Antiflash \n " +
                                $"🚀/bunnyhop - Bunnyhop \n ✨/chamsMenu - chams menu \n 🔹/language - Change language \n ⛔/exit - exit \n \n \n {linkTG}");
                        }
                    }
                    if (msg.Text.ToLower().Contains("/exit"))
                    {
                        Environment.Exit(1);
                    }
                    if (msg.Text.ToLower().Contains("/inject"))
                    {
                        processFind();
                        if (lang)
                        {
                            if (clientdll != null & enginedll != 0)
                            {
                                botClient.SendTextMessageAsync(msg.Chat.Id, "Процесс найден✅");
                            }
                            else
                            {
                                botClient.SendTextMessageAsync(msg.Chat.Id, "Процесс не найден!❌");
                            }
                        }
                        else
                        {
                            if (clientdll != null & enginedll != 0)
                            {
                                botClient.SendTextMessageAsync(msg.Chat.Id, "Injected✅");
                            }
                            else
                            {
                                botClient.SendTextMessageAsync(msg.Chat.Id, "Process not found!❌");
                            }
                        }
                    }
                    if (msg.Text.ToLower().Contains("/bunnyhop"))
                    {
                        bhopStatus = !bhopStatus;
                        newProcess(FuncBhop);

                        if (lang)
                        {

                            if (bhopStatus)
                            {
                                botClient.SendTextMessageAsync(msg.Chat.Id, "Баннихоп включен✅");
                            }
                            else
                            {
                                botClient.SendTextMessageAsync(msg.Chat.Id, "Баннихоп включен⛔");
                            }
                        }
                        else
                        {
                            if (bhopStatus)
                            {
                                botClient.SendTextMessageAsync(msg.Chat.Id, "Bunnyhop enabled✅");
                            }
                            else
                            {
                                botClient.SendTextMessageAsync(msg.Chat.Id, "Bunnyhop disabled⛔");
                            }
                        }
                    }
                    if (msg.Text.ToLower().Contains("/radarhack"))
                    {
                        radarStatus = !radarStatus;
                        if (radarStatus)
                        {
                            newProcess(FuncRadar);
                            if (lang)
                            {
                                botClient.SendTextMessageAsync(msg.Chat.Id, "Радархак включен✅");
                            }
                            else
                            {
                                botClient.SendTextMessageAsync(msg.Chat.Id, "Radarhack enabled✅");
                            }
                        }
                        else
                        {
                            if (lang)
                            {
                                botClient.SendTextMessageAsync(msg.Chat.Id, "Радархак выключен⛔");
                            }
                            else
                            {
                                botClient.SendTextMessageAsync(msg.Chat.Id, "Radarhack disabled⛔");
                            }
                        }
                    }
                    if (msg.Text.ToLower().Contains("/antiflash"))
                    {
                        antiflashStatus = !antiflashStatus;
                        if (antiflashStatus)
                        {
                            newProcess(FuncAntiflash);
                            if (lang)
                            {
                                botClient.SendTextMessageAsync(msg.Chat.Id, "Антифлеш включен✅");
                            }
                            else
                            {
                                botClient.SendTextMessageAsync(msg.Chat.Id, "Antiflash enabled✅");
                            }
                        }
                        else
                        {
                            if (lang)
                            {
                                botClient.SendTextMessageAsync(msg.Chat.Id, "Антифлеш выключен⛔");
                            }
                            else
                            {
                                botClient.SendTextMessageAsync(msg.Chat.Id, "Antiflash disabled⛔");
                            }
                        }
                    }
                    if (msg.Text == "/chamsMenu")
                    {
                        if (lang)
                        {
                            botClient.SendTextMessageAsync(msg.Chat.Id, "💥Меню цветов чамсов \n \n /chams - включить chams \n "
                                + "/chamsSetRed - красный цвет \n /chamsSetGreen - зеленый цвет \n "
                                + "/chamsSetBlue - синий цвет \n /chamsSetYellow - желтый цвет \n /chamsSetPink - розовый цвет "
                                + "\n ");
                        }
                        else
                        {
                            botClient.SendTextMessageAsync(msg.Chat.Id, "💥Colour Menu ВХ \n \n /wallhack - turn on wallhack \n "
                                + "/chamsSetRed - red colour \n /chamsSetGreen - green colour \n "
                                + "/chamsSetBlue - blue colour \n /chamsSetYellow - yellow colour \n /chamsSetPink - pink colour"
                                + "\n ");
                        }
                    }
                    if (msg.Text == "/wallhackMenu")
                    {
                        if (lang)
                        {
                            botClient.SendTextMessageAsync(msg.Chat.Id, "💥Меню цветов ВХ \n \n /wallhack - включить wallhack \n "
                                + "/wallhackSetRed - красный цвет \n /wallhackSetGreen - зеленый цвет \n "
                                + "/wallhackSetBlue - синий цвет \n /wallhackSetYellow - желтый цвет \n /wallhackSetPink - розовый цвет "
                                + "\n ");
                        }
                        else
                        {
                            botClient.SendTextMessageAsync(msg.Chat.Id, "💥Colour Menu ВХ \n \n /wallhack - turn on wallhack \n "
                                + "/wallhackSetRed - red colour \n /wallhackSetGreen - green colour \n "
                                + "/wallhackSetBlue - blue colour \n /wallhackSetYellow - yellow colour \n /wallhackSetPink - pink colour"
                                + "\n ");
                        }
                    }
                    if (msg.Text.ToLower().Contains("/language"))
                    {
                        lang = !lang;
                        if (lang)
                        {
                            botClient.SendTextMessageAsync(msg.Chat.Id, "Текущий язык: русский🇷🇺");
                        }
                        else
                        {
                            botClient.SendTextMessageAsync(msg.Chat.Id, "Current language: 🇬🇧");
                        }
                    }
                    switch (msg.Text)
                    {
                        case "/wallhack":
                            glowStatus = !glowStatus;
                            if (glowStatus)
                            {
                                newProcess(FuncGlow);
                                if (lang)
                                {
                                    botClient.SendTextMessageAsync(msg.Chat.Id, "Воллхак включен✅");
                                }
                                else
                                {
                                    botClient.SendTextMessageAsync(msg.Chat.Id, "Wallhack enabled✅");
                                }
                            }
                            else
                            {
                                if (lang)
                                {
                                    botClient.SendTextMessageAsync(msg.Chat.Id, "Воллхак выключен⛔");
                                }
                                else
                                {
                                    botClient.SendTextMessageAsync(msg.Chat.Id, "Wallhack disabled⛔");
                                }
                            }
                            break;
                        case "/wallhackSetRed":
                            if (lang)
                            {
                                botClient.SendTextMessageAsync(msg.Chat.Id, "Красный цвет установлен✅");
                            }
                            else
                            {
                                botClient.SendTextMessageAsync(msg.Chat.Id, "Red colour is set✅");
                            }
                            clrGlow = "red";
                            break;
                        case "/wallhackSetGreen":
                            if (lang)
                            {
                                botClient.SendTextMessageAsync(msg.Chat.Id, "Зеленый цвет установлен✅");
                            }
                            else
                            {
                                botClient.SendTextMessageAsync(msg.Chat.Id, "Green colour is set✅");
                            }
                            clrGlow = "green";
                            break;
                        case "/wallhackSetBlue":
                            if (lang)
                            {
                                botClient.SendTextMessageAsync(msg.Chat.Id, "Синий цвет установлен✅");
                            }
                            else
                            {
                                botClient.SendTextMessageAsync(msg.Chat.Id, "Blue colour is set✅");
                            }
                            clrGlow = "blue";
                            break;
                        case "/wallhackSetYellow":
                            if (lang)
                            {
                                botClient.SendTextMessageAsync(msg.Chat.Id, "Желтый цвет установлен✅");
                            }
                            else
                            {
                                botClient.SendTextMessageAsync(msg.Chat.Id, "Yellow colour is set✅");
                            }
                            clrGlow = "yellow";
                            break;
                        case "/wallhackSetPink":
                            if (lang)
                            {
                                botClient.SendTextMessageAsync(msg.Chat.Id, "Розовый цвет установлен✅");
                            }
                            else
                            {
                                botClient.SendTextMessageAsync(msg.Chat.Id, "Pink colour is set✅");
                            }
                            clrGlow = "pink";
                            break;
                        case "/chams":
                            chamsStatus = !chamsStatus;
                            if (chamsStatus)
                            {
                                newProcess(FuncChams);
                                if (lang)
                                {
                                    botClient.SendTextMessageAsync(msg.Chat.Id, "Чамсы включены✅");
                                }
                                else
                                {
                                    botClient.SendTextMessageAsync(msg.Chat.Id, "Chams enabled✅");
                                }
                            }
                            else
                            {
                                if (lang)
                                {
                                    botClient.SendTextMessageAsync(msg.Chat.Id, "Чамсы выключены⛔");
                                }
                                else
                                {
                                    botClient.SendTextMessageAsync(msg.Chat.Id, "Chams disabled⛔");
                                }
                            }
                            break;
                        case "/chamsSetRed":
                            if (lang)
                            {
                                botClient.SendTextMessageAsync(msg.Chat.Id, "Красный цвет установлен✅");
                            }
                            else
                            {
                                botClient.SendTextMessageAsync(msg.Chat.Id, "Red colour is set✅");
                            }
                            clrChams = "red";
                            break;
                        case "/chamsSetGreen":
                            if (lang)
                            {
                                botClient.SendTextMessageAsync(msg.Chat.Id, "Зеленый цвет установлен✅");
                            }
                            else
                            {
                                botClient.SendTextMessageAsync(msg.Chat.Id, "Green colour is set✅");
                            }
                            clrChams = "green";
                            break;
                        case "/chamsSetBlue":
                            if (lang)
                            {
                                botClient.SendTextMessageAsync(msg.Chat.Id, "Снний цвет установлен✅");
                            }
                            else
                            {
                                botClient.SendTextMessageAsync(msg.Chat.Id, "Blue colour is set✅");
                            }
                            clrChams = "blue";
                            break;
                        case "/chamsSetYellow":
                            if (lang)
                            {
                                botClient.SendTextMessageAsync(msg.Chat.Id, "Желтый цвет установлен✅");
                            }
                            else
                            {
                                botClient.SendTextMessageAsync(msg.Chat.Id, "Yellow colour is set✅");
                            }
                            clrChams = "yellow";
                            break;
                        case "/chamsSetPink":
                            if (lang)
                            {
                                botClient.SendTextMessageAsync(msg.Chat.Id, "Желтый цвет установлен✅");
                            }
                            else
                            {
                                botClient.SendTextMessageAsync(msg.Chat.Id, "Pink colour is set✅");
                            }
                            clrChams = "pink";
                            break;
                    }
                }
                else
                {
                    if (lang)
                    {
                        botClient.SendTextMessageAsync(msg.Chat.Id, "У вас нет доступа к боту");
                    }
                    else
                    {
                        botClient.SendTextMessageAsync(msg.Chat.Id, "You don't have access to the bot");
                    }
                }
            }
        }
        private static Task Error(ITelegramBotClient arg1, Exception arg2, CancellationToken arg3)
        {
            throw new NotImplementedException();
        }
    }
}