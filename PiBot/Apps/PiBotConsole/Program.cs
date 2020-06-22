#region Copyright (c) 2020 Spencer Hoffa
/// \file Program.cs
/// \author Spencer Hoffa
/// \copyright \link LICENSE.md MIT License\endlink 2020 Spencer Hoffa 
#endregion

using log4net;
using PiBot.Core.Error;

namespace PiBot.Apps.PiBotConsole
{
	class Program
	{
		private static readonly ILog log = LogManager.GetLogger(typeof(Program));
		private static Core.PiBot s_Bot;

		static int Main(string[] args)
		{
			var logRepo = LogManager.GetRepository(System.Reflection.Assembly.GetEntryAssembly());
			log4net.Config.XmlConfigurator.Configure(logRepo, new System.IO.FileInfo("log4net.config"));

			log.Info("Starting Pibot");

			System.Console.CancelKeyPress += Console_CancelKeyPress;

			s_Bot = new Core.PiBot();
			var result = s_Bot.Run();
			s_Bot = null;

			System.Console.CancelKeyPress -= Console_CancelKeyPress;
			if (result != ErrorVal.OK)
			{
				log.Error("Error running the bot.");
				log.Error($"Error Code: {result.Code}");
				log.Error($"Error Msg:  {result.Message}");
			}
			log.Info("Closing Pibot");
			return (int)result.Code;
		}

		private static void Console_CancelKeyPress(object sender, System.ConsoleCancelEventArgs e)
		{
			log.Debug("Catching ctl+C keypress. Shutting down PiBot.");
			e.Cancel = true;
			s_Bot?.Shutdown();
		}
	}
}
