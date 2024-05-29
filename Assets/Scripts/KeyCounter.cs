using System;
using UnityEngine;

namespace GameManager
{
	public class KeyCounter : MonoBehaviour
	{
		[SerializeField] private GameObject _key;
		
		private void Start()
		{
			for (int i = 0; i < Key._keyCount; i++)
			{
				Instantiate(_key).transform.SetParent(gameObject.transform);
			}
		}

		private void OnEnable()
		{
			Key.OnKeyReceived += PlayerOnKey;
		}

		private void PlayerOnKey(int count)
		{
			Destroy(gameObject.transform.GetChild(transform.childCount - 1).gameObject);
		}

		private void OnDisable()
		{
			Key.OnKeyReceived-= PlayerOnKey;
		}
	}
}