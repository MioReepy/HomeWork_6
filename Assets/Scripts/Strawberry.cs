using UnityEngine;

namespace Fruits
{
	public class Strawberry : MonoBehaviour
	{
		[SerializeField] internal static int _bonus = 50;
		public delegate void GetBonus();
		public static event GetBonus OnGetBonus;
		internal virtual void OnTriggerEnter2D(Collider2D other)
		{
			gameObject.SetActive(false);
			OnGetBonus?.Invoke();
		}
	}
}