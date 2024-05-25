using UnityEngine;

namespace TrapSpace
{
	public class BallTrap : Trap
	{
		[SerializeField] private float _ballTrapSpeed;
		[SerializeField] private float _ballTrapBorder;
		
		private void Update()
		{
			var endBallRotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, _ballTrapBorder);

			transform.rotation = Quaternion.RotateTowards(transform.rotation, endBallRotation,
				_ballTrapSpeed * Time.deltaTime);
			
			if (transform.rotation == endBallRotation)
			{
				_ballTrapBorder *= -1f;
			}
		}
	}
}