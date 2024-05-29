using PlayerSpace;
using UnityEngine;

namespace GameManager
{
	public class Key : MonoBehaviour
	{
		internal static int _keyCount;

		public delegate void KeyReceived(int count);
		public static event KeyReceived OnKeyReceived;

		private void OnEnable()
		{
			_keyCount++;
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
			_keyCount--;
			OnKeyReceived?.Invoke(_keyCount);
		}
	}
}