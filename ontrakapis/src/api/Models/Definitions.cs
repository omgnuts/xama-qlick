using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models.Definitions
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
        AtEnd = 1
    }

}
