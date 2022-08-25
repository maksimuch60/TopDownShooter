using System;
using UnityEngine;

namespace TDS.Game.Objects
{
    public class CameraMover : MonoBehaviour
    {
        [SerializeField] private Transform _target;

        private Transform _cachedTransform;

        private void Awake()
        {
            _cachedTransform = transform;
        }

        private void LateUpdate()
        {
            Vector3 targetPosition = _target.position;
            targetPosition.z = _cachedTransform.position.z;
            _cachedTransform.position = targetPosition;
        }
    }
}