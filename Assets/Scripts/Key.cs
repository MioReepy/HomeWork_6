using PlayerSpace;
using UnityEngine;

namespace GameManager
{
	public class Key : MonoBehaviour
	{
		public delegate void KeyReceived();
		public static event KeyReceived OnKeyReceived;

		private void OnEnable()
		{
			KeyCounter._keyCount++;
		}

		private void OnTriggerEnter2D(Collider2D other)
		{
			if (other.GetComponent<Player>())
			{
				gameObject.SetActive(false);
			}
		}

		private void OnDisable()
		{
			KeyCounter._keyCount--;
			OnKeyReceived?.Invoke();
		}
	}
}