using System;
using System.Collections.Generic;
using UnityEngine;

namespace TDS.Game.Objects.Patrol
{
    [Serializable]
    public class PatrolPath
    {
        [SerializeField] private List<PatrolPoint> _pointList;

        private int _currentPointIndex;
        
        public void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.magenta;
            for (int i = 0; i < _pointList.Count - 1; i++)
            {
                _pointList[i].OnDrawGizmosSelected();
                Gizmos.DrawLine(_pointList[i].PointPosition, _pointList[i+1].PointPosition);
            }
            
            _pointList[^1].OnDrawGizmosSelected();
            Gizmos.DrawLine(_pointList[^1].PointPosition, _pointList[0].PointPosition);
        }

        public PatrolPoint NextPoint()
        {
            if (_currentPointIndex == _pointList.Count)
            {
                _currentPointIndex = 0;
            }

            return _pointList[_currentPointIndex++];
        }
    }
}