using PlayerSpace;
using UnityEngine;

namespace GunSpace
{
	public class Bullet : MonoBehaviour
	{
		[SerializeField] private float _bulletSpeed = 1f;
		[SerializeField] private float _endBulletPositionX = 100f;
		[SerializeField] private string[] _tags;

		private void Start()
		{
			if (Player.SingletonPlayer._isFlip)
			{
				_endBulletPositionX *= -1;
			}
		}

		private void Update()
		{
			gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, new Vector3(_endBulletPositionX, gameObject.transform.position.y, gameObject.transform.position.z), _bulletSpeed * Time.deltaTime);
		}

		private void OnTriggerEnter2D(Collider2D other)
		{
			foreach (var tag in _tags)
			{
				if (other.gameObject.tag == tag)
				{
					gameObject.SetActive(false);
				}
			}
		}
	}
}