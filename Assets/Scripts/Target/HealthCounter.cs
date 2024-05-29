using EnemySpace;
using PlayerSpace;
using TrapSpace;
using UnityEngine;

namespace GameManager
{
	public class HealthCounter : MonoBehaviour
	{
		[SerializeField] private GameObject _heart;
		[SerializeField] private float _spawnInterval = 0.5f;
		private float _timer;
		
		public delegate void Dead();
		public static event Dead OnDead;

		private void OnEnable()
		{
			EnemyContact.OnHit += PlayerOnHit;
			Trap.OnHit += PlayerOnHit;
		}

		private void Start()
		{
			for (int i = 0; i < Player.SingletonPlayer._countHealth; i++)
			{
				Instantiate(_heart).transform.SetParent(gameObject.transform);
			}
		}

		private void Update()
		{
			_timer += Time.deltaTime;
		}

		private void PlayerOnHit()
		{
			if (_timer >= _spawnInterval)
			{
				Destroy(gameObject.transform.GetChild(transform.childCount - 1).gameObject);
				Player.SingletonPlayer._countHealth--;

				if (Player.SingletonPlayer._countHealth == 0)
				{
					OnDead?.Invoke();
				}

				_timer = 0;
			}
		}

		private void OnDisable()
		{
			EnemyContact.OnHit -= PlayerOnHit;
			Trap.OnHit -= PlayerOnHit;
		}
	}
}