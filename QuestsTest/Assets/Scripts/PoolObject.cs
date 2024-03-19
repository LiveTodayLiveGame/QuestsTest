using System;
using System.Collections.Generic;
using UnityEngine;

namespace LiveToday
{
    public class PoolObject<T> where T : MonoBehaviour
    {
        public T prefab { get; }
        public bool autoExpand { get; set; }
        public Transform contaniner { get; }

        public List<T> pool;

        public PoolObject(T prefab, int count)
        {
            this.prefab = prefab;
            contaniner = null;
            CreatePool(count);
        }

        public PoolObject(T prefab, int count, Transform container)
        {
            this.prefab = prefab;
            contaniner = container;
            CreatePool(count);
        }

        private void CreatePool(int count)
        {
            pool = new List<T>();

            for (var i = 0; i < count; i++)
            {
                CreateObject();
            }
        }

        private T CreateObject(bool isActiveByDefault = false)
        {
            var createdObject = GameObject.Instantiate(this.prefab, this.contaniner);
            createdObject.gameObject.SetActive(isActiveByDefault);
            pool.Add(createdObject);
            return createdObject;
        }

        public bool HasFreeElement(out T element, bool isActive)
        {
            for (var i = 0; i < pool.Count; i++)
            {
                if (!pool[i].gameObject.activeInHierarchy)
                {
                    element = pool[i];
                    element.gameObject.SetActive(isActive);
                    return true;
                }
            }

            element = null;
            return false;
        }

        public T GetFreeElement(bool isActiveByDefault = true)
        {

            if (HasFreeElement(out var element, isActiveByDefault))
                return element;

            if (autoExpand)
                return CreateObject(true);

            throw new Exception($"There is no free element in pool of type:  {typeof(T)}");
        }
    }
}
