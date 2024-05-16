using UnityEngine;

namespace Animations
{
	public class PlayerAnimationController : MonoBehaviour
	{
		private Animator _animator;
		internal bool _isMoving;
		
		private void Start()
		{
			_animator = GetComponent<Animator>();
		}
		
		private void Update()
		{
			_animator.SetBool("isMove", _isMoving);
		}
	}
}