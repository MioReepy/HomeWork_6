using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

namespace DoTweemSpace
{
	public class TweenButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
	{
		[SerializeField] private float _highScale = 1.2f;
		[SerializeField] private float _duration = 0.5f;

		private Vector3 _originalScale;

		private void Start()
		{
			_originalScale = transform.localScale;
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
			gameObject.transform.DOScale(_originalScale * _highScale, _duration).SetEase(Ease.Flash);
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			gameObject.transform.DOScale(_originalScale, _duration).SetEase(Ease.Flash);
		}
	}
}