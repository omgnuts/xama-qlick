using System;

namespace Trak.Client.Portable
{
	public enum Priority
	{
		Normal, High
	}

	public enum WaypointStatus
	{
		Previous = -1,
		Current = 0,
		Next = 1
	}

	public enum WaypointPath
	{
		AtStart = -1,
		Middle = 0,
		AtEnd = 1 }
}
