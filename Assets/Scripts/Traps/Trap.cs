using PlayerSpace;
using UnityEngine;

namespace TrapSpace
{
	public class Trap : MonoBehaviour
	{
		public delegate void Hit();
		public static event Hit OnHit;
		protected virtual void OnCollisionEnter2D(Collision2D other)
		{
			if (other.gameObject.GetComponent<Player>())
			{
				OnHit?.Invoke();
			}
		}

		protected void OnTriggerEnter2D(Collider2D other)
		{
			if (other.gameObject.GetComponent<Player>())
			{
				OnHit?.Invoke();
			}
		}
	}
}