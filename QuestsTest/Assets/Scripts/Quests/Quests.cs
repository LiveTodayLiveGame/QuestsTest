using System.Collections.Generic;

namespace LiveToday
{
    public class Quests
    {
        private readonly List<IQuest> _listQuests;
        private readonly PoolObject<QuestView> _poolView;
        private readonly ListQuestResources _listResources;

        public Quests(QuestsData data, PoolQuestsView poolQuests, ListQuestResources listResources)
        {
            _listQuests = data.ListQuests;

            _listResources = listResources;
           
            _poolView = poolQuests.PoolView;

            AddCollectButton.OnButtonClickEvent += AddCollectQuest;

            CollectionQuest.OnQuestCompleted += RemoveQuest;
        }

        private void AddCollectQuest()
        {
            var view = _poolView.GetFreeElement(false);

            var quest = new CollectionQuest(_listResources.GetRandomResources(), view);

            _listQuests.Add(quest);
        }

        private void RemoveQuest(IQuest quest)
        {
            _listQuests.Remove(quest);
        }
    }
}
