using System;
using UnityEngine;

namespace TDS.Game.Enemy
{
    public class EnemyTrigger : MonoBehaviour
    {
        [SerializeField] private float _triggerDistance;
        [SerializeField] private Transform _targetTransform;

        private Transform _cachedTransform;

        private void Awake()
        {
            _cachedTransform = transform;
        }

        public bool IsTriggered()
        {
            return _triggerDistance >= (_targetTransform.position - _cachedTransform.position).magnitude;
        }
    }
}