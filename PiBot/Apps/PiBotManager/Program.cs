#region Copyright (c) 2020 Spencer Hoffa
/// \file Program.cs
/// \author Spencer Hoffa
/// \copyright \link LICENSE.md MIT License\endlink 2020 Spencer Hoffa 
#endregion

using System;

namespace PiBot.App.PiBotManager
{
	public class Program
	{
		[STAThread]
		static int Main(string[] args)
		{
			MainWindowVM vm = new MainWindowVM();
			MainWindowView window = new MainWindowView
			{
				DataContext = vm
			};

			App app = new App();
			app.MainWindow = window;
			app.Run(window);

			window.DataContext = null;
			vm.Dispose();
			

			return 0;
		}
	}
}
