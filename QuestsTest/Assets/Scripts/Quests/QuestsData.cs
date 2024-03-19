using System;
using System.Collections.Generic;

namespace LiveToday
{
    [Serializable]
    public class QuestsData
    {
        public readonly List<IQuest> ListQuests = new();
    }
}
