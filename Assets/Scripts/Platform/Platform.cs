using UnityEngine;

namespace TrapSpace
{
	public class Platform : MonoBehaviour
	{
		[Header("Border")]
		[SerializeField] private Transform _checkTopTransform;
		[SerializeField] private Transform _checkBottomTransform;
		[SerializeField] private LayerMask _layerMask;
		private bool _isBottom;

		private void OnCollisionEnter2D(Collision2D other)
		{
			if (other.gameObject.name == "Player")
			{
				other.transform.SetParent(gameObject.transform);
			}
		}
		
		private void OnCollisionExit2D(Collision2D other)
		{
			if (other.gameObject.name == "Player")
			{
				other.transform.SetParent(null);
			}
		}

		private void FixedUpdate()
		{
			BorderCollisionCheck();

			if (_isBottom)
			{
				gameObject.GetComponent<Collider2D>().enabled = false;
			}
			else
			{
				gameObject.GetComponent<Collider2D>().enabled = true;
			}
		}

		private void BorderCollisionCheck()
		{
			_isBottom = Physics2D.OverlapArea(_checkBottomTransform.position, _checkTopTransform.position, _layerMask);
		}

		private void OnDrawGizmos()
		{
			Gizmos.color = Color.red;
			Gizmos.DrawLine(new Vector3(_checkBottomTransform.position.x, _checkBottomTransform.position.y), new Vector3(_checkTopTransform.position.x, _checkBottomTransform.position.y));
			Gizmos.DrawLine(new Vector3(_checkBottomTransform.position.x, _checkBottomTransform.position.y), new Vector3(_checkBottomTransform.position.x, _checkTopTransform.position.y));
			Gizmos.DrawLine(new Vector3(_checkTopTransform.position.x, _checkTopTransform.position.y), new Vector3(_checkTopTransform.position.x, _checkBottomTransform.position.y));
			Gizmos.DrawLine(new Vector3(_checkTopTransform.position.x, _checkTopTransform.position.y), new Vector3(_checkBottomTransform.position.x, _checkTopTransform.position.y));
		}
	}
}