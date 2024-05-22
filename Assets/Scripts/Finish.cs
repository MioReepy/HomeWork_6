using UnityEngine;

namespace GameManager
{
	public class Finish : MonoBehaviour
	{
		public delegate void Win();
		public static event Win OnWin;
		
		private void OnTriggerEnter2D(Collider2D other)
		{
			OnWin?.Invoke();
		}
	}
}