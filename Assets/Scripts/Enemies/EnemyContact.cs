using UnityEngine;

namespace EnemySpace
{
	public class EnemyContact : MonoBehaviour
	{
		[SerializeField] private GameObject _enemy;
		
		public delegate void Dead();
		public static event Dead OnDead;

		public delegate void Kill();
		public static event Kill OnKill;

		private void OnCollisionEnter2D(Collision2D other)
		{
			if (gameObject.name == "DeadEnemyCollider")
			{
				Destroy(_enemy);
				OnDead?.Invoke();
			}

			if (gameObject.name == "HitEnemyCollider")
			{
				OnKill?.Invoke();
			}
		}
	}
}