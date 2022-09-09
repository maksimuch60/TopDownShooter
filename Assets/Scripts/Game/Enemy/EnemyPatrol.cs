using System;
using System.Collections;
using TDS.Game.Objects.Patrol;
using UnityEngine;

namespace TDS.Game.Enemy
{
    public class EnemyPatrol : MonoBehaviour
    {
        [SerializeField] private EnemyMovement _enemyMovement;
        [SerializeField] private PatrolPath _patrolPath;

        private GameObject _patrolPointGo;
        private PatrolPoint _patrolPoint;
        private void Awake()
        {
            _patrolPointGo = new GameObject();
            _patrolPoint = new PatrolPoint();
            SetTarget(_patrolPath.NextPoint().PointPosition);
        }

        private void Update()
        {
            if (Vector3.Distance(transform.position, _patrolPoint.PointPosition) <= 0.1f)
            {
                SetTarget(_patrolPath.NextPoint().PointPosition);
            }
        }

        private void OnDrawGizmosSelected()
        {
            _patrolPath.OnDrawGizmosSelected();
        }

        private void SetTarget(Vector3 targetPosition)
        {
            _patrolPoint.SetPosition(targetPosition);
            _patrolPointGo.transform.position = targetPosition;
            _enemyMovement.SetTarget(_patrolPointGo.transform);
        }
    }
}