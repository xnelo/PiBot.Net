#region Copyright (c) 2020 Spencer Hoffa
/// \file MainWindowVM.cs
/// \author Spencer Hoffa
/// \copyright \link LICENSE.md MIT License\endlink 2020 Spencer Hoffa 
#endregion

using PiBot.Core;
using XneloUtils.MVVM;

namespace PiBot.App.PiBotManager
{
	public class MainWindowVM: ViewModelBase
	{
		#region Fields
		private PiBotInstanceListener m_Listener;
		#endregion

		#region Constructor
		public MainWindowVM()
		{
			m_Listener = new PiBotInstanceListener(12345);
		}

		public override void Dispose()
		{
			if (m_Listener != null)
			{
				m_Listener.Dispose();
				m_Listener = null;
			}
		}
		#endregion
	}
}
