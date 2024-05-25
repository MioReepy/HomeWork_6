using PlayerSpace;
using UnityEngine;

namespace Animations
{
	public class PlayerAnimationController : MonoBehaviour
	{
		private Animator _playerAnimator;
		
		private void Start()
		{
			_playerAnimator = GetComponent<Animator>();
		}
		
		private void Update()
		{
			_playerAnimator.SetBool("isMove", Player.SingletonPlayer._isMoving);
			_playerAnimator.SetBool("isGrounded", Player.SingletonPlayer._isGround);
			_playerAnimator.SetFloat("velosityY", Player.SingletonPlayer._playerRigidbody.velocity.y);
		}
	}
}