using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace LiveToday
{
    public class CompleteTheQuestButton : MonoBehaviour, IPointerClickHandler
    {
        public event Action OnCompleteQuestEvent;
        private Button _button;

        private void Start()
        {
            _button = transform.GetComponent<Button>();
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (_button.interactable)
            {
                OnCompleteQuestEvent?.Invoke();
            }
        }
    }
}
