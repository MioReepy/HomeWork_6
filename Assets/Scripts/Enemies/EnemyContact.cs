using System;
using GunSpace;
using UnityEngine;

namespace EnemySpace
{
	public class EnemyContact : MonoBehaviour
	{
		[SerializeField] private GameObject _enemy;
		
		public delegate void Dead();
		public static event Dead OnDead;

		public delegate void Hit();
		public static event Hit OnHit;

		private void OnCollisionEnter2D(Collision2D other)
		{
			if (gameObject.name == "DeadEnemyCollider")
			{
				DeadEnemy();
			}

			if (gameObject.name == "HitEnemyCollider")
			{
				OnHit?.Invoke();
			}
		}

		private void OnTriggerEnter2D(Collider2D other)
		{
			if (other.gameObject.GetComponent<Bullet>())
			{
				DeadEnemy();
			}
		}

		private void DeadEnemy()
		{
			Destroy(_enemy);
			OnDead?.Invoke();
		}
	}
}