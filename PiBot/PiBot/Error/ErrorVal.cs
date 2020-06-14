#region Copyright (c) 2020 Spencer Hoffa
/// \file ErrorVal.cs
/// \author Spencer Hoffa
/// \copyright \link LICENSE.md MIT License\endlink 2020 Spencer Hoffa 
#endregion

using System;

namespace PiBot.Error
{
	public struct ErrorVal : IEquatable<ErrorVal>
	{
		public static readonly ErrorVal OK = new ErrorVal(ErrorCode.OK, "OK");

		public ErrorVal(ErrorCode code, string msg)
		{
			Code = code;
			Message = msg;
		}

		public ErrorCode Code { get; }
		public string Message { get; }

		public override bool Equals(object obj)
		{
			bool retVal = false;

			if (obj != null && GetType() == obj.GetType())
			{
				retVal = Equals((ErrorVal)obj);
			}

			return retVal;
		}

		public bool Equals(ErrorVal other)
		{
			bool retVal = false;
			if (Code == other.Code)
			{
				if (string.IsNullOrWhiteSpace(Message))
				{
					retVal = string.IsNullOrWhiteSpace(other.Message);
				}
				else
				{
					retVal = Message.Equals(other.Message);
				}
			}

			return retVal;
		}

		public override int GetHashCode()
		{
			return HashCode.Combine(Code, Message);
		}

		public static bool operator ==(ErrorVal l, ErrorVal r)
		{
			return l.Equals(r);
		}

		public static bool operator !=(ErrorVal l, ErrorVal r)
		{
			return !(l == r);
		}
	}
}
