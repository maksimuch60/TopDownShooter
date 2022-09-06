using System;
using System.Collections;
using UnityEngine;

namespace TDS.Game.Enemy
{
    public class EnemyPatrol : MonoBehaviour
    {
        [SerializeField] private EnemyMovement _enemyMovement;
        
        [SerializeField] private Vector3 _startPoint;
        [SerializeField] private Vector3 _endPoint;

        private void Start()
        {
            StartCoroutine(PerformPatrol());
        }

        public IEnumerator PerformPatrol()
        {
            while (true)
            {
                SetTarget(_startPoint);
                yield return new WaitUntil(() => transform.position == _startPoint);
                SetTarget(_endPoint);
                yield return new WaitUntil(() => transform.position == _endPoint);
            }
        }

        public void StopPatrol()
        {
            StopAllCoroutines();
        }
            
        private void SetTarget(Vector3 targetPosition)
        {
            GameObject startPoint = new();
            startPoint.transform.position = targetPosition;
            _enemyMovement.SetTarget(startPoint.transform);
        }
    }
}