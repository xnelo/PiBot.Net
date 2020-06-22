#region Copyright (c) 2020 Spencer Hoffa
/// \file PiBot.cs
/// \author Spencer Hoffa
/// \copyright \link LICENSE.md MIT License\endlink 2020 Spencer Hoffa 
#endregion

using log4net;
using PiBot.Core.Error;

namespace PiBot.Core
{
	public class PiBot
	{
		public static ILog log = LogManager.GetLogger(typeof(PiBot));

		private volatile bool m_Running = false;
		public bool Running
		{
			get { return m_Running; }
			set
			{
				m_Running = value;
			}
		}

		public ErrorVal Run()
		{
			log.Info("Running PiBot");
			Running = true;

			while (Running)
			{
				log.Debug("Executing loop.");
				System.Threading.Thread.Sleep(1000);
			}

			log.Info("Pibot stopped");

			return ErrorVal.OK;
		}

		public void Shutdown()
		{
			log.Info("Stopping PiBot");
			Running = false;
		}
	}
}
