using System;
using UnityEngine;

namespace EnemySpace
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private float speed = 1f;
        [SerializeField] private Vector3 _enemySnailEndPosition;
        private Vector3 _enemySnailStartPosition;
        private bool _isFlip;
        private Animator _animator;
        private bool _isDead;

        private void Start()
        {
            _enemySnailStartPosition = gameObject.transform.position;
            _animator = GetComponent<Animator>();

        }

        private void Update()
        {
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position,
                _enemySnailEndPosition, speed * Time.deltaTime);
				
            if (gameObject.transform.position == _enemySnailEndPosition)
            {
                Flip();
            }
        }

        private void Flip()
        {
            _isFlip = !_isFlip;
            transform.Rotate(0, 180, 0);
            Vector3 _enemySnailTempPosition = _enemySnailStartPosition;
            _enemySnailStartPosition = _enemySnailEndPosition;
            _enemySnailEndPosition = _enemySnailTempPosition;
        }
    }
}