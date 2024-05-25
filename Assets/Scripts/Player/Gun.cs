using System.Collections.Generic;
using UnityEngine;

namespace GunSpace
{
	public class Gun : MonoBehaviour
	{
		[SerializeField] private GameObject _objectToPool;
		[SerializeField] private int _initialPoolSize;
		[SerializeField] private float _spawnInterval = 0.5f;
		private float _timer;
		private List<GameObject> _pooledObject;
		internal static bool _isPoof;
		
		private void Start()
		{
			_pooledObject = new List<GameObject>();

			for (int obj = 0; obj < _initialPoolSize; obj++)
			{
				GameObject newObj = Instantiate(_objectToPool);
				newObj.SetActive(false);
				_pooledObject.Add(newObj);
			}
		}
		
		private void Update()
		{
			_timer += Time.deltaTime;

			if (_timer >= _spawnInterval && _isPoof)
			{
				SpawnObject();
				_timer = 0f;
			}
		}

		internal GameObject GetPoolObject()
		{
			foreach (var obj in _pooledObject)
			{
				if (!obj.activeInHierarchy)
				{
					return obj;
				}
			}
			
			GameObject newObj = Instantiate(_objectToPool);
			newObj.SetActive(false);
			_pooledObject.Add(newObj);
			return newObj;
		}

		internal void SpawnObject()
		{
			GameObject obj = GetPoolObject();
			if (obj != null)
			{
				_isPoof = false;
				obj.transform.position = transform.position;
				obj.transform.rotation = transform.rotation;
				obj.SetActive(true);
			}
		}
	}
}