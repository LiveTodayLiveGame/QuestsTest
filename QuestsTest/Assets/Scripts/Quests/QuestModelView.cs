using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace LiveToday
{
    public class QuestModelView
    {
        private readonly QuestView _view;
        private readonly Button _button;
        private readonly TextMeshProUGUI _description;
        private readonly TextMeshProUGUI _progress;

        public QuestModelView(QuestView view)
        {
            _view = view;
            _button = view.transform.GetChild(0).GetComponent<Button>();
            _description = view.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
            _progress = _description.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        }

        public void SetNewData(string description, bool isEnoughItemCount, int itemValue, int requiredQuantity)
        {
            if (!isEnoughItemCount)
                SetActiveQuest(description, itemValue, requiredQuantity);
            else
                SetCompleteQuest(description, itemValue, requiredQuantity);

            InitNewQuest();
        }

        public void SetProgress( bool isEnoughItemCount, int itemValue, int requiredQuantity)
        {
            if (!isEnoughItemCount)
            {
                _description.color = Color.white;
                _progress.text = ($"({itemValue} / {requiredQuantity})");
                _progress.color = Color.white;
                _button.interactable = false;
            }
            else
            {
                _description.color = Color.green;
                _progress.text = ($"({itemValue} / {requiredQuantity})");
                _progress.color = Color.green;
                _button.interactable = true;
            }
        }

        public void CompletedQuest()
        {
            DOTween.Sequence()
                .Append(_view.transform.DOScale(0f,2f))
                .AppendCallback(AndAnimation);
        }

        private void AndAnimation()
        {
            _view.gameObject.SetActive(false);
        }

        private void InitNewQuest()
        {
            _view.gameObject.SetActive(true);
            _view.transform.DOScale(1f, 2f);
        }


        private void SetActiveQuest(string description, int itemValue, int requiredQuantity )
        {
            _description.text = description;
            _description.color = Color.white;
            _progress.text = ($"({itemValue} / {requiredQuantity})");
            _progress.color = Color.white;
            _button.interactable = false;
        }

        private void SetCompleteQuest(string description, int itemValue, int requiredQuantity)
        {
            _description.text = description;
            _description.color = Color.green;
            _progress.text = ($"({itemValue} / {requiredQuantity})");
            _progress.color = Color.green;
            _button.interactable = true;
        }
    }
}
