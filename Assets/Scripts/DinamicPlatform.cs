using UnityEngine;

namespace TrapSpace
{
	public class DinamicPlatform : Platform
	{
		[Header("Platform Position")]
		[SerializeField] private float speed = 1f;
		[SerializeField] private Vector3 _endPlatformPosition;
		private Vector3 _startPlatformPosition;

		private void Start()
		{
			_startPlatformPosition = gameObject.transform.position;
		}

		private void Update()
		{
			gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, _endPlatformPosition,
				speed * Time.deltaTime);

			if (gameObject.transform.position == _endPlatformPosition)
			{
				Flip();
			}
		}

		private void Flip()
		{
			var tempPlatformPosition = _endPlatformPosition;
			_endPlatformPosition = _startPlatformPosition;
			_startPlatformPosition = tempPlatformPosition;
		}
	}
}