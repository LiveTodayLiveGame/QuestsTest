using System;

namespace LiveToday
{
    public interface IQuestResources
    {
        public event Action<int> OnQuestResourcesChanged;
        QuestResourcesType Type { get; }
        int Amount { get; }
    }
}
