using UnityEngine;

namespace LiveToday
{
    public class ListQuestResources
    {
        public QuestsResources[] ListQuestsResources { get; private set; }

        public ListQuestResources()
        {
            var apple = new QuestsResources(QuestResourcesType.Apple);
            var mushroom = new QuestsResources(QuestResourcesType.Mushroom);
            var berries = new QuestsResources(QuestResourcesType.Berries);
            var carrot = new QuestsResources(QuestResourcesType.Carrot);

            ListQuestsResources = new QuestsResources[] { apple, mushroom, berries, carrot };
        }

        public QuestsResources GetRandomResources()
        {
            var rIndex = Random.Range(0, ListQuestsResources.Length);
            return ListQuestsResources[rIndex];
        }
    }
}
