using UnityEngine;

namespace TDS.Game.Enemy.Movement
{
    public abstract class EnemyMovement : EnemyBehaviour
    {
        [SerializeField] private EnemyAnimation _enemyAnimation;
        
        public abstract void SetTarget(Transform target);

        protected void SetAnimationSpeed(float speed)
        {
            _enemyAnimation.SetSpeed(speed);
        }
    }
}