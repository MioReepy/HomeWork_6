using UnityEngine;

namespace TrapSpace
{
	public class FireTrap : Trap
	{
		[SerializeField] private float _coolDown = 1;
		private float _coolDownTimer;
		private Animator _animator;
		private bool _isFire;
		
		private void Start()
		{
			_animator = GetComponent<Animator>();
		}

		private void Update()
		{
			_coolDownTimer -= Time.deltaTime;

			if (_coolDownTimer < 0)
			{
				_coolDownTimer = _coolDown;
				_isFire = !_isFire;
			}
			
			_animator.SetBool("isFire", _isFire);
		}

		protected override void OnCollisionEnter2D(Collision2D other)
		{
			if (_isFire)
			{
				base.OnCollisionEnter2D(other);
			}
		}
	}
}