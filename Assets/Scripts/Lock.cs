using UnityEngine;

namespace GameManager
{
	public class Lock : MonoBehaviour
	{
		[SerializeField] private GameObject _wall;
		
		private void OnTriggerEnter2D(Collider2D other)
		{
			if (KeyCounter._keyCount <= 0)
			{
				gameObject.SetActive(false);
				_wall.SetActive(false);
			}
		}
	}
}