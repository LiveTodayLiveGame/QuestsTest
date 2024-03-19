using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace LiveToday
{
    public class AddCollectButton : MonoBehaviour, IPointerClickHandler
    {
        public static event Action OnButtonClickEvent;
        public void OnPointerClick(PointerEventData eventData)
        {
            OnButtonClickEvent?.Invoke();
        }
    }
}
