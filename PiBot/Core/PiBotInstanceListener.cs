#region Copyright (c) 2020 Spencer Hoffa
#endregion

using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
/// \file PiBotInstanceListener.cs
/// \author Spencer Hoffa
/// \copyright \link LICENSE.md MIT License\endlink 2020 Spencer Hoffa 
namespace PiBot.Core
{
	public class PiBotInstanceListener: IDisposable
	{
		#region Fields
		private UdpClient m_Client;
		private Task m_ListenTask;
		private bool m_ListenTaskRunning = false;
		private ushort m_ListenPort;
		#endregion

		#region Constructor
		public PiBotInstanceListener(ushort port)
		{
			m_ListenPort = port;
			m_ListenTask = Task.Run(ListenMethod);
		}

		~PiBotInstanceListener()
		{
			Dispose();
		}

		public void Dispose()
		{
			m_ListenTaskRunning = false;

			m_Client?.Close();

			if (m_ListenTask != null)
			{
				m_ListenTask.Wait(2000);
				m_ListenTask.Dispose();
				m_ListenTask = null;
			}

			m_Client?.Dispose();
			m_Client = null;
		}
		#endregion

		#region Methods
		private void ListenMethod()
		{
			m_Client = new UdpClient();
			m_Client.Client.Bind(new IPEndPoint(IPAddress.Any, m_ListenPort));

			var receivedFrom = new IPEndPoint(0, 0);

			m_ListenTaskRunning = true;
			try
			{
				while (m_ListenTaskRunning && m_Client != null)
				{
					var receivedBuffer = m_Client.Receive(ref receivedFrom);
					System.Console.WriteLine("Received From: " + receivedFrom);
					System.Console.WriteLine("Data: " + receivedBuffer);
				}
			}
			catch (SocketException)
			{ }

			m_Client?.Dispose();
			m_Client = null;
		}
		#endregion
	}
}
