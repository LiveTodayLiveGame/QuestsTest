 using System;
 using System.Collections.Generic;
 using System.Linq;

 namespace LiveToday
{
    public class QuestsProgress
    {
        public event Action<QuestResourcesType, int> OnQuestResourcesChangedEvent;

        public readonly Dictionary<QuestResourcesType, QuestsResources> QuestsResources;

        public QuestsProgress(ListQuestResources questsResources)
        {
            QuestsResources = questsResources.ListQuestsResources.ToDictionary(r => r.Type);

            foreach (var resource in questsResources.ListQuestsResources )
            {
                resource.OnQuestResourcesChanged += delegate(int newValue)
                {
                    OnQuestResourcesChangedEvent?.Invoke(resource.Type, newValue);
                };
            }
        }

        public void AddResources(QuestResourcesType type, int value)
        {
            var resources = QuestsResources[type];
            resources.Amount += value;
        }

        public void SpendResources(QuestResourcesType type, int value)
        {
            if (!HasResources(type, value)) return;
            var resources = QuestsResources[type];
            resources.Amount -= value;
        }

        private bool HasResources(QuestResourcesType type, int value)
        {
            var resources = QuestsResources[type];
            return resources.Amount >= value;
        }

        public string GetResourcesValueToString(QuestResourcesType type)
        {
            return QuestsResources[type].Amount.ToString();
        }
    }
}
