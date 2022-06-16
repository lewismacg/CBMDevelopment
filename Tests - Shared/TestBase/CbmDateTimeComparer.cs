using System;
using System.Collections.Generic;

namespace Tests.Shared.TestBase
{
	public class CbmDateTimeComparer : IEqualityComparer<DateTime>
	{
		public virtual CbmDateTimeComparer.AcceptableDelta? Delta { get; set; }

		public bool Equals(DateTime x, DateTime y)
		{
			return Math.Abs((x - y).TotalMilliseconds) <= (this.Delta.HasValue ? Convert.ToDouble((object)this.Delta.Value) : 0.0);
		}

		public int GetHashCode(DateTime obj)
		{
			return obj.GetHashCode();
		}

		public enum AcceptableDelta
		{
			Second = 1000, // 0x000003E8
			Database = 60000, // 0x0000EA60
			Minute = 60000, // 0x0000EA60
			Hour = 3600000, // 0x0036EE80
		}
	}
}
