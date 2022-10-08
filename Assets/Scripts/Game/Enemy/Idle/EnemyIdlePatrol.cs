using TDS.Game.Enemy.Movement;
using TDS.Game.Objects;
using UnityEngine;

namespace TDS.Game.Enemy
{
    public class EnemyIdlePatrol : EnemyIdle
    {
        [SerializeField] private EnemyMovement _enemyMovement;
        [SerializeField] private PatrolPath _patrolPath;

        private Vector3 _currentPosition;

        protected override void OnActiveUpdate()
        {
            base.OnUpdate();
            
            if (Vector3.Distance(transform.position, _currentPosition) <= 0.1f)
            {
                SetTarget(_patrolPath.NextPoint().transform);
            }
        }

        public override void Activate()
        {
            base.Activate();
            
            SetTarget(_patrolPath.NextPoint().transform);
        }

        public override void Deactivate()
        {
            base.Deactivate();
            
            SetTarget(null);
        }

        private void SetTarget(Transform patrolPoint)
        {
            if (patrolPoint != null)
            {
                _currentPosition = patrolPoint.position;
            }
            _enemyMovement.SetTarget(patrolPoint);
        }
    }
}