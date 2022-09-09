using TDS.Game.Objects.Patrol;
using UnityEngine;

namespace TDS.Game.Enemy
{
    public class EnemyPatrol : MonoBehaviour
    {
        [SerializeField] private EnemyMovement _enemyMovement;
        [SerializeField] private PatrolPath _patrolPath;

        private Vector3 _currentPosition;

        private void Awake()
        {
            SetTarget(_patrolPath.NextPoint().transform);
        }

        private void Update()
        {
            if (Vector3.Distance(transform.position, _currentPosition) <= 0.1f)
            {
                SetTarget(_patrolPath.NextPoint().transform);
            }
        }

        private void SetTarget(Transform patrolPoint)
        {
            _currentPosition = patrolPoint.position;
            _enemyMovement.SetTarget(patrolPoint);
        }
    }
}