using System;

namespace LiveToday
{
    public class QuestsResources : IQuestResources
    {
        public event Action<int> OnQuestResourcesChanged;
        public QuestResourcesType Type { get; }
        public int Amount { get => _amount;
            set
            {
                var oldValue = _amount;
                _amount = value;
                if (oldValue != _amount)
                {
                    OnQuestResourcesChanged?.Invoke(_amount);
                }
            }
        }

        private int _amount;
        public QuestsResources(QuestResourcesType type)
        {
            Type = type;
        }



    }
}
