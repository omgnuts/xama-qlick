namespace Trak.Client.Portable
{
    public enum StagePosition
    {
        Start = -1,
        Middle = 0,
        End = 1
    }

    public enum StageStatus
    {
        Completed = -1,
        Current = 0,
        Uncompleted = 1
    }



	public enum Priority
	{
		Normal, High
	}

	public enum WaypointStatus
	{
		Completed = -1,
		Current = 0,
		Uncompleted = 1
	}

	public enum WaypointPath
	{
		AtStart = -1,
		Middle = 0,
		AtEnd = 1
	}

	public enum BlockChained
	{
		Broken = -1,
		Open = 0,
		Locked = 1

	}

	public static class EnumConvert
	{
		public static string BlockChainCode(BlockChained value)
		{
			switch (value)
			{
				case BlockChained.Locked: return "Secure";
				case BlockChained.Broken: return "Broken";
				default: return "-";
			}
		}
	}

}