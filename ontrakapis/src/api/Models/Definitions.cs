namespace api.Models.Definitions
{
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

}
