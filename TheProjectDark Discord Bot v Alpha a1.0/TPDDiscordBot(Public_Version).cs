using System;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;

namespace TheProjectDark_CSarp_test_bot
{
	class Program
	{
		DiscordSocketClient client;
		static void Main(string[] args)
			=> new Program().MainAsync().GetAwaiter().GetResult();

		private async Task MainAsync()
		{
			client = new DiscordSocketClient();
			client.MessageReceived += TPDarkHandler;
			client.Log += Log;

			var token = "";
			//токен бота

			await client.LoginAsync(TokenType.Bot, token);
			await client.StartAsync();

			Console.ReadLine();
		}

		private Task Log(LogMessage arg)
		{
			Console.WriteLine(arg.ToString());
			return Task.CompletedTask;
		}

		private Task TPDarkHandler(SocketMessage arg)
		{
			if (!arg.Author.IsBot)
				switch (arg.Content)
				{
					case ".aboutbot":
						{
							arg.Channel.SendMessageAsync($"Привет, {arg.Author}, я бот разработанный TheProjectDark. Это тестовая альфа версия и функционала тут почти нету. Раработан на C# и имею открытый исходный код.");
							break;
						}
					case ".botversion":
						{
							arg.Channel.SendMessageAsync($"Версия бота: Alpha a1.0");
							break;
						}
					case ".random":
						{
							Random rnd = new Random();
							arg.Channel.SendMessageAsync($"Случайное число: {rnd.Next(-1000000000, 1000000000)}");
							break;
						}
					case ".trolling":
						{
							arg.Channel.SendMessageAsync($"@everyone");
							arg.Channel.SendMessageAsync($"@everyone");
							arg.Channel.SendMessageAsync($"@everyone");
							arg.Channel.SendMessageAsync($"@everyone");
							arg.Channel.SendMessageAsync($"@everyone");
							arg.Channel.SendMessageAsync($"@everyone");
							arg.Channel.SendMessageAsync($"@everyone");
							arg.Channel.SendMessageAsync($"@everyone");
							arg.Channel.SendMessageAsync($"@everyone");
							arg.Channel.SendMessageAsync($"@everyone");
							break;
						}
					case ".time":
						{
							arg.Channel.SendMessageAsync($"{arg.Timestamp.UtcDateTime.AddHours(3)} по киевскому времени.");
							break;
						}
					case ".help":
						{
                            arg.Channel.SendMessageAsync($".aboutbot - выводит информацию о боте.");
							arg.Channel.SendMessageAsync($".botversion - выводит версию бота.");
							arg.Channel.SendMessageAsync($".random - выводит случайное число от -1000000000 до 1000000000.");
							arg.Channel.SendMessageAsync($".trolling - 10 раз выводит сообщение, которое упоминает всех на сервере.");
							arg.Channel.SendMessageAsync($".time - выводит киевское время.");
							arg.Channel.SendMessageAsync($" .help - то что ты сейчас прописал.");
							break;
						}
				}
			return Task.CompletedTask;
		}
	}
}
