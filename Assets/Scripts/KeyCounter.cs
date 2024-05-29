using UnityEngine;

namespace GameManager
{
	public class KeyCounter : MonoBehaviour
	{
		[SerializeField] private GameObject _keyTarget;
		internal static int _keyCount;
		
		private void Start()
		{
			for (int i = 0; i < _keyCount; i++)
			{
				Instantiate(_keyTarget).transform.SetParent(gameObject.transform);
			}
		}

		private void OnEnable()
		{
			Key.OnKeyReceived += PlayerOnKey;
		}

		private void PlayerOnKey()
		{
		}

		private void OnDisable()
		{
			Key.OnKeyReceived -= PlayerOnKey;
		}
	}
}