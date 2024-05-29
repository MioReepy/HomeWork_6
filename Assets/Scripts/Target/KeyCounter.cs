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
				var key = _keyTarget.transform.GetChild(0);
				key.gameObject.SetActive(false);
			}
		}

		private void OnEnable()
		{
			Key.OnKeyReceived += PlayerOnKey;
		}

		private void PlayerOnKey()
		{
			gameObject.transform.GetChild(_keyCount).gameObject.transform.GetChild(0).gameObject.SetActive(true);
		}

		private void OnDisable()
		{
			Key.OnKeyReceived -= PlayerOnKey;
		}
	}
}