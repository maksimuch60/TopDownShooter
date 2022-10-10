using System;
using UnityEngine;

namespace TDS.Game.Enemy
{
    public class EnemyInstantBackToIdle : EnemyBackToIdle
    {
        [SerializeField] private EnemyIdle _enemyIdle;

        public override void Activate()
        {
            base.Activate();
            
            Deactivate();
            _enemyIdle.Activate();
        }
    }
}