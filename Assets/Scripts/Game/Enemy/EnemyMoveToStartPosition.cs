using System;
using TDS.Game.Enemy.Movement;
using UnityEngine;

namespace TDS.Game.Enemy
{
    public class EnemyMoveToStartPosition : EnemyBehaviour
    {
        [SerializeField] private EnemyDirectMovement enemyDirectMovement;
        [SerializeField] private TriggerObserver _triggerObserver;
        
        [SerializeField] private float _delta = 0.1f;

        private Transform _cachedTransform;
        private GameObject _startPoint;
        private bool _isOutOfTrigger;

        private void Awake()
        {
            _cachedTransform = transform;
            _startPoint = new GameObject();
            _startPoint.transform.position = _cachedTransform.position;
        }

        private void Start()
        {
            _triggerObserver.OnTriggerEnter += OnEntered;
            _triggerObserver.OnTriggerExit += OnExited;
        }

        private void Update()
        {
            if (!_isOutOfTrigger)
            {
                return;
            }

            if (CheckPosition())
            {
                SetTarget(null);
            }
        }

        private void OnDisable()
        {
            Destroy(_startPoint);
        }

        private bool CheckPosition()
        {
            return Vector2.Distance(_cachedTransform.position, _startPoint.transform.position) < _delta;
        }

        private void SetTarget(Transform target)
        {
            enemyDirectMovement.SetTarget(target);
        }

        private void OnEntered(Collider2D obj)
        {
            _isOutOfTrigger = false;
        }

        private void OnExited(Collider2D obj)
        {
            _isOutOfTrigger = true;
            SetTarget(_startPoint.transform);
        }
    }
}