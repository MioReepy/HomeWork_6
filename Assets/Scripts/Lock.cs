using System;
using UnityEngine;

namespace GameManager
{
	public class Lock : MonoBehaviour
	{
		private void OnEnable()
		{
			Key.OnKeyReceived += OnFinishEnable;
		}
		
		private void OnFinishEnable()
		{
			if (KeyCounter._keyCount <= 0)
			{
				gameObject.SetActive(false);
			}
		}
		
		private void OnDisable()
		{
			Key.OnKeyReceived -= OnFinishEnable;
		}
	}
}