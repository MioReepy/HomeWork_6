using UnityEngine;

namespace TrapSpace
{
	public class Trap : MonoBehaviour
	{
		public delegate void Kill();
		public static event Kill OnKill;
		protected virtual void OnCollisionEnter2D(Collision2D other)
		{
			OnKill?.Invoke();
		}
	}
}