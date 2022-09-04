using System;
using UnityEngine;

namespace TDS.Game.Enemy
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class EnemyMovement : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private EnemyTrigger _enemyTrigger;

        private Rigidbody2D _rigidbody;
        private Transform _target;
        private Transform _cachedTransform;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _cachedTransform = transform;
        }

        private void OnDisable()
        {
            SetVelocity(Vector2.zero);
        }

        private void FixedUpdate()
        {
            if (!IsTargetValid())
            {
                return;
            }

            MoveToTarget();
            RotateToTarget();
        }

        public void SetTarget(Transform target)
        {
            _target = target;

            if (_target == null)
            {
                SetVelocity(Vector2.zero);
            }
        }

        private void SetVelocity(Vector2 velocity)
        {
            _rigidbody.velocity = velocity;
        }

        private void MoveToTarget()
        {
            Vector3 direction = (_target.position - _cachedTransform.position).normalized;
            SetVelocity(direction * speed);
        }

        private bool IsTargetValid()
        {
            return _target != null;
        }

        private void RotateToTarget()
        {
            Vector2 direction = _target.position - _cachedTransform.position;
            _cachedTransform.up = direction;
        }
    }
}