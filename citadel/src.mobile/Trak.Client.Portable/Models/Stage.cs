using System.Collections.Generic;

namespace Trak.Client.Portable.Models
{
    public class Stage
    {
        public string Title { get; set; }

        public string SubTitle { get; set; }

        public int Order { get; set; }

        public StagePosition Position(int total) {
            return GetPosition(Order, total);
        }

        static StagePosition GetPosition(int position, int total) {
            if (position == 0) return StagePosition.Start;
            if (position == (total - 1)) return StagePosition.End;
            return StagePosition.Middle;
        }

        public List<StageItem> StageItems { get; set; } = new List<StageItem>(); 

        public StageStatus Status { 
            get {
                foreach(StageItem si in StageItems) {
                    if (si.StageItemTxn == null) {
                        return StageStatus.Uncompleted;
                    }
                }
                return StageStatus.Completed;
            }
        }

    }
}
