using GunSpace;
using UnityEngine;

namespace PlayerSpace
{
	public class MovementController : MonoBehaviour
	{
		internal float _movementInput;

		private void Update()
		{
			_movementInput = Input.GetAxisRaw("Horizontal");

			if (Input.GetKeyDown(KeyCode.Space))
			{
				Player.SingletonPlayer.Jump();
			}

			if (Input.GetKeyDown(KeyCode.F))
			{
				Gun._isPoof = true;
			}
		}
	}
}