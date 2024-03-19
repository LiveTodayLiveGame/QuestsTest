using UnityEngine;

namespace LiveToday
{
    public class PrefabsProvider 
    {
        public T GetPrefab<T>(string name) where T : Object
        {
            var prefab = Resources.Load<T>("Prefabs/" + name);
            return prefab;
        }
    }
}
