using UnityEngine;

namespace PlayerSpace
{
	public class Player : MonoBehaviour
	{
		[Header("Movement")] 
		[SerializeField] private float _speed = 4f;
		[SerializeField] private float _jumpForce = 5f;
		internal bool _isFlip;
		private int _jumpCount = 2;
		private MovementController _movementController;
		internal Rigidbody2D _playerRigidbody;
		internal bool _isMoving;

		[Header("ColisionInfo")]
		[SerializeField] private Transform _groundCheckTransform;
		[SerializeField] private float _groundCheckRadius;
		[SerializeField] private LayerMask _groundLayerMask;
		internal bool _isGround;

		[Header("PlayerDate")] 
		[SerializeField]
		internal int _countHealth = 3;

		static public Player SingletonPlayer;
		private void Awake() => SingletonPlayer = this;

		private void Start()
		{
			_movementController = GetComponent<MovementController>();
			_playerRigidbody = GetComponent<Rigidbody2D>();
		}

		private void FixedUpdate()
		{
			GroudColisionCheck();
			_isMoving = _playerRigidbody.velocity.x != 0;
			_playerRigidbody.velocity = new Vector2(_movementController._movementInput * _speed, _playerRigidbody.velocity.y);
			Flip();
		}

		private void Flip()
		{
			if ((_playerRigidbody.velocity.x > 0 && _isFlip) || (_playerRigidbody.velocity.x < 0 && !_isFlip))
			{
				_isFlip = !_isFlip;
				transform.Rotate(0, 180, 0);
			}
		}

		internal void Jump()
		{
			if (_isGround)
			{
				_jumpCount = 2;
			}

			if (_jumpCount > 0)
			{
				_playerRigidbody.velocity = new Vector2(_playerRigidbody.velocity.x, _jumpForce);
				_jumpCount--;
			}
		}

		private void GroudColisionCheck()
		{
			_isGround = Physics2D.OverlapCircle(_groundCheckTransform.position, _groundCheckRadius, _groundLayerMask);
		}

		private void OnDrawGizmos()
		{
			Gizmos.DrawWireSphere(_groundCheckTransform.position, _groundCheckRadius);
		}
	}
}