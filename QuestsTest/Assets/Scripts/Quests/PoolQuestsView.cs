using UnityEngine;

namespace LiveToday
{ 
    public class PoolQuestsView
    {
        public readonly PoolObject<QuestView> PoolView;

        private readonly int _itemsCount = 15;
        public PoolQuestsView(PrefabsProvider prefabsProvider, Transform container)
        {
            var prefab = prefabsProvider.GetPrefab<QuestView>("QuestView");

            PoolView = new PoolObject<QuestView>(prefab, _itemsCount, container)
            {
                autoExpand = true
            };
        }
    }
}
