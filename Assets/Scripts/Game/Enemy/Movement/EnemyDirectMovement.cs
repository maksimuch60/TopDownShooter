using UnityEngine;

namespace TDS.Game.Enemy.Movement
{
    public class EnemyDirectMovement : EnemyMovement
    {
        [SerializeField] private float _speed;

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

        public override void SetTarget(Transform target)
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

        private bool IsTargetValid()
        {
            return _target != null;
        }

        private void MoveToTarget()
        {
            Vector3 direction = (_target.position - _cachedTransform.position).normalized;
            SetVelocity(direction * _speed);
        }

        private void RotateToTarget()
        {
            Vector2 direction = _target.position - _cachedTransform.position;
            _cachedTransform.up = direction;
        }
    }
}