using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace TDS.Game.Objects.Patrol
{
    [Serializable]
    public class PatrolPoint
    {
        [SerializeField] private Vector3 _pointPosition;

        public Vector3 PointPosition => _pointPosition;

        public void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.magenta;
            Gizmos.DrawWireSphere(_pointPosition, 1);
        }

        public void SetPosition(Vector3 position)
        {
            _pointPosition = position;
        }
    }
}