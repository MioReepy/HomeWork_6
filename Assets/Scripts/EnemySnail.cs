using UnityEngine;

namespace Enemy
{
	public class EnemySnail : MonoBehaviour
	{
		[SerializeField] private float speed = 1f;
		[SerializeField] private Vector3 _enemySnailEndPosition;
		private Vector3 _enemySnailStartPosition;
		private bool _isFlip;

		public delegate void Dead();
		public static event Dead OnDead;
		
		private void Start()
		{
			_enemySnailStartPosition = gameObject.transform.position;
		}

		private void OnCollisionEnter2D(Collision2D other)
		{
			this.gameObject.SetActive(false);
			OnDead?.Invoke();
		}

		private void OnTriggerEnter2D(Collider2D other)
		{
			other.gameObject.SetActive(false);
		}

		private void Update()
		{
				gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position,
					_enemySnailEndPosition, speed * Time.deltaTime);
				
				if (gameObject.transform.position == _enemySnailEndPosition)
				{
					Flip();
				}
		}

		private void Flip()
		{
				_isFlip = !_isFlip;
				transform.Rotate(0, 180, 0);
				Vector3 _enemySnailTempPosition = _enemySnailStartPosition;
				_enemySnailStartPosition = _enemySnailEndPosition;
				_enemySnailEndPosition = _enemySnailTempPosition;
		}
	}
}