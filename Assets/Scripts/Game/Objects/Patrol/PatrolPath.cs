using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace TDS.Game.Objects.Patrol
{
    [Serializable]
    public class PatrolPath : MonoBehaviour
    {
        [SerializeField] private List<GameObject> _pointList = new();

        private int _currentPointIndex;

        public GameObject NextPoint()
        {
            if (_currentPointIndex == _pointList.Count)
            {
                _currentPointIndex = 0;
            }

            return _pointList[_currentPointIndex++];
        }

        public List<GameObject> GetPath()
        {
            return _pointList;
        }
    }
}