using UnityEngine;

namespace LiveToday
{
    public class EntryPoint : MonoBehaviour
    {
        [SerializeField] private Transform _poolContainer;
        [SerializeField] private AddQuestsItemButton _addButton;

        private ListQuestResources _listQuestResources;

        private void Awake()
        {
            InitQuestResources();

            InitQuestData();
        }

        private void Start()
        {
            Debug.Log("To add a quest item, press 'E'");
        }

        private void InitQuestData()
        {
            var data = new QuestsData();

            var prefabsProvider = new PrefabsProvider();

            var poolQuests = new PoolQuestsView(prefabsProvider, _poolContainer);

            var quests = new Quests(data, poolQuests, _listQuestResources);

        }

        private void InitQuestResources()
        {
            _listQuestResources = new ListQuestResources();

            var questsProgress = new QuestsProgress(_listQuestResources);

            var resourcesController = new QuestResourcesController(questsProgress, _listQuestResources, _addButton);

        }
    }
}
