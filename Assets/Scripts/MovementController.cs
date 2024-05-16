using System;
using UnityEngine;

namespace PlayerSpace
{
	public class MovementController : MonoBehaviour
	{
		private Player _player;
		internal float _movementInput;

		private void Start()
		{
			_player = GetComponent<Player>();
		}

		private void Update()
		{
			_movementInput = Input.GetAxisRaw("Horizontal");

			if (Input.GetKeyDown(KeyCode.Space))
			{
				_player.Jump();
			}
		}
	}
}