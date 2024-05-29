using UnityEngine;

namespace GunSpace
{
	public class Bullet : MonoBehaviour
	{
		[SerializeField] private string[] _tags;
		[SerializeField] private float _bulletSpeed = 200;
		private Rigidbody2D _rb;
		
		private void Start()
		{
			_rb = GetComponent<Rigidbody2D>();
		}

		private void Update()
		{
			float direction = transform.rotation.y >= 0 ? 1 : -1;
			_rb.velocity = new Vector2(direction * _bulletSpeed * Time.deltaTime, _rb.velocity.y);
		}

		private void OnTriggerEnter2D(Collider2D other)
		{
			foreach (var tag in _tags)
			{
				if (other.gameObject.tag == tag)
				{
					Gun.ReturnObjectToPool(gameObject);
				}
			}
		}
	}
}