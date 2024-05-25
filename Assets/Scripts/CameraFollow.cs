using UnityEngine;
using EnemySpace;

namespace GameManager
{
	public class CameraFollow : MonoBehaviour
	{
		[SerializeField] private Transform _playerPosition;
		[SerializeField] private Vector3 _offSet;
		[SerializeField] private float _smoothSpeed = 0.125f;

		private void OnEnable()
		{
			EnemyContact.OnHit += OnStopCameraMoving;
		}

		private void OnStopCameraMoving()
		{
			gameObject.transform.parent = null;
		}

		private void LateUpdate()
		{
			Vector3 differentPosition = _playerPosition.position + _offSet;
			Vector3 movePosition = Vector3.Lerp(transform.position, differentPosition, _smoothSpeed);
			transform.position = new Vector3(Mathf.Clamp(movePosition.x, 0f, 16f), Mathf.Clamp(movePosition.y, -31.5f, 0f), transform.position.z);
		}

		private void OnDisable()
		{
			EnemyContact.OnHit -= OnStopCameraMoving;
		}
	}
}