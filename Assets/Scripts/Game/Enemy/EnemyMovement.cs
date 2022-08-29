using System;
using UnityEngine;

namespace TDS.Game.Enemy
{
    public class EnemyMovement : MonoBehaviour
    {
        [SerializeField] private Transform _targetTransform;
        [SerializeField] private EnemyTrigger _enemyTrigger;
        

        private Transform _cachedTransform;

        private void Awake()
        {
            _cachedTransform = transform;
        }

        private void Update()
        {
            if (_enemyTrigger.IsTriggered())
            {
                RotateToTarget();
            }
        }

        private void RotateToTarget()
        {
            Vector2 direction = _targetTransform.position - _cachedTransform.position;
            _cachedTransform.up = direction;
        }
    }
}