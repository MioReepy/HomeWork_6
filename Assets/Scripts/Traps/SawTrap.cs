using UnityEngine;

namespace TrapSpace
{
	public class SawTrap : Trap
	{
		[Header("SawTrap Position")] 
		[SerializeField] private GameObject _sawTrap;
		[SerializeField] private GameObject _waySawTrap;
		[SerializeField] private float speed = 1f;
		private float _startSawTrapPosition;
		private float _endSawTrapPosition;
		private void Start()
		{
			_startSawTrapPosition = transform.position.x + _waySawTrap.GetComponent<Renderer>().bounds.size.x / 2;
			_endSawTrapPosition = transform.position.x - _waySawTrap.GetComponent<Renderer>().bounds.size.x / 2;
		}

		private void Update()
		{
			_sawTrap.transform.position = Vector3.MoveTowards(_sawTrap.transform.position, new Vector3(_endSawTrapPosition, transform.position.y, transform.position.z),
				speed * Time.deltaTime);

			if (_sawTrap.transform.position.x == _endSawTrapPosition)
			{
				Flip();
			}
		}

		private void Flip()
		{
			var tempSawTrapPosition = _startSawTrapPosition;
			_startSawTrapPosition = _endSawTrapPosition;
			_endSawTrapPosition = tempSawTrapPosition;
			_sawTrap.transform.Rotate(0, 180, 0);
		}
	}
}