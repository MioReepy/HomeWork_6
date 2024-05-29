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
		
		private void OnFinishEnable(int count)
		{
			if (count <= 0)
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