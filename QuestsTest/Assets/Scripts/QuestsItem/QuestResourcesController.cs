namespace LiveToday
{
    public class QuestResourcesController
    {
        private readonly QuestsProgress _progress;
        private readonly ListQuestResources _listResources;

        public QuestResourcesController(QuestsProgress progress, ListQuestResources listResources, AddQuestsItemButton addButton )
        {
            _progress = progress;

            _listResources = listResources;

            addButton.OnAddQuestsItemEvent += AddResources;

            CollectionQuest.OnQuestCompleted += SpendResources;
        }
        private void AddResources(int value)
        {
            var rResources = _listResources.GetRandomResources();

            _progress.AddResources(rResources.Type, value);
        }

        private void SpendResources(IQuest quest)
        {
            _progress.SpendResources(quest.Item.Type, quest.RequiredQuantity);
        }

    }
}
