using System;
using UnityEngine;

namespace LiveToday
{
    public class AddQuestsItemButton : MonoBehaviour
    {
        public event Action<int> OnAddQuestsItemEvent;
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                var rvalue = UnityEngine.Random.Range(1, 5);
                OnAddQuestsItemEvent?.Invoke(rvalue);
            }

            if (Input.GetKeyDown(KeyCode.Q))
            {
                var rCount = UnityEngine.Random.Range(0, 4);
                OnAddQuestsItemEvent?.Invoke(rCount);
            }
        }
    }
}
