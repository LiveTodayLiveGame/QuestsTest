using System;

namespace LiveToday
{
    public class CollectionQuest : IQuest
    {
        public static event Action<IQuest> OnQuestCompleted;
        public string DescriptionQuest { get; private set; }
        public int RequiredQuantity { get; private set; }

        public QuestsResources Item { get; private set; }

        private readonly QuestModelView _modelView;
        private readonly QuestView _view;

        public CollectionQuest(QuestsResources item, QuestView view)
        {
            Item = item;
            _view = view;

            _modelView = new QuestModelView(view);

            Subscription();
            SetNewQuest();
        }

        private void Subscription()
        {
            Item.OnQuestResourcesChanged += AddItem;

            var button = _view.gameObject.GetComponentInChildren<CompleteTheQuestButton>();
            button.OnCompleteQuestEvent += QuestCompleted;
        }

        private void SetNewQuest()
        {
            RequiredQuantity = UnityEngine.Random.Range(7, 10);
            DescriptionQuest = ($"Collect {Item.Type} : Pick {RequiredQuantity} {Item.Type}s - ");
            _modelView.SetNewData(DescriptionQuest, IsEnoughQuestItem(Item.Amount), Item.Amount, RequiredQuantity);
        }

        private bool IsEnoughQuestItem(int value)
        {
            return value >= RequiredQuantity;
        }

        protected void AddItem(int newValue)
        {
            _modelView.SetProgress(IsEnoughQuestItem(newValue), newValue, RequiredQuantity);
        }

        private void QuestCompleted()
        {
            _modelView.CompletedQuest();
            OnQuestCompleted?.Invoke(this);
        }
    }
}
    
