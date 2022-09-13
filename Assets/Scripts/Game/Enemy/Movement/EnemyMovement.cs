using UnityEngine;

namespace TDS.Game.Enemy.Movement
{
    public abstract class EnemyMovement : EnemyBehaviour
    {
        public abstract void SetTarget(Transform target);
    }
}