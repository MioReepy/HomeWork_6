using PlayerSpace;
using UnityEngine;

namespace Fruits
{
	public class Fruit : MonoBehaviour
	{
		internal static int _bonus = 10;
		public delegate void GetBonus();
		public static event GetBonus OnGetBonus;

		internal virtual void OnTriggerEnter2D(Collider2D other)
		{
			if (other.GetComponent<Player>())
			{
				Destroy(gameObject);
				OnGetBonus?.Invoke();
			}
		}
	}
}