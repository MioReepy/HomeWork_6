using PlayerSpace;
using UnityEngine;

namespace Animations
{
	public class PlayerAnimationController : MonoBehaviour
	{
		private Animator _playerAnimator;
		private Player _player;
		
		private void Start()
		{
			_playerAnimator = GetComponent<Animator>();
			_player = GetComponent<Player>();
		}
		
		private void Update()
		{
			_playerAnimator.SetBool("isMove", _player._isMoving);
			_playerAnimator.SetBool("isGrounded", _player._isGround);
			_playerAnimator.SetFloat("velosityY", _player._playerRigidbody.velocity.y);
		}
	}
}