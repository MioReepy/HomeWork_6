using UnityEngine;
using Animations;

namespace PlayerSpace
{
	public class Player : MonoBehaviour
	{
		[Header("Movement")] 
		[SerializeField] private float _speed = 4f;
		[SerializeField] private float _jumpForce = 5f;
		private bool _isFlip;
		private int _jumpCount = 2;
		private MovementController _movementController;
		private Rigidbody2D _playerRigidbody;

		[Header("ColisionInfo")]
		[SerializeField] private Transform _groundCheckTransform;
		[SerializeField] private float _groundCheckRadius;
		[SerializeField] private LayerMask _groundLayerMask;
		private bool _isGround;
		
		private PlayerAnimationController _playerAnimationController;
		
		private void Start()
		{
			_movementController = GetComponent<MovementController>();
			_playerRigidbody = GetComponent<Rigidbody2D>();
			_playerAnimationController = GetComponent<PlayerAnimationController>();
		}

		private void Update()
		{
			Flip();
			GroudColisionCheck();
			_playerAnimationController._isMoving = _playerRigidbody.velocity.x != 0;
		}

		private void FixedUpdate()
		{
			_playerRigidbody.velocity = new Vector2(_movementController._movementInput * _speed, _playerRigidbody.velocity.y);
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