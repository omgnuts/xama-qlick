using System.Collections.Generic;

namespace Trak.Client.Portable.Models
{
    public class StageItem
    {
        public string Title { get; set; }

        public int Order { get; set; }

        public StageItemTxn StageItemTxn { get; set; }

    }

}
